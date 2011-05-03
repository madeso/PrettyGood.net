﻿namespace PrettyGood.SpotifyTest
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
			this.dSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.sfd = new System.Windows.Forms.SaveFileDialog();
			this.dRoots = new System.Windows.Forms.TextBox();
			this.dCompile = new System.Windows.Forms.Button();
			this.dCompileResults = new System.Windows.Forms.Label();
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
			// dSave
			// 
			this.dSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.dSave.Location = new System.Drawing.Point(469, 142);
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
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Roots:";
			// 
			// sfd
			// 
			this.sfd.DefaultExt = "m3u";
			this.sfd.Filter = "Playlists (*.m3u)|*.m3u|All files(*.*)|*.*";
			// 
			// dRoots
			// 
			this.dRoots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dRoots.Location = new System.Drawing.Point(56, 14);
			this.dRoots.Multiline = true;
			this.dRoots.Name = "dRoots";
			this.dRoots.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.dRoots.Size = new System.Drawing.Size(488, 122);
			this.dRoots.TabIndex = 6;
			this.dRoots.WordWrap = false;
			// 
			// dCompile
			// 
			this.dCompile.Location = new System.Drawing.Point(56, 142);
			this.dCompile.Name = "dCompile";
			this.dCompile.Size = new System.Drawing.Size(75, 23);
			this.dCompile.TabIndex = 7;
			this.dCompile.Text = "Compile";
			this.dCompile.UseVisualStyleBackColor = true;
			this.dCompile.Click += new System.EventHandler(this.dCompile_Click);
			// 
			// dCompileResults
			// 
			this.dCompileResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dCompileResults.Location = new System.Drawing.Point(137, 147);
			this.dCompileResults.Name = "dCompileResults";
			this.dCompileResults.Size = new System.Drawing.Size(326, 18);
			this.dCompileResults.TabIndex = 8;
			this.dCompileResults.Text = "Not Compiled!";
			// 
			// PlayListSaver
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(603, 177);
			this.Controls.Add(this.dCompileResults);
			this.Controls.Add(this.dCompile);
			this.Controls.Add(this.dRoots);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dSave);
			this.Controls.Add(this.dSetRoot);
			this.Name = "PlayListSaver";
			this.Text = "PlayListSaver";
			this.Load += new System.EventHandler(this.PlayListSaver_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog dFolder;
		private System.Windows.Forms.Button dSetRoot;
		private System.Windows.Forms.Button dSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.SaveFileDialog sfd;
		private System.Windows.Forms.TextBox dRoots;
		private System.Windows.Forms.Button dCompile;
		private System.Windows.Forms.Label dCompileResults;
	}
}