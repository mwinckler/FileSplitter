/*
The MIT License

Copyright (c) 2009 Matt Winckler

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

public static class SplitterCore {
	public static bool SplitFile(string filename, int chunkSize, bool base64Encode, out List<string> messages, out List<string> errors) {
		messages = new List<string>();
		errors = new List<string>();
		var f = File.OpenRead(filename);

		messages.Add(String.Format(
			"Splitting {0} into {1} parts, {2} bytes per part.",
			filename,
			Math.Ceiling((double)f.Length / chunkSize).ToString(),
			chunkSize
		));


		if (f.Length <= chunkSize) {
			errors.Add("Specified file is already smaller than the desired chunk size. No need to split.");
			return false;
		}

		int pos = 0;
		int i = 0;
		while (pos < f.Length) {
			chunkSize = (int)Math.Min(chunkSize, f.Length - pos);
			byte[] chunk = new byte[chunkSize];
			f.Read(chunk, 0, chunkSize);
			pos += chunkSize;
			messages.Add("Writing chunk " + i.ToString());
			if (base64Encode) {
				File.WriteAllText(String.Format("{0}.{1}.part", filename, i++), Convert.ToBase64String(chunk));
			} else {
				File.WriteAllBytes(String.Format("{0}.{1}.part", filename, i++), chunk);
			}
		}
		f.Close();
		f.Dispose();
		messages.Add("Done.");
		return errors.Count == 0;
	}

	public static bool JoinFile(string filename, out List<string> messages, out List<string> errors) {
		messages = new List<string>();
		errors = new List<string>();


		// Find all file parts.
		byte[] part;
		int i = 0;

		messages.Add("Joining split file " + filename + ".");
		string partFilename = GetPartFilename(filename, 0);
		if (!File.Exists(partFilename)) {
			errors.Add("No part files found for base filename '" + filename + "'.");
		} else {
			// Determine whether to apply base64 decoding to this file.
			bool base64Decode = IsBase64String(File.ReadAllText(partFilename));

			var output = File.OpenWrite(filename);

			while (File.Exists(partFilename)) {
				part = base64Decode
						? Convert.FromBase64String(File.ReadAllText(partFilename))
						: File.ReadAllBytes(partFilename);
				output.Write(part, 0, part.Length);
				messages.Add("  Successfully read part " + i.ToString() + ".");
				partFilename = GetPartFilename(filename, ++i);
			}
			output.Close();
			output.Dispose();

			// Upon success, remove the parts.
			messages.Add("Removing .part files.");
			i = 0;
			partFilename = GetPartFilename(filename, 0);
			while (File.Exists(partFilename)) {
				File.Delete(partFilename);
				partFilename = GetPartFilename(filename, ++i);
			}
		}
		messages.Add("Done.");
		return errors.Count == 0;
	}


	/// <summary>
	/// Parses a string (e.g. 25KB, 1204, 1.4MB) and returns the amount in bytes.
	/// </summary>
	/// <param name="size"></param>
	/// <returns></returns>
	public static int ParseSize(string size, int defaultSize) {
		Func<double, string, int> convertToBytes = (val, units) => {
			switch (units.ToLower()) {
				case "gb":
				case "g":
				case "gbytes":
				case "gigabytes":
					// This seems unlikely. But whatever.
					return (int)Math.Round(val * 1024 * 1024 * 1024);					
				case "mb":
				case "m":
				case "mbytes":
				case "megabytes":
					return (int)Math.Round(val * 1024 * 1024);
				case "b":
				case "bytes":
					return (int)Math.Round(val);
				case "kb":
				case "k":
				case "kilobytes":
				case "kbytes":
				default: // default to KB
					return (int)Math.Round(val * 1024);
			}
		};

		var match = Regex.Match(size, @"^(\d+|\d?\.\d?)[ ]?([MmKkBb]+)?$");
		if (match.Success) {
			double d;
			if (double.TryParse(match.Groups[1].Value, out d)) {
				return convertToBytes(d, (match.Groups[2].Success ? match.Groups[2].Value : ""));
			}
		}

		return defaultSize;
	}


	public static string GetPartFilename(string filename, int partIndex) {
		return (String.Format(
								"{0}.{1}.part",
								filename,
								partIndex.ToString()
							));
	}


	/// <summary>
	/// Attempts to determine whether a string is base64-encoded.
	/// </summary>
	/// <param name="str"></param>
	/// <returns></returns>
	private static bool IsBase64String(string str) {
		if ((str.Length % 4) != 0)
			return false;

		try {
			// If not exception is cought, then it is a base64 string
			MemoryStream stream = new MemoryStream(Convert.FromBase64String(str));
			return true;
		} catch {
			// If exception is cought, then I assumed it is a normal string
			return false;
		}
	}

}
