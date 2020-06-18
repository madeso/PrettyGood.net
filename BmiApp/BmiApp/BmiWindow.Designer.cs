namespace Bmi
{
    partial class BmiWindow
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
            this.dLength = new System.Windows.Forms.TextBox();
            this.dWeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dMale = new System.Windows.Forms.CheckBox();
            this.dDescription = new System.Windows.Forms.TextBox();
            this.dAge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dActivity = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.dActivity)).BeginInit();
            this.SuspendLayout();
            // 
            // dLength
            // 
            this.dLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dLength.Location = new System.Drawing.Point(81, 35);
            this.dLength.Name = "dLength";
            this.dLength.Size = new System.Drawing.Size(283, 20);
            this.dLength.TabIndex = 0;
            this.dLength.TextChanged += new System.EventHandler(this.dLength_TextChanged);
            // 
            // dWeight
            // 
            this.dWeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dWeight.Location = new System.Drawing.Point(81, 61);
            this.dWeight.Name = "dWeight";
            this.dWeight.Size = new System.Drawing.Size(283, 20);
            this.dWeight.TabIndex = 1;
            this.dWeight.TextChanged += new System.EventHandler(this.dWeight_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Längd (cm):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vikt (kg):";
            // 
            // dMale
            // 
            this.dMale.AutoSize = true;
            this.dMale.Checked = true;
            this.dMale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dMale.Location = new System.Drawing.Point(12, 12);
            this.dMale.Name = "dMale";
            this.dMale.Size = new System.Drawing.Size(47, 17);
            this.dMale.TabIndex = 5;
            this.dMale.Text = "Man";
            this.dMale.UseVisualStyleBackColor = true;
            this.dMale.CheckedChanged += new System.EventHandler(this.dMale_CheckedChanged);
            // 
            // dDescription
            // 
            this.dDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dDescription.Location = new System.Drawing.Point(12, 168);
            this.dDescription.Multiline = true;
            this.dDescription.Name = "dDescription";
            this.dDescription.ReadOnly = true;
            this.dDescription.Size = new System.Drawing.Size(352, 227);
            this.dDescription.TabIndex = 6;
            // 
            // dAge
            // 
            this.dAge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dAge.Location = new System.Drawing.Point(81, 87);
            this.dAge.Name = "dAge";
            this.dAge.Size = new System.Drawing.Size(283, 20);
            this.dAge.TabIndex = 7;
            this.dAge.TextChanged += new System.EventHandler(this.dAge_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ålder:";
            // 
            // dActivity
            // 
            this.dActivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dActivity.LargeChange = 20;
            this.dActivity.Location = new System.Drawing.Point(15, 113);
            this.dActivity.Maximum = 200;
            this.dActivity.Minimum = 100;
            this.dActivity.Name = "dActivity";
            this.dActivity.Size = new System.Drawing.Size(349, 45);
            this.dActivity.SmallChange = 5;
            this.dActivity.TabIndex = 9;
            this.dActivity.TickFrequency = 10;
            this.dActivity.Value = 120;
            this.dActivity.ValueChanged += new System.EventHandler(this.dActivity_ValueChanged);
            // 
            // BmiWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 407);
            this.Controls.Add(this.dActivity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dAge);
            this.Controls.Add(this.dDescription);
            this.Controls.Add(this.dMale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dWeight);
            this.Controls.Add(this.dLength);
            this.Name = "BmiWindow";
            this.Text = "BMI";
            ((System.ComponentModel.ISupportInitialize)(this.dActivity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dLength;
        private System.Windows.Forms.TextBox dWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox dMale;
        private System.Windows.Forms.TextBox dDescription;
        private System.Windows.Forms.TextBox dAge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar dActivity;
    }
}

