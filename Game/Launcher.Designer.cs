namespace Game
{
    partial class Launcher
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
            this.dVideoModes = new System.Windows.Forms.ComboBox();
            this.dOk = new System.Windows.Forms.Button();
            this.dCancel = new System.Windows.Forms.Button();
            this.dFullscreen = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dVideoModes
            // 
            this.dVideoModes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dVideoModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dVideoModes.FormattingEnabled = true;
            this.dVideoModes.Location = new System.Drawing.Point(12, 12);
            this.dVideoModes.Name = "dVideoModes";
            this.dVideoModes.Size = new System.Drawing.Size(268, 21);
            this.dVideoModes.TabIndex = 0;
            // 
            // dOk
            // 
            this.dOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dOk.Location = new System.Drawing.Point(124, 68);
            this.dOk.Name = "dOk";
            this.dOk.Size = new System.Drawing.Size(75, 23);
            this.dOk.TabIndex = 1;
            this.dOk.Text = "OK";
            this.dOk.UseVisualStyleBackColor = true;
            this.dOk.Click += new System.EventHandler(this.dOk_Click);
            // 
            // dCancel
            // 
            this.dCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dCancel.Location = new System.Drawing.Point(205, 68);
            this.dCancel.Name = "dCancel";
            this.dCancel.Size = new System.Drawing.Size(75, 23);
            this.dCancel.TabIndex = 2;
            this.dCancel.Text = "Cancel";
            this.dCancel.UseVisualStyleBackColor = true;
            this.dCancel.Click += new System.EventHandler(this.dCancel_Click);
            // 
            // dFullscreen
            // 
            this.dFullscreen.AutoSize = true;
            this.dFullscreen.Location = new System.Drawing.Point(12, 39);
            this.dFullscreen.Name = "dFullscreen";
            this.dFullscreen.Size = new System.Drawing.Size(109, 17);
            this.dFullscreen.TabIndex = 3;
            this.dFullscreen.Text = "Fullscreen mode?";
            this.dFullscreen.UseVisualStyleBackColor = true;
            // 
            // Launcher
            // 
            this.AcceptButton = this.dOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.dCancel;
            this.ClientSize = new System.Drawing.Size(292, 104);
            this.Controls.Add(this.dFullscreen);
            this.Controls.Add(this.dCancel);
            this.Controls.Add(this.dOk);
            this.Controls.Add(this.dVideoModes);
            this.Name = "Launcher";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox dVideoModes;
        private System.Windows.Forms.Button dOk;
        private System.Windows.Forms.Button dCancel;
        private System.Windows.Forms.CheckBox dFullscreen;
    }
}

