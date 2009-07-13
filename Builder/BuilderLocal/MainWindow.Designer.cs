namespace BuilderLocal
{
	partial class MainWindow
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
			this.dOpen = new System.Windows.Forms.Button();
			this.dVariables = new System.Windows.Forms.Button();
			this.dActions = new BrightIdeasSoftware.ObjectListView();
			this.olvcType = new BrightIdeasSoftware.OLVColumn();
			this.olvcContext = new BrightIdeasSoftware.OLVColumn();
			this.olvcDescription = new BrightIdeasSoftware.OLVColumn();
			this.dOpenProject = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.dActions)).BeginInit();
			this.SuspendLayout();
			// 
			// dOpen
			// 
			this.dOpen.Location = new System.Drawing.Point(12, 10);
			this.dOpen.Name = "dOpen";
			this.dOpen.Size = new System.Drawing.Size(75, 23);
			this.dOpen.TabIndex = 2;
			this.dOpen.Text = "Open...";
			this.dOpen.UseVisualStyleBackColor = true;
			this.dOpen.Click += new System.EventHandler(this.dOpen_Click);
			// 
			// dVariables
			// 
			this.dVariables.Location = new System.Drawing.Point(93, 10);
			this.dVariables.Name = "dVariables";
			this.dVariables.Size = new System.Drawing.Size(75, 23);
			this.dVariables.TabIndex = 3;
			this.dVariables.Text = "Variables...";
			this.dVariables.UseVisualStyleBackColor = true;
			this.dVariables.Click += new System.EventHandler(this.dVariables_Click);
			// 
			// dActions
			// 
			this.dActions.AllColumns.Add(this.olvcType);
			this.dActions.AllColumns.Add(this.olvcContext);
			this.dActions.AllColumns.Add(this.olvcDescription);
			this.dActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvcType,
            this.olvcContext,
            this.olvcDescription});
			this.dActions.FullRowSelect = true;
			this.dActions.Location = new System.Drawing.Point(12, 39);
			this.dActions.Name = "dActions";
			this.dActions.Size = new System.Drawing.Size(342, 215);
			this.dActions.TabIndex = 4;
			this.dActions.UseCompatibleStateImageBehavior = false;
			this.dActions.View = System.Windows.Forms.View.Details;
			this.dActions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dActions_MouseDoubleClick);
			// 
			// olvcType
			// 
			this.olvcType.AspectName = "type";
			this.olvcType.Text = "Type";
			this.olvcType.Width = 79;
			// 
			// olvcContext
			// 
			this.olvcContext.AspectName = "context";
			this.olvcContext.Text = "Context";
			this.olvcContext.Width = 77;
			// 
			// olvcDescription
			// 
			this.olvcDescription.AspectName = "description";
			this.olvcDescription.Text = "Description";
			this.olvcDescription.UseInitialLetterForGroup = true;
			this.olvcDescription.Width = 180;
			// 
			// dOpenProject
			// 
			this.dOpenProject.Filter = "Project files (*.proj)|*.proj|All files (*.*)|*.*";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(366, 266);
			this.Controls.Add(this.dActions);
			this.Controls.Add(this.dVariables);
			this.Controls.Add(this.dOpen);
			this.Name = "MainWindow";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dActions)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button dOpen;
		private System.Windows.Forms.Button dVariables;
		private BrightIdeasSoftware.ObjectListView dActions;
		private BrightIdeasSoftware.OLVColumn olvcType;
		private BrightIdeasSoftware.OLVColumn olvcContext;
		private BrightIdeasSoftware.OLVColumn olvcDescription;
		private System.Windows.Forms.OpenFileDialog dOpenProject;
	}
}

