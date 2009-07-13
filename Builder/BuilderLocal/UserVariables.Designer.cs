namespace BuilderLocal
{
	partial class UserVariables
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
			this.dVariables = new BrightIdeasSoftware.FastObjectListView();
			this.dCancel = new System.Windows.Forms.Button();
			this.dOK = new System.Windows.Forms.Button();
			this.olvcDescription = new BrightIdeasSoftware.OLVColumn();
			this.olvcValue = new BrightIdeasSoftware.OLVColumn();
			((System.ComponentModel.ISupportInitialize)(this.dVariables)).BeginInit();
			this.SuspendLayout();
			// 
			// dVariables
			// 
			this.dVariables.AllColumns.Add(this.olvcDescription);
			this.dVariables.AllColumns.Add(this.olvcValue);
			this.dVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dVariables.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
			this.dVariables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcDescription,
            this.olvcValue});
			this.dVariables.FullRowSelect = true;
			this.dVariables.Location = new System.Drawing.Point(12, 12);
			this.dVariables.Name = "dVariables";
			this.dVariables.ShowGroups = false;
			this.dVariables.Size = new System.Drawing.Size(569, 245);
			this.dVariables.TabIndex = 0;
			this.dVariables.TintSortColumn = true;
			this.dVariables.UseAlternatingBackColors = true;
			this.dVariables.UseCompatibleStateImageBehavior = false;
			this.dVariables.View = System.Windows.Forms.View.Details;
			this.dVariables.VirtualMode = true;
			// 
			// dCancel
			// 
			this.dCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.dCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.dCancel.Location = new System.Drawing.Point(515, 263);
			this.dCancel.Name = "dCancel";
			this.dCancel.Size = new System.Drawing.Size(66, 23);
			this.dCancel.TabIndex = 1;
			this.dCancel.Text = "Cancel";
			this.dCancel.UseVisualStyleBackColor = true;
			this.dCancel.Click += new System.EventHandler(this.dCancel_Click);
			// 
			// dOK
			// 
			this.dOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.dOK.Location = new System.Drawing.Point(434, 263);
			this.dOK.Name = "dOK";
			this.dOK.Size = new System.Drawing.Size(75, 23);
			this.dOK.TabIndex = 2;
			this.dOK.Text = "OK";
			this.dOK.UseVisualStyleBackColor = true;
			this.dOK.Click += new System.EventHandler(this.dOK_Click);
			// 
			// olvcDescription
			// 
			this.olvcDescription.AspectName = "Description";
			this.olvcDescription.Text = "Description";
			this.olvcDescription.Width = 91;
			// 
			// olvcValue
			// 
			this.olvcValue.AspectName = "Value";
			this.olvcValue.Text = "Value";
			// 
			// UserVariables
			// 
			this.AcceptButton = this.dOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.dCancel;
			this.ClientSize = new System.Drawing.Size(593, 298);
			this.Controls.Add(this.dOK);
			this.Controls.Add(this.dCancel);
			this.Controls.Add(this.dVariables);
			this.Name = "UserVariables";
			this.Text = "UserVariables";
			((System.ComponentModel.ISupportInitialize)(this.dVariables)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private BrightIdeasSoftware.FastObjectListView dVariables;
		private System.Windows.Forms.Button dCancel;
		private System.Windows.Forms.Button dOK;
		private BrightIdeasSoftware.OLVColumn olvcDescription;
		private BrightIdeasSoftware.OLVColumn olvcValue;
	}
}