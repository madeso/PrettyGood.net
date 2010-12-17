namespace HeaderParser
{
	partial class Form1
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
			this.dBrowseInput = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dInsertMissingHeaders = new System.Windows.Forms.CheckBox();
			this.dGo = new System.Windows.Forms.Button();
			this.dInput = new System.Windows.Forms.TextBox();
			this.dInclude = new System.Windows.Forms.TextBox();
			this.dLayout = new System.Windows.Forms.ComboBox();
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.label4 = new System.Windows.Forms.Label();
			this.dIgnoreFolders = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// dBrowseInput
			// 
			this.dBrowseInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dBrowseInput.Location = new System.Drawing.Point(423, 12);
			this.dBrowseInput.Name = "dBrowseInput";
			this.dBrowseInput.Size = new System.Drawing.Size(35, 23);
			this.dBrowseInput.TabIndex = 0;
			this.dBrowseInput.Text = "...";
			this.dBrowseInput.UseVisualStyleBackColor = true;
			this.dBrowseInput.Click += new System.EventHandler(this.dBrowseInput_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Input:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Layout:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Include folders:";
			// 
			// dInsertMissingHeaders
			// 
			this.dInsertMissingHeaders.AutoSize = true;
			this.dInsertMissingHeaders.Location = new System.Drawing.Point(97, 120);
			this.dInsertMissingHeaders.Name = "dInsertMissingHeaders";
			this.dInsertMissingHeaders.Size = new System.Drawing.Size(130, 17);
			this.dInsertMissingHeaders.TabIndex = 4;
			this.dInsertMissingHeaders.Text = "Insert missing headers";
			this.dInsertMissingHeaders.UseVisualStyleBackColor = true;
			// 
			// dGo
			// 
			this.dGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dGo.Location = new System.Drawing.Point(405, 120);
			this.dGo.Name = "dGo";
			this.dGo.Size = new System.Drawing.Size(53, 40);
			this.dGo.TabIndex = 5;
			this.dGo.Text = "Go!";
			this.dGo.UseVisualStyleBackColor = true;
			this.dGo.Click += new System.EventHandler(this.dGo_Click);
			// 
			// dInput
			// 
			this.dInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dInput.Location = new System.Drawing.Point(97, 12);
			this.dInput.Name = "dInput";
			this.dInput.Size = new System.Drawing.Size(320, 20);
			this.dInput.TabIndex = 6;
			// 
			// dInclude
			// 
			this.dInclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dInclude.Location = new System.Drawing.Point(97, 68);
			this.dInclude.Name = "dInclude";
			this.dInclude.Size = new System.Drawing.Size(361, 20);
			this.dInclude.TabIndex = 7;
			// 
			// dLayout
			// 
			this.dLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dLayout.FormattingEnabled = true;
			this.dLayout.Items.AddRange(new object[] {
            "dot",
            "neato",
            "fdp",
            "sfdp",
            "twopi",
            "circo"});
			this.dLayout.Location = new System.Drawing.Point(97, 41);
			this.dLayout.Name = "dLayout";
			this.dLayout.Size = new System.Drawing.Size(361, 21);
			this.dLayout.TabIndex = 8;
			this.dLayout.Text = "dot";
			// 
			// ofd
			// 
			this.ofd.Filter = "Source files|*.cpp;*.c|Header files|*.h;*.hpp|All files|*.*";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 97);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Ignore folders:";
			// 
			// dIgnoreFolders
			// 
			this.dIgnoreFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dIgnoreFolders.Location = new System.Drawing.Point(97, 94);
			this.dIgnoreFolders.Name = "dIgnoreFolders";
			this.dIgnoreFolders.Size = new System.Drawing.Size(361, 20);
			this.dIgnoreFolders.TabIndex = 10;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(470, 185);
			this.Controls.Add(this.dIgnoreFolders);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dLayout);
			this.Controls.Add(this.dInclude);
			this.Controls.Add(this.dInput);
			this.Controls.Add(this.dGo);
			this.Controls.Add(this.dInsertMissingHeaders);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dBrowseInput);
			this.Name = "Form1";
			this.Text = "Header Dependency Parser";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button dBrowseInput;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox dInsertMissingHeaders;
		private System.Windows.Forms.Button dGo;
		private System.Windows.Forms.TextBox dInput;
		private System.Windows.Forms.TextBox dInclude;
		private System.Windows.Forms.ComboBox dLayout;
		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox dIgnoreFolders;
	}
}

