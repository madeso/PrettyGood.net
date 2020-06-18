namespace PathFinder
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
			this.dInput = new System.Windows.Forms.TextBox();
			this.dView = new BrightIdeasSoftware.FastObjectListView();
			this.olvColumn1 = new BrightIdeasSoftware.OLVColumn();
			((System.ComponentModel.ISupportInitialize)(this.dView)).BeginInit();
			this.SuspendLayout();
			// 
			// dInput
			// 
			this.dInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dInput.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.dInput.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.dInput.Location = new System.Drawing.Point(12, 253);
			this.dInput.Name = "dInput";
			this.dInput.Size = new System.Drawing.Size(419, 20);
			this.dInput.TabIndex = 1;
			this.dInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dInput_KeyUp);
			// 
			// dView
			// 
			this.dView.AllColumns.Add(this.olvColumn1);
			this.dView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
			this.dView.EmptyListMsg = "nothing to display";
			this.dView.Location = new System.Drawing.Point(12, 12);
			this.dView.Name = "dView";
			this.dView.ShowGroups = false;
			this.dView.Size = new System.Drawing.Size(419, 235);
			this.dView.TabIndex = 2;
			this.dView.TintSortColumn = true;
			this.dView.UseAlternatingBackColors = true;
			this.dView.UseCompatibleStateImageBehavior = false;
			this.dView.View = System.Windows.Forms.View.Details;
			this.dView.VirtualMode = true;
			// 
			// olvColumn1
			// 
			this.olvColumn1.AspectName = "Name";
			this.olvColumn1.FillsFreeSpace = true;
			this.olvColumn1.Text = "Name";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(443, 285);
			this.Controls.Add(this.dView);
			this.Controls.Add(this.dInput);
			this.Name = "Main";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox dInput;
		private BrightIdeasSoftware.FastObjectListView dView;
		private BrightIdeasSoftware.OLVColumn olvColumn1;
	}
}

