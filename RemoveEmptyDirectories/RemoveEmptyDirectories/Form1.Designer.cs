﻿namespace RemoveEmptyDirectories
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
			this.dGo = new System.Windows.Forms.Button();
			this.dOutput = new System.Windows.Forms.TextBox();
			this.dInput = new System.Windows.Forms.TextBox();
			this.dWork = new System.ComponentModel.BackgroundWorker();
			this.dShow = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// dGo
			// 
			this.dGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dGo.Location = new System.Drawing.Point(292, 11);
			this.dGo.Name = "dGo";
			this.dGo.Size = new System.Drawing.Size(75, 23);
			this.dGo.TabIndex = 0;
			this.dGo.Text = "Remove!";
			this.dGo.UseVisualStyleBackColor = true;
			this.dGo.Click += new System.EventHandler(this.dGo_Click);
			// 
			// dOutput
			// 
			this.dOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dOutput.Location = new System.Drawing.Point(12, 40);
			this.dOutput.Multiline = true;
			this.dOutput.Name = "dOutput";
			this.dOutput.ReadOnly = true;
			this.dOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.dOutput.Size = new System.Drawing.Size(425, 213);
			this.dOutput.TabIndex = 1;
			this.dOutput.WordWrap = false;
			// 
			// dInput
			// 
			this.dInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dInput.Location = new System.Drawing.Point(12, 13);
			this.dInput.Name = "dInput";
			this.dInput.Size = new System.Drawing.Size(274, 20);
			this.dInput.TabIndex = 2;
			// 
			// dWork
			// 
			this.dWork.WorkerReportsProgress = true;
			this.dWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dWork_DoWork);
			this.dWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.dWork_RunWorkerCompleted);
			this.dWork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.dWork_ProgressChanged);
			// 
			// dShow
			// 
			this.dShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dShow.Location = new System.Drawing.Point(373, 11);
			this.dShow.Name = "dShow";
			this.dShow.Size = new System.Drawing.Size(64, 23);
			this.dShow.TabIndex = 3;
			this.dShow.Text = "Show!";
			this.dShow.UseVisualStyleBackColor = true;
			this.dShow.Click += new System.EventHandler(this.dShow_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(449, 265);
			this.Controls.Add(this.dShow);
			this.Controls.Add(this.dInput);
			this.Controls.Add(this.dOutput);
			this.Controls.Add(this.dGo);
			this.Name = "Form1";
			this.Text = "Dir Operator!";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dGo;
        private System.Windows.Forms.TextBox dOutput;
        private System.Windows.Forms.TextBox dInput;
        private System.ComponentModel.BackgroundWorker dWork;
		private System.Windows.Forms.Button dShow;
    }
}

