using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Graph_Algorithms
{
	/// <summary>
	/// Summary description for TSPForm.
	/// </summary>
	public class TSPForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel outerPanel;
		public MyPanel panelGraph;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Graph graph;
		private ArrayList TSPlinks;

		public TSPForm()
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
			this.outerPanel = new System.Windows.Forms.Panel();
			this.panelGraph = new Graph_Algorithms.MyPanel();
			this.outerPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// outerPanel
			// 
			this.outerPanel.AutoScroll = true;
			this.outerPanel.BackColor = System.Drawing.SystemColors.Window;
			this.outerPanel.Controls.Add(this.panelGraph);
			this.outerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outerPanel.Location = new System.Drawing.Point(0, 0);
			this.outerPanel.Name = "outerPanel";
			this.outerPanel.Size = new System.Drawing.Size(528, 398);
			this.outerPanel.TabIndex = 0;
			this.outerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.outerPanel_Paint);
			// 
			// panelGraph
			// 
			this.panelGraph.Location = new System.Drawing.Point(0, 0);
			this.panelGraph.Name = "panelGraph";
			this.panelGraph.Size = new System.Drawing.Size(520, 392);
			this.panelGraph.TabIndex = 0;
			this.panelGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGraph_Paint);
			// 
			// TSPForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(528, 398);
			this.Controls.Add(this.outerPanel);
			this.Name = "TSPForm";
			this.Text = "Travelling Salesman";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.TSPForm_Paint);
			this.outerPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		// draw the graph
		private void DrawGraph(Graph gph, Graphics g)
		{
			int i;
			Node node;
			for (i=0; i<gph.Nodes.Count; i++)
			{
				node = gph.GetNode(i);
				g.DrawEllipse(Pens.Black, node.X-gph.NodeSize, node.Y-gph.NodeSize, 2*gph.NodeSize, 2*gph.NodeSize);
				Rectangle r = new Rectangle(node.X-gph.NodeSize, node.Y-gph.NodeSize, 2*gph.NodeSize, 2*gph.NodeSize);
				StringFormat fmt = new StringFormat();
				fmt.Alignment = StringAlignment.Center;
				fmt.LineAlignment = StringAlignment.Center;
				g.DrawString(node.Name, this.Font, Brushes.Black, r, fmt);
			}
			DrawLinks(gph, g);
		}

		private void DrawLinks(Graph g, Graphics grfx)
		{
			foreach (Link l in TSPlinks)
				DrawLink(g, grfx, l.SrcNode.X, l.SrcNode.Y, l.DestNode.X, l.DestNode.Y, l.Weight, true);
			foreach (Node n in g.Nodes)
				foreach (Link l in n.Links)
					DrawLink(g, grfx, n.X, n.Y, l.DestNode.X, l.DestNode.Y, l.Weight, false);
		}

		private void DrawLink(Graph g, Graphics grfx, int begX, int begY, int endX, int endY, int cost, bool highlighted)
		{
			// quite tough transformations, aren't they?
			float length, midX, midY, angle, kX;
			length = (float)Math.Sqrt((endX - begX)*(endX - begX) + (endY - begY)*(endY - begY));
			midX = (begX + endX) / 2.0f;
			midY = (begY + endY) / 2.0f;
			Matrix matrix = new Matrix();
			angle = 180.0f*(float)Math.Atan2(endY-begY, endX-begX)/(float)Math.PI;
			matrix.Translate(-midX, -midY, MatrixOrder.Append);
			matrix.Rotate(angle, MatrixOrder.Append);
			matrix.Translate(midX, midY, MatrixOrder.Append);
			grfx.Transform = matrix;
			kX = midX+length/2-g.NodeSize;
			if (highlighted == true)
			{
				Pen pen = new Pen(Color.Orange, 4.0f);
				grfx.DrawLine(pen, midX-length/2+g.NodeSize, midY, kX, midY);
			}
			// link
			if (highlighted == false)
				grfx.DrawLine(Pens.Black, midX-length/2+g.NodeSize, midY, kX, midY);
			// weight /cost/
			RectangleF r = new RectangleF(midX-40, midY-20, 80, 20);
			StringFormat fmt = new StringFormat();
			fmt.Alignment = StringAlignment.Center;
			fmt.LineAlignment = StringAlignment.Center;
			grfx.Transform = new Matrix();	// back to standard transformation
			grfx.DrawString(cost.ToString(), this.Font, Brushes.Black, r, fmt); 
		}

		private void panelGraph_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			DrawGraph(graph, e.Graphics);
		}

		private void outerPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			panelGraph.Refresh();
		}

		private void TSPForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			outerPanel.Refresh();
		}

		public Graph Graph
		{
			get
			{
				return graph;
			}
			set
			{
				graph = value;
			}
		}

		public ArrayList TSPLinks
		{
			get
			{
				return TSPlinks;
			}
			set
			{
				TSPlinks = value;
			}
		}
	}
}
