namespace FileSplitter {
	partial class Main {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.txtFilename = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPartSize = new System.Windows.Forms.TextBox();
			this.btnSplit = new System.Windows.Forms.Button();
			this.btnJoin = new System.Windows.Forms.Button();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.chkBase64Encode = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label4 = new System.Windows.Forms.Label();
			this.chkSplit = new System.Windows.Forms.CheckBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "File:";
			// 
			// txtFilename
			// 
			this.txtFilename.Location = new System.Drawing.Point(59, 35);
			this.txtFilename.Name = "txtFilename";
			this.txtFilename.Size = new System.Drawing.Size(270, 20);
			this.txtFilename.TabIndex = 1;
			this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.CheckFileExists = false;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(335, 33);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 2;
			this.btnBrowse.Text = "Browse...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(173, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Part size:";
			// 
			// txtPartSize
			// 
			this.txtPartSize.Location = new System.Drawing.Point(229, 61);
			this.txtPartSize.Name = "txtPartSize";
			this.txtPartSize.Size = new System.Drawing.Size(100, 20);
			this.txtPartSize.TabIndex = 4;
			this.txtPartSize.Text = "5MB";
			// 
			// btnSplit
			// 
			this.btnSplit.Enabled = false;
			this.btnSplit.Location = new System.Drawing.Point(60, 166);
			this.btnSplit.Name = "btnSplit";
			this.btnSplit.Size = new System.Drawing.Size(100, 25);
			this.btnSplit.TabIndex = 5;
			this.btnSplit.Text = "Split/Encode";
			this.btnSplit.UseVisualStyleBackColor = true;
			this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
			// 
			// btnJoin
			// 
			this.btnJoin.Enabled = false;
			this.btnJoin.Location = new System.Drawing.Point(166, 166);
			this.btnJoin.Name = "btnJoin";
			this.btnJoin.Size = new System.Drawing.Size(100, 25);
			this.btnJoin.TabIndex = 6;
			this.btnJoin.Text = "Join/Decode";
			this.btnJoin.UseVisualStyleBackColor = true;
			this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtOutput.BackColor = System.Drawing.SystemColors.ControlLight;
			this.txtOutput.Location = new System.Drawing.Point(12, 222);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.Size = new System.Drawing.Size(394, 223);
			this.txtOutput.TabIndex = 7;
			// 
			// chkBase64Encode
			// 
			this.chkBase64Encode.AutoSize = true;
			this.chkBase64Encode.Location = new System.Drawing.Point(59, 92);
			this.chkBase64Encode.Name = "chkBase64Encode";
			this.chkBase64Encode.Size = new System.Drawing.Size(101, 17);
			this.chkBase64Encode.TabIndex = 8;
			this.chkBase64Encode.Text = "Base64-encode";
			this.chkBase64Encode.UseVisualStyleBackColor = true;
			this.chkBase64Encode.CheckedChanged += new System.EventHandler(this.chkBase64Encode_CheckedChanged);
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label3.Location = new System.Drawing.Point(76, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(309, 51);
			this.label3.TabIndex = 9;
			this.label3.Text = "Encoding as Base64 may help evade some email filtering systems that strip off exe" +
				"cutable files or DLLs, but enabling this option will also increase the part size" +
				"s by 4/3.";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(418, 24);
			this.menuStrip1.TabIndex = 10;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.openToolStripMenuItem.Text = "Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 206);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Output";
			// 
			// chkSplit
			// 
			this.chkSplit.AutoSize = true;
			this.chkSplit.Location = new System.Drawing.Point(59, 63);
			this.chkSplit.Name = "chkSplit";
			this.chkSplit.Size = new System.Drawing.Size(92, 17);
			this.chkSplit.TabIndex = 12;
			this.chkSplit.Text = "Split into parts";
			this.chkSplit.UseVisualStyleBackColor = true;
			this.chkSplit.CheckedChanged += new System.EventHandler(this.chkSplit_CheckedChanged);
			// 
			// Main
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(418, 457);
			this.Controls.Add(this.chkSplit);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.chkBase64Encode);
			this.Controls.Add(this.txtOutput);
			this.Controls.Add(this.btnJoin);
			this.Controls.Add(this.btnSplit);
			this.Controls.Add(this.txtPartSize);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.txtFilename);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Main";
			this.Text = "File Splitter";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtFilename;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPartSize;
		private System.Windows.Forms.Button btnSplit;
		private System.Windows.Forms.Button btnJoin;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.CheckBox chkBase64Encode;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox chkSplit;
	}
}

