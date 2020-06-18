namespace TextLines
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
            this.dUnique.Location = new System.Drawing.Point(24, 23);
            this.dUnique.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dUnique.Name = "dUnique";
            this.dUnique.Size = new System.Drawing.Size(150, 44);
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
            this.dInput.Location = new System.Drawing.Point(24, 79);
            this.dInput.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dInput.Multiline = true;
            this.dInput.Name = "dInput";
            this.dInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.dInput.Size = new System.Drawing.Size(1470, 983);
            this.dInput.TabIndex = 1;
            this.dInput.WordWrap = false;
            // 
            // dTrim
            // 
            this.dTrim.Location = new System.Drawing.Point(186, 23);
            this.dTrim.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dTrim.Name = "dTrim";
            this.dTrim.Size = new System.Drawing.Size(150, 44);
            this.dTrim.TabIndex = 2;
            this.dTrim.Text = "Trim";
            this.dTrim.UseVisualStyleBackColor = true;
            this.dTrim.Click += new System.EventHandler(this.dTrim_Click);
            // 
            // dRemoveEmpty
            // 
            this.dRemoveEmpty.Location = new System.Drawing.Point(348, 23);
            this.dRemoveEmpty.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dRemoveEmpty.Name = "dRemoveEmpty";
            this.dRemoveEmpty.Size = new System.Drawing.Size(212, 44);
            this.dRemoveEmpty.TabIndex = 3;
            this.dRemoveEmpty.Text = "Remove Empty";
            this.dRemoveEmpty.UseVisualStyleBackColor = true;
            this.dRemoveEmpty.Click += new System.EventHandler(this.dRemoveEmpty_Click);
            // 
            // dSort
            // 
            this.dSort.Location = new System.Drawing.Point(572, 23);
            this.dSort.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dSort.Name = "dSort";
            this.dSort.Size = new System.Drawing.Size(150, 44);
            this.dSort.TabIndex = 4;
            this.dSort.Text = "Sort";
            this.dSort.UseVisualStyleBackColor = true;
            this.dSort.Click += new System.EventHandler(this.dSort_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1522, 1088);
            this.Controls.Add(this.dSort);
            this.Controls.Add(this.dRemoveEmpty);
            this.Controls.Add(this.dTrim);
            this.Controls.Add(this.dInput);
            this.Controls.Add(this.dUnique);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Main";
            this.Text = "TextLines";
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

