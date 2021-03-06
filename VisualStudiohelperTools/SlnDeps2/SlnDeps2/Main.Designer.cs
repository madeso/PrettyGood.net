﻿namespace SlnDeps
{
	partial class Main
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dSource = new System.Windows.Forms.TextBox();
			this.dTarget = new System.Windows.Forms.TextBox();
			this.dFormat = new System.Windows.Forms.TextBox();
			this.dBrowseSource = new System.Windows.Forms.Button();
			this.dBrowseTarget = new System.Windows.Forms.Button();
			this.dGo = new System.Windows.Forms.Button();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.sfd = new System.Windows.Forms.SaveFileDialog();
			this.dExcludes = new System.Windows.Forms.CheckedListBox();
			this.dFillExcludes = new System.Windows.Forms.Button();
			this.dSimplifyLinks = new System.Windows.Forms.CheckBox();
			this.dStyle = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.dOpen = new System.Windows.Forms.Button();
			this.dReverseArrows = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(19, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Source:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Target:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(21, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Format:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 113);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Includes:";
			// 
			// dSource
			// 
			this.dSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dSource.Location = new System.Drawing.Point(69, 12);
			this.dSource.Name = "dSource";
			this.dSource.Size = new System.Drawing.Size(357, 20);
			this.dSource.TabIndex = 4;
			// 
			// dTarget
			// 
			this.dTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dTarget.Location = new System.Drawing.Point(69, 38);
			this.dTarget.Name = "dTarget";
			this.dTarget.Size = new System.Drawing.Size(357, 20);
			this.dTarget.TabIndex = 5;
			// 
			// dFormat
			// 
			this.dFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dFormat.Location = new System.Drawing.Point(69, 64);
			this.dFormat.Name = "dFormat";
			this.dFormat.Size = new System.Drawing.Size(357, 20);
			this.dFormat.TabIndex = 6;
			this.dFormat.Text = "png";
			// 
			// dBrowseSource
			// 
			this.dBrowseSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dBrowseSource.Location = new System.Drawing.Point(432, 10);
			this.dBrowseSource.Name = "dBrowseSource";
			this.dBrowseSource.Size = new System.Drawing.Size(31, 23);
			this.dBrowseSource.TabIndex = 8;
			this.dBrowseSource.Text = "...";
			this.dBrowseSource.UseVisualStyleBackColor = true;
			this.dBrowseSource.Click += new System.EventHandler(this.dBrowseSource_Click);
			// 
			// dBrowseTarget
			// 
			this.dBrowseTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dBrowseTarget.Location = new System.Drawing.Point(432, 38);
			this.dBrowseTarget.Name = "dBrowseTarget";
			this.dBrowseTarget.Size = new System.Drawing.Size(31, 23);
			this.dBrowseTarget.TabIndex = 9;
			this.dBrowseTarget.Text = "...";
			this.dBrowseTarget.UseVisualStyleBackColor = true;
			this.dBrowseTarget.Click += new System.EventHandler(this.dBrowseTarget_Click);
			// 
			// dGo
			// 
			this.dGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.dGo.Location = new System.Drawing.Point(379, 292);
			this.dGo.Name = "dGo";
			this.dGo.Size = new System.Drawing.Size(47, 35);
			this.dGo.TabIndex = 10;
			this.dGo.Text = "Go";
			this.dGo.UseVisualStyleBackColor = true;
			this.dGo.Click += new System.EventHandler(this.dGo_Click);
			// 
			// ofd
			// 
			this.ofd.Filter = "Visual studio solutions (*.sln)|*.sln|All files|*.*";
			// 
			// dExcludes
			// 
			this.dExcludes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dExcludes.CheckOnClick = true;
			this.dExcludes.FormattingEnabled = true;
			this.dExcludes.Location = new System.Drawing.Point(69, 117);
			this.dExcludes.Name = "dExcludes";
			this.dExcludes.Size = new System.Drawing.Size(357, 169);
			this.dExcludes.TabIndex = 11;
			// 
			// dFillExcludes
			// 
			this.dFillExcludes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.dFillExcludes.Location = new System.Drawing.Point(69, 292);
			this.dFillExcludes.Name = "dFillExcludes";
			this.dFillExcludes.Size = new System.Drawing.Size(75, 23);
			this.dFillExcludes.TabIndex = 12;
			this.dFillExcludes.Text = "Fill";
			this.dFillExcludes.UseVisualStyleBackColor = true;
			this.dFillExcludes.Click += new System.EventHandler(this.dFillExcludes_Click);
			// 
			// dSimplifyLinks
			// 
			this.dSimplifyLinks.AutoSize = true;
			this.dSimplifyLinks.Checked = true;
			this.dSimplifyLinks.CheckState = System.Windows.Forms.CheckState.Checked;
			this.dSimplifyLinks.Location = new System.Drawing.Point(69, 92);
			this.dSimplifyLinks.Name = "dSimplifyLinks";
			this.dSimplifyLinks.Size = new System.Drawing.Size(61, 17);
			this.dSimplifyLinks.TabIndex = 13;
			this.dSimplifyLinks.Text = "Simplify";
			this.dSimplifyLinks.UseVisualStyleBackColor = true;
			// 
			// dStyle
			// 
			this.dStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dStyle.FormattingEnabled = true;
			this.dStyle.Items.AddRange(new object[] {
            "dot",
            "neato",
            "fdp",
            "sfdp",
            "twopi",
            "circo"});
			this.dStyle.Location = new System.Drawing.Point(305, 90);
			this.dStyle.Name = "dStyle";
			this.dStyle.Size = new System.Drawing.Size(121, 21);
			this.dStyle.TabIndex = 14;
			this.dStyle.Text = "dot";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(257, 93);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Layout:";
			// 
			// dOpen
			// 
			this.dOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.dOpen.Location = new System.Drawing.Point(432, 298);
			this.dOpen.Name = "dOpen";
			this.dOpen.Size = new System.Drawing.Size(27, 23);
			this.dOpen.TabIndex = 16;
			this.dOpen.Text = "O";
			this.dOpen.UseVisualStyleBackColor = true;
			this.dOpen.Click += new System.EventHandler(this.dOpen_Click);
			// 
			// dReverseArrows
			// 
			this.dReverseArrows.AutoSize = true;
			this.dReverseArrows.Location = new System.Drawing.Point(136, 92);
			this.dReverseArrows.Name = "dReverseArrows";
			this.dReverseArrows.Size = new System.Drawing.Size(162, 17);
			this.dReverseArrows.TabIndex = 17;
			this.dReverseArrows.Text = "Reverse dependency arrows";
			this.dReverseArrows.UseVisualStyleBackColor = true;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(471, 347);
			this.Controls.Add(this.dReverseArrows);
			this.Controls.Add(this.dOpen);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.dStyle);
			this.Controls.Add(this.dSimplifyLinks);
			this.Controls.Add(this.dFillExcludes);
			this.Controls.Add(this.dExcludes);
			this.Controls.Add(this.dGo);
			this.Controls.Add(this.dBrowseTarget);
			this.Controls.Add(this.dBrowseSource);
			this.Controls.Add(this.dFormat);
			this.Controls.Add(this.dTarget);
			this.Controls.Add(this.dSource);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Main";
			this.Text = "Visual Studio Solution Dependency Graphvizer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox dSource;
		private System.Windows.Forms.TextBox dTarget;
		private System.Windows.Forms.TextBox dFormat;
		private System.Windows.Forms.Button dBrowseSource;
		private System.Windows.Forms.Button dBrowseTarget;
		private System.Windows.Forms.Button dGo;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.SaveFileDialog sfd;
		private System.Windows.Forms.CheckedListBox dExcludes;
		private System.Windows.Forms.Button dFillExcludes;
		private System.Windows.Forms.CheckBox dSimplifyLinks;
		private System.Windows.Forms.ComboBox dStyle;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button dOpen;
		private System.Windows.Forms.CheckBox dReverseArrows;
	}
}

