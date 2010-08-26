using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace FileSplitter {
	static class Program {
		const int defaultChunkSize = 1024 * 1024 * 5; // 5MB

		static int chunkSize = defaultChunkSize;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] argv) {
			if (argv.Length > 0) {
				HashSet<string> flags = new HashSet<string>();
				var matches = Regex.Matches(String.Join(";", argv), "-[a-zA-Z]");
				// Process arguments.
				int argIndex = 0;
				while (argIndex < argv.Length) {
					string arg = argv[argIndex];
					if (arg.StartsWith("-")) {
						arg = arg.TrimStart('-');
						ProcessArg(arg, argIndex, argv);
						flags.Add(arg);
					}
					argIndex++;
				}

				string filename = argv[argv.Length - 1];
				List<string> errors, messages;
				if (flags.Contains("e")) { // encode
					if (File.Exists(filename)) {
						SplitterCore.Base64Encode(filename, out messages, out errors);
					}
					return;
				} else if (flags.Contains("d")) { // decode
					if (File.Exists(filename)) {
						SplitterCore.Base64Decode(filename, out messages, out errors);
					}
					return;
				} else if (flags.Contains("j")) {
					if (File.Exists(filename)) {
						SplitterCore.JoinFile(filename, out messages, out errors);
					}
					return;
				}
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Main());
		}

		static void ProcessArg(string argName, int argIndex, string[] args) {
			switch (argName.ToLower()) {
				case "size":
					chunkSize = SplitterCore.ParseSize(args[argIndex + 1], defaultChunkSize);
					break;
			}
		}
	}
}
