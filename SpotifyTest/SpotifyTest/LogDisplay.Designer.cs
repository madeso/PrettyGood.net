namespace PrettyGood.SpotifyTest
{
	partial class LogDisplay
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
			this.dClose = new System.Windows.Forms.Button();
			this.dLines = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// dClose
			// 
			this.dClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.dClose.Location = new System.Drawing.Point(197, 227);
			this.dClose.Name = "dClose";
			this.dClose.Size = new System.Drawing.Size(75, 23);
			this.dClose.TabIndex = 0;
			this.dClose.Text = "Close";
			this.dClose.UseVisualStyleBackColor = true;
			this.dClose.Click += new System.EventHandler(this.dClose_Click);
			// 
			// dLines
			// 
			this.dLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dLines.Location = new System.Drawing.Point(12, 12);
			this.dLines.Multiline = true;
			this.dLines.Name = "dLines";
			this.dLines.ReadOnly = true;
			this.dLines.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.dLines.Size = new System.Drawing.Size(260, 209);
			this.dLines.TabIndex = 1;
			this.dLines.WordWrap = false;
			// 
			// LogDisplay
			// 
			this.AcceptButton = this.dClose;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.dLines);
			this.Controls.Add(this.dClose);
			this.Name = "LogDisplay";
			this.Text = "LogDisplay";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button dClose;
		private System.Windows.Forms.TextBox dLines;
	}
}