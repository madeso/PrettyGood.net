﻿namespace TextLines
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
			this.dUnique = new System.Windows.Forms.Button();
			this.dInput = new System.Windows.Forms.TextBox();
			this.dTrim = new System.Windows.Forms.Button();
			this.dRemoveEmpty = new System.Windows.Forms.Button();
			this.dSort = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// dUnique
			// 
			this.dUnique.Location = new System.Drawing.Point(12, 12);
			this.dUnique.Name = "dUnique";
			this.dUnique.Size = new System.Drawing.Size(75, 23);
			this.dUnique.TabIndex = 0;
			this.dUnique.Text = "Unique";
			this.dUnique.UseVisualStyleBackColor = true;
			this.dUnique.Click += new System.EventHandler(this.dUnique_Click);
			// 
			// dInput
			// 
			this.dInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dInput.Location = new System.Drawing.Point(12, 41);
			this.dInput.Multiline = true;
			this.dInput.Name = "dInput";
			this.dInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.dInput.Size = new System.Drawing.Size(737, 513);
			this.dInput.TabIndex = 1;
			this.dInput.WordWrap = false;
			// 
			// dTrim
			// 
			this.dTrim.Location = new System.Drawing.Point(93, 12);
			this.dTrim.Name = "dTrim";
			this.dTrim.Size = new System.Drawing.Size(75, 23);
			this.dTrim.TabIndex = 2;
			this.dTrim.Text = "Trim";
			this.dTrim.UseVisualStyleBackColor = true;
			this.dTrim.Click += new System.EventHandler(this.dTrim_Click);
			// 
			// dRemoveEmpty
			// 
			this.dRemoveEmpty.Location = new System.Drawing.Point(174, 12);
			this.dRemoveEmpty.Name = "dRemoveEmpty";
			this.dRemoveEmpty.Size = new System.Drawing.Size(106, 23);
			this.dRemoveEmpty.TabIndex = 3;
			this.dRemoveEmpty.Text = "Remove Empty";
			this.dRemoveEmpty.UseVisualStyleBackColor = true;
			this.dRemoveEmpty.Click += new System.EventHandler(this.dRemoveEmpty_Click);
			// 
			// dSort
			// 
			this.dSort.Location = new System.Drawing.Point(286, 12);
			this.dSort.Name = "dSort";
			this.dSort.Size = new System.Drawing.Size(75, 23);
			this.dSort.TabIndex = 4;
			this.dSort.Text = "Sort";
			this.dSort.UseVisualStyleBackColor = true;
			this.dSort.Click += new System.EventHandler(this.dSort_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(761, 566);
			this.Controls.Add(this.dSort);
			this.Controls.Add(this.dRemoveEmpty);
			this.Controls.Add(this.dTrim);
			this.Controls.Add(this.dInput);
			this.Controls.Add(this.dUnique);
			this.Name = "Main";
			this.Text = "Main";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button dUnique;
		private System.Windows.Forms.TextBox dInput;
		private System.Windows.Forms.Button dTrim;
		private System.Windows.Forms.Button dRemoveEmpty;
		private System.Windows.Forms.Button dSort;
	}
}

