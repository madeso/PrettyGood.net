namespace PrettyGood.SpotifyTest
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
			this.dOutput = new System.Windows.Forms.TextBox();
			this.dAbort = new System.Windows.Forms.Button();
			this.dProgress = new System.Windows.Forms.ProgressBar();
			this.dWorker = new System.ComponentModel.BackgroundWorker();
			this.dStart = new System.Windows.Forms.Button();
			this.dSaveXml = new System.Windows.Forms.Button();
			this.dSavePlaylist = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.sfdXml = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// dOutput
			// 
			this.dOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dOutput.Location = new System.Drawing.Point(12, 54);
			this.dOutput.Multiline = true;
			this.dOutput.Name = "dOutput";
			this.dOutput.ReadOnly = true;
			this.dOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.dOutput.Size = new System.Drawing.Size(638, 434);
			this.dOutput.TabIndex = 1;
			this.dOutput.WordWrap = false;
			// 
			// dAbort
			// 
			this.dAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dAbort.Location = new System.Drawing.Point(597, 25);
			this.dAbort.Name = "dAbort";
			this.dAbort.Size = new System.Drawing.Size(53, 23);
			this.dAbort.TabIndex = 2;
			this.dAbort.Text = "Stop";
			this.dAbort.UseVisualStyleBackColor = true;
			this.dAbort.Click += new System.EventHandler(this.dAbort_Click);
			// 
			// dProgress
			// 
			this.dProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dProgress.Location = new System.Drawing.Point(77, 25);
			this.dProgress.Name = "dProgress";
			this.dProgress.Size = new System.Drawing.Size(512, 23);
			this.dProgress.TabIndex = 3;
			// 
			// dWorker
			// 
			this.dWorker.WorkerReportsProgress = true;
			this.dWorker.WorkerSupportsCancellation = true;
			this.dWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dWorker_DoWork);
			this.dWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.dWorker_RunWorkerCompleted);
			this.dWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.dWorker_ProgressChanged);
			// 
			// dStart
			// 
			this.dStart.Location = new System.Drawing.Point(12, 25);
			this.dStart.Name = "dStart";
			this.dStart.Size = new System.Drawing.Size(59, 23);
			this.dStart.TabIndex = 4;
			this.dStart.Text = "Start";
			this.dStart.UseVisualStyleBackColor = true;
			this.dStart.Click += new System.EventHandler(this.dStart_Click);
			// 
			// dSaveXml
			// 
			this.dSaveXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.dSaveXml.Location = new System.Drawing.Point(12, 494);
			this.dSaveXml.Name = "dSaveXml";
			this.dSaveXml.Size = new System.Drawing.Size(75, 23);
			this.dSaveXml.TabIndex = 5;
			this.dSaveXml.Text = "Save XML...";
			this.dSaveXml.UseVisualStyleBackColor = true;
			this.dSaveXml.Click += new System.EventHandler(this.dSaveXml_Click);
			// 
			// dSavePlaylist
			// 
			this.dSavePlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.dSavePlaylist.Location = new System.Drawing.Point(93, 494);
			this.dSavePlaylist.Name = "dSavePlaylist";
			this.dSavePlaylist.Size = new System.Drawing.Size(95, 23);
			this.dSavePlaylist.TabIndex = 6;
			this.dSavePlaylist.Text = "Save playlist...";
			this.dSavePlaylist.UseVisualStyleBackColor = true;
			this.dSavePlaylist.Click += new System.EventHandler(this.dSavePlaylist_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(451, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Select one or more tracks in spotify and copy Spotify URI, then hit start and let" +
				" me do the work";
			// 
			// sfdXml
			// 
			this.sfdXml.DefaultExt = "xml";
			this.sfdXml.Filter = "XML files(*.xml)|*.xml|All files (*.*)|*.*";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(662, 529);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dSavePlaylist);
			this.Controls.Add(this.dSaveXml);
			this.Controls.Add(this.dStart);
			this.Controls.Add(this.dProgress);
			this.Controls.Add(this.dAbort);
			this.Controls.Add(this.dOutput);
			this.Name = "MainWindow";
			this.Text = "SpotifyGetter";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox dOutput;
		private System.Windows.Forms.Button dAbort;
		private System.Windows.Forms.ProgressBar dProgress;
		private System.ComponentModel.BackgroundWorker dWorker;
		private System.Windows.Forms.Button dStart;
		private System.Windows.Forms.Button dSaveXml;
		private System.Windows.Forms.Button dSavePlaylist;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.SaveFileDialog sfdXml;
	}
}

