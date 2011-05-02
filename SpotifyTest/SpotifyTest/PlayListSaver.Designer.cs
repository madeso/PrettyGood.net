namespace PrettyGood.SpotifyTest
{
	partial class PlayListSaver
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.dSetRoot = new System.Windows.Forms.Button();
			this.dRoot = new System.Windows.Forms.TextBox();
			this.dFormat = new System.Windows.Forms.ComboBox();
			this.dSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.sfd = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// dSetRoot
			// 
			this.dSetRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dSetRoot.Location = new System.Drawing.Point(550, 12);
			this.dSetRoot.Name = "dSetRoot";
			this.dSetRoot.Size = new System.Drawing.Size(41, 23);
			this.dSetRoot.TabIndex = 0;
			this.dSetRoot.Text = "...";
			this.dSetRoot.UseVisualStyleBackColor = true;
			this.dSetRoot.Click += new System.EventHandler(this.dSetRoot_Click);
			// 
			// dRoot
			// 
			this.dRoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dRoot.Location = new System.Drawing.Point(60, 14);
			this.dRoot.Name = "dRoot";
			this.dRoot.Size = new System.Drawing.Size(484, 20);
			this.dRoot.TabIndex = 1;
			// 
			// dFormat
			// 
			this.dFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dFormat.FormattingEnabled = true;
			this.dFormat.Location = new System.Drawing.Point(57, 40);
			this.dFormat.Name = "dFormat";
			this.dFormat.Size = new System.Drawing.Size(534, 21);
			this.dFormat.TabIndex = 2;
			// 
			// dSave
			// 
			this.dSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.dSave.Location = new System.Drawing.Point(516, 70);
			this.dSave.Name = "dSave";
			this.dSave.Size = new System.Drawing.Size(75, 23);
			this.dSave.TabIndex = 3;
			this.dSave.Text = "Save...";
			this.dSave.UseVisualStyleBackColor = true;
			this.dSave.Click += new System.EventHandler(this.dSave_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Root:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Format:";
			// 
			// sfd
			// 
			this.sfd.DefaultExt = "m3u";
			this.sfd.Filter = "Playlists (*.m3u)|*.m3u|All files(*.*)|*.*";
			// 
			// PlayListSaver
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(603, 105);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dSave);
			this.Controls.Add(this.dFormat);
			this.Controls.Add(this.dRoot);
			this.Controls.Add(this.dSetRoot);
			this.Name = "PlayListSaver";
			this.Text = "PlayListSaver";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog dFolder;
		private System.Windows.Forms.Button dSetRoot;
		private System.Windows.Forms.TextBox dRoot;
		private System.Windows.Forms.ComboBox dFormat;
		private System.Windows.Forms.Button dSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.SaveFileDialog sfd;
	}
}