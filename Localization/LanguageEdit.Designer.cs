namespace Localization
{
	partial class LanguageEdit
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dOverview = new System.Windows.Forms.TreeView();
			this.dDefault = new System.Windows.Forms.Label();
			this.dValue = new System.Windows.Forms.TextBox();
			this.dInformation = new System.Windows.Forms.TextBox();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dOverview);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dInformation);
			this.splitContainer1.Panel2.Controls.Add(this.dValue);
			this.splitContainer1.Panel2.Controls.Add(this.dDefault);
			this.splitContainer1.Size = new System.Drawing.Size(381, 271);
			this.splitContainer1.SplitterDistance = 155;
			this.splitContainer1.TabIndex = 0;
			// 
			// dOverview
			// 
			this.dOverview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dOverview.Location = new System.Drawing.Point(0, 0);
			this.dOverview.Name = "dOverview";
			this.dOverview.Size = new System.Drawing.Size(155, 271);
			this.dOverview.TabIndex = 0;
			this.dOverview.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.dOverview_AfterSelect);
			// 
			// dDefault
			// 
			this.dDefault.AutoSize = true;
			this.dDefault.Location = new System.Drawing.Point(3, 12);
			this.dDefault.Name = "dDefault";
			this.dDefault.Size = new System.Drawing.Size(35, 13);
			this.dDefault.TabIndex = 1;
			this.dDefault.Text = "label2";
			// 
			// dValue
			// 
			this.dValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dValue.Location = new System.Drawing.Point(6, 28);
			this.dValue.Name = "dValue";
			this.dValue.Size = new System.Drawing.Size(213, 20);
			this.dValue.TabIndex = 2;
			this.dValue.TextChanged += new System.EventHandler(this.dValue_TextChanged);
			// 
			// dInformation
			// 
			this.dInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dInformation.Location = new System.Drawing.Point(6, 54);
			this.dInformation.Multiline = true;
			this.dInformation.Name = "dInformation";
			this.dInformation.ReadOnly = true;
			this.dInformation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.dInformation.Size = new System.Drawing.Size(213, 214);
			this.dInformation.TabIndex = 3;
			// 
			// LanguageEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Name = "LanguageEdit";
			this.Size = new System.Drawing.Size(381, 271);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView dOverview;
		private System.Windows.Forms.TextBox dInformation;
		private System.Windows.Forms.TextBox dValue;
		private System.Windows.Forms.Label dDefault;
	}
}
