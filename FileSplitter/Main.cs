﻿/*
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileSplitter {
	public partial class Main : Form {
		public Main() {
			InitializeComponent();
			this.Load += (sndr, e) => {
				UpdateSplitEnabled();
			};
		}

		private void WriteOutput(List<string> messages) {
			txtOutput.Text = string.Join(Environment.NewLine, messages.ToArray());
		}

		private void UpdateSplitEnabled() {
			txtPartSize.Enabled = chkSplit.Checked && File.Exists(txtFilename.Text);
			btnSplit.Enabled = (txtPartSize.Enabled && !string.IsNullOrEmpty(txtPartSize.Text))
								|| chkBase64Encode.Checked;

		}

		private void UpdateJoinEnabled() {
			string fname = System.Text.RegularExpressions.Regex.Replace(txtFilename.Text, @"\.\d+\.part$", "");
			btnJoin.Enabled = (File.Exists(
				Path.GetDirectoryName(txtFilename.Text) + @"\" +
					SplitterCore.GetPartFilename(
						Path.GetFileName(fname)
						, 0)
				))
				|| (txtFilename.Text.EndsWith(".base64") && File.Exists(txtFilename.Text));
		}

		private void txtFilename_TextChanged(object sender, EventArgs e) {
			UpdateSplitEnabled();
			UpdateJoinEnabled();

		}

		private void btnSplit_Click(object sender, EventArgs e) {
			List<string> errors, messages;
			if (chkSplit.Checked) {
				int chunkSize = SplitterCore.ParseSize(txtPartSize.Text, 1024 * 1024 * 5);
				if (SplitterCore.SplitFile(txtFilename.Text, chunkSize, chkBase64Encode.Checked, out messages, out errors)) {
					WriteOutput(messages);
				} else {
					WriteOutput(errors);
				}
			} else if (chkBase64Encode.Checked) {
				if (SplitterCore.Base64Encode(txtFilename.Text, out messages, out errors)) {
					WriteOutput(messages);
				} else {
					WriteOutput(errors);
				}
			} else {
				txtOutput.Text = "No operation selected; nothing done.";
			}
		}

		private void btnJoin_Click(object sender, EventArgs e) {
			List<string> errors, messages;
			if (txtFilename.Text.EndsWith(".part")) {
				if (SplitterCore.JoinFile(txtFilename.Text, out messages, out errors)) {
					WriteOutput(messages);
				} else {
					WriteOutput(errors);
				}
			} else {
				
				if (SplitterCore.Base64Decode(txtFilename.Text, out messages, out errors)) {
					WriteOutput(messages);
				} else {
					WriteOutput(errors);
				}
			}
		}

		private void BrowseForFile() {
			if (openFileDialog1.ShowDialog() == DialogResult.OK) {
				txtFilename.Text = openFileDialog1.FileName;
			}
		}

		private void btnBrowse_Click(object sender, EventArgs e) {
			BrowseForFile();
		}

		private void Main_DragDrop(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				txtFilename.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
			}
		}

		private void Main_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			BrowseForFile();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Application.Exit();
		}

		private void usageToolStripMenuItem_Click(object sender, EventArgs e) {
			Help.ShowHelpIndex(this, "splitter_help.chm");
		}

		private void chkSplit_CheckedChanged(object sender, EventArgs e) {
			UpdateSplitEnabled();
		}

		private void chkBase64Encode_CheckedChanged(object sender, EventArgs e) {
			UpdateSplitEnabled();
		}

	}
}
