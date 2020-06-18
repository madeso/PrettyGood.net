namespace Diagram
{
	partial class Diagram
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
			this.SuspendLayout();
			// 
			// Diagram
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.DoubleBuffered = true;
			this.Name = "Diagram";
			this.Size = new System.Drawing.Size(283, 229);
			this.MouseLeave += new System.EventHandler(this.Diagram_MouseLeave);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Diagram_MouseMove);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Diagram_KeyUp);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Diagram_MouseDown);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Diagram_MouseUp);
			this.MouseEnter += new System.EventHandler(this.Diagram_MouseEnter);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Diagram_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
