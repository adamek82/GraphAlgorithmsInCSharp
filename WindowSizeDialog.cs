using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Graph_Algorithms
{
	/// <summary>
	/// Summary description for WindowSizeDialog.
	/// </summary>
	public class WindowSizeDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lWidth;
		private System.Windows.Forms.Label lHeight;
		private System.Windows.Forms.NumericUpDown nudWidth;
		private System.Windows.Forms.NumericUpDown nudHeight;
		private System.Windows.Forms.Button bOK;
		private System.Windows.Forms.Button bCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WindowSizeDialog(int width, int height)
		{
			InitializeComponent();
			nudWidth.Value = width;
			nudHeight.Value = height;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lWidth = new System.Windows.Forms.Label();
			this.lHeight = new System.Windows.Forms.Label();
			this.nudWidth = new System.Windows.Forms.NumericUpDown();
			this.nudHeight = new System.Windows.Forms.NumericUpDown();
			this.bOK = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
			this.SuspendLayout();
			// 
			// lWidth
			// 
			this.lWidth.Location = new System.Drawing.Point(12, 11);
			this.lWidth.Name = "lWidth";
			this.lWidth.Size = new System.Drawing.Size(40, 16);
			this.lWidth.TabIndex = 0;
			this.lWidth.Text = "Width:";
			// 
			// lHeight
			// 
			this.lHeight.Location = new System.Drawing.Point(8, 35);
			this.lHeight.Name = "lHeight";
			this.lHeight.Size = new System.Drawing.Size(40, 16);
			this.lHeight.TabIndex = 1;
			this.lHeight.Text = "Height:";
			// 
			// nudWidth
			// 
			this.nudWidth.Location = new System.Drawing.Point(56, 8);
			this.nudWidth.Maximum = new System.Decimal(new int[] {
																	 2000,
																	 0,
																	 0,
																	 0});
			this.nudWidth.Name = "nudWidth";
			this.nudWidth.TabIndex = 2;
			// 
			// nudHeight
			// 
			this.nudHeight.Location = new System.Drawing.Point(56, 32);
			this.nudHeight.Maximum = new System.Decimal(new int[] {
																	  2000,
																	  0,
																	  0,
																	  0});
			this.nudHeight.Name = "nudHeight";
			this.nudHeight.TabIndex = 3;
			// 
			// bOK
			// 
			this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bOK.Location = new System.Drawing.Point(11, 64);
			this.bOK.Name = "bOK";
			this.bOK.TabIndex = 4;
			this.bOK.Text = "OK";
			this.bOK.Click += new System.EventHandler(this.bOK_Click);
			// 
			// bCancel
			// 
			this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancel.Location = new System.Drawing.Point(99, 64);
			this.bCancel.Name = "bCancel";
			this.bCancel.TabIndex = 5;
			this.bCancel.Text = "Cancel";
			// 
			// WindowSizeDialog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(184, 94);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOK);
			this.Controls.Add(this.nudHeight);
			this.Controls.Add(this.nudWidth);
			this.Controls.Add(this.lHeight);
			this.Controls.Add(this.lWidth);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "WindowSizeDialog";
			this.Text = "Set Window Size";
			((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private int width, height;

		private void bOK_Click(object sender, System.EventArgs e)
		{
			width = (int)nudWidth.Value;
			height = (int)nudHeight.Value;
		}

		public new int Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
			}
		}

		public new int Height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
			}
		}

	}
}
