namespace WindowsFormsApplication1
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
			this.dStatus = new System.Windows.Forms.TextBox();
			this.dRun = new System.Windows.Forms.Button();
			this.dFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// dStatus
			// 
			this.dStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dStatus.Location = new System.Drawing.Point(12, 40);
			this.dStatus.Name = "dStatus";
			this.dStatus.ReadOnly = true;
			this.dStatus.Size = new System.Drawing.Size(400, 20);
			this.dStatus.TabIndex = 3;
			// 
			// dRun
			// 
			this.dRun.Location = new System.Drawing.Point(12, 12);
			this.dRun.Name = "dRun";
			this.dRun.Size = new System.Drawing.Size(75, 23);
			this.dRun.TabIndex = 0;
			this.dRun.Text = "Run...";
			this.dRun.UseVisualStyleBackColor = true;
			this.dRun.Click += new System.EventHandler(this.dRun_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(424, 71);
			this.Controls.Add(this.dStatus);
			this.Controls.Add(this.dRun);
			this.Name = "Form1";
			this.Text = "vs2010 template remover";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox dStatus;
		private System.Windows.Forms.Button dRun;
		private System.Windows.Forms.FolderBrowserDialog dFolder;
	}
}

