using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Graph_Algorithms
{
	/// <summary>
	/// Summary description for EditCost.
	/// </summary>
	public class EditCost : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox tbCost;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bOK;
		private System.Windows.Forms.Button bCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditCost()
		{
			InitializeComponent();
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
			this.tbCost = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bOK = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbCost
			// 
			this.tbCost.Location = new System.Drawing.Point(46, 13);
			this.tbCost.Name = "tbCost";
			this.tbCost.TabIndex = 0;
			this.tbCost.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Cost:";
			// 
			// bOK
			// 
			this.bOK.Location = new System.Drawing.Point(27, 56);
			this.bOK.Name = "bOK";
			this.bOK.TabIndex = 2;
			this.bOK.Text = "OK";
			this.bOK.Click += new System.EventHandler(this.bOK_Click);
			// 
			// bCancel
			// 
			this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancel.Location = new System.Drawing.Point(123, 56);
			this.bCancel.Name = "bCancel";
			this.bCancel.TabIndex = 3;
			this.bCancel.Text = "Cancel";
			// 
			// EditCost
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(224, 94);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOK);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbCost);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "EditCost";
			this.Text = "Edit Cost";
			this.ResumeLayout(false);

		}
		#endregion

		int cost;

		private void bOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				cost = Int32.Parse(tbCost.Text);
				Close();
			}
			catch (Exception)
			{
				MessageBox.Show("Invalid cost!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	
		public int Cost
		{
			get
			{
				return cost;
			}
			set
			{
				cost = value;
				this.tbCost.Text = cost.ToString();
			}
		}
	}
}
