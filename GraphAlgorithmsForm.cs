using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Graph_Algorithms
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class GraphAlgorithmsForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuFileExit;
		private System.Windows.Forms.MenuItem menuWindow;
		private System.Windows.Forms.MenuItem menuWindowSize;
		private MyPanel panelGraph;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		Graph g = new Graph("graph1", 15);
		
		int highlightedNode = -1;
		Link highlightedLink = null;
		int firstNode=-1, secondNode=-1;
		bool dragging = false;
		int selX, selY;

		private System.Windows.Forms.ToolBarButton tbbNode;
		private System.Windows.Forms.ToolBarButton tbbLink;
		private System.Windows.Forms.ToolBar tbOperations;
		private System.Windows.Forms.ToolBarButton tbbSelect;

		private System.Windows.Forms.Panel panelOuter;
		private System.Windows.Forms.ContextMenu cmLink;
		private System.Windows.Forms.MenuItem mcChangeCost;
		private System.Windows.Forms.MenuItem mcRemoveLink;
		private System.Windows.Forms.ContextMenu cmNode;
		private System.Windows.Forms.MenuItem mcNode;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuMST;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuDirected;
		private System.Windows.Forms.MenuItem menuUndirected;

		private enum Operations
		{
			Select,
			NewNode,
			NewLink,
			ShortestPath
		};

		private enum GraphType
		{
			Directed,
			Undirected
		};

		Operations operation = Operations.Select;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuShortestPath;
		private System.Windows.Forms.MenuItem mcDeleteNode;
		private System.Windows.Forms.MenuItem menuTSP;
		GraphType graphType = GraphType.Undirected;

		public GraphAlgorithmsForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			menuMST.Enabled = true;
			PushButton(0);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.panelGraph = new Graph_Algorithms.MyPanel();
			this.cmLink = new System.Windows.Forms.ContextMenu();
			this.mcChangeCost = new System.Windows.Forms.MenuItem();
			this.mcRemoveLink = new System.Windows.Forms.MenuItem();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuFileExit = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuMST = new System.Windows.Forms.MenuItem();
			this.menuShortestPath = new System.Windows.Forms.MenuItem();
			this.menuWindow = new System.Windows.Forms.MenuItem();
			this.menuWindowSize = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuDirected = new System.Windows.Forms.MenuItem();
			this.menuUndirected = new System.Windows.Forms.MenuItem();
			this.tbOperations = new System.Windows.Forms.ToolBar();
			this.tbbSelect = new System.Windows.Forms.ToolBarButton();
			this.tbbNode = new System.Windows.Forms.ToolBarButton();
			this.tbbLink = new System.Windows.Forms.ToolBarButton();
			this.panelOuter = new System.Windows.Forms.Panel();
			this.cmNode = new System.Windows.Forms.ContextMenu();
			this.mcNode = new System.Windows.Forms.MenuItem();
			this.mcDeleteNode = new System.Windows.Forms.MenuItem();
			this.menuTSP = new System.Windows.Forms.MenuItem();
			this.panelOuter.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelGraph
			// 
			this.panelGraph.BackColor = System.Drawing.SystemColors.Window;
			this.panelGraph.Location = new System.Drawing.Point(0, 0);
			this.panelGraph.Name = "panelGraph";
			this.panelGraph.Size = new System.Drawing.Size(1000, 1000);
			this.panelGraph.TabIndex = 0;
			this.panelGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGraph_Paint);
			this.panelGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelGraph_MouseMove);
			this.panelGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelGraph_MouseDown);
			// 
			// cmLink
			// 
			this.cmLink.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.mcChangeCost,
																				   this.mcRemoveLink});
			// 
			// mcChangeCost
			// 
			this.mcChangeCost.Index = 0;
			this.mcChangeCost.Text = "Change &Cost";
			this.mcChangeCost.Click += new System.EventHandler(this.mcChangeCost_Click);
			// 
			// mcRemoveLink
			// 
			this.mcRemoveLink.Index = 1;
			this.mcRemoveLink.Text = "Remove &Link";
			this.mcRemoveLink.Click += new System.EventHandler(this.mcRemoveLink_Click);
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFile,
																					 this.menuItem1,
																					 this.menuWindow,
																					 this.menuItem2});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFileExit});
			this.menuFile.Text = "&File";
			// 
			// menuFileExit
			// 
			this.menuFileExit.Index = 0;
			this.menuFileExit.Text = "E&xit";
			this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuMST,
																					  this.menuShortestPath,
																					  this.menuTSP});
			this.menuItem1.Text = "&Algorithms";
			// 
			// menuMST
			// 
			this.menuMST.Index = 0;
			this.menuMST.Text = "Minimum Spanning &Tree";
			this.menuMST.Click += new System.EventHandler(this.menuMST_Click);
			// 
			// menuShortestPath
			// 
			this.menuShortestPath.Index = 1;
			this.menuShortestPath.Text = "Shortest &Path";
			this.menuShortestPath.Click += new System.EventHandler(this.menuShortestPath_Click);
			// 
			// menuWindow
			// 
			this.menuWindow.Index = 2;
			this.menuWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuWindowSize});
			this.menuWindow.Text = "&Window";
			// 
			// menuWindowSize
			// 
			this.menuWindowSize.Index = 0;
			this.menuWindowSize.Text = "&Size";
			this.menuWindowSize.Click += new System.EventHandler(this.menuWindowSize_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 3;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuDirected,
																					  this.menuUndirected});
			this.menuItem2.Text = "&Type";
			// 
			// menuDirected
			// 
			this.menuDirected.Index = 0;
			this.menuDirected.RadioCheck = true;
			this.menuDirected.Text = "&Directed";
			this.menuDirected.Click += new System.EventHandler(this.menuDirected_Click);
			// 
			// menuUndirected
			// 
			this.menuUndirected.Checked = true;
			this.menuUndirected.Index = 1;
			this.menuUndirected.RadioCheck = true;
			this.menuUndirected.Text = "&Undirected";
			this.menuUndirected.Click += new System.EventHandler(this.menuUndirected_Click);
			// 
			// tbOperations
			// 
			this.tbOperations.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																							this.tbbSelect,
																							this.tbbNode,
																							this.tbbLink});
			this.tbOperations.DropDownArrows = true;
			this.tbOperations.Location = new System.Drawing.Point(0, 0);
			this.tbOperations.Name = "tbOperations";
			this.tbOperations.ShowToolTips = true;
			this.tbOperations.Size = new System.Drawing.Size(492, 42);
			this.tbOperations.TabIndex = 1;
			this.tbOperations.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbOperations_ButtonClick);
			// 
			// tbbSelect
			// 
			this.tbbSelect.Text = "Select";
			this.tbbSelect.ToolTipText = "Select Node/Link";
			// 
			// tbbNode
			// 
			this.tbbNode.Text = "Node";
			this.tbbNode.ToolTipText = "Add Node";
			// 
			// tbbLink
			// 
			this.tbbLink.Text = "Link";
			this.tbbLink.ToolTipText = "Add Link";
			// 
			// panelOuter
			// 
			this.panelOuter.AutoScroll = true;
			this.panelOuter.BackColor = System.Drawing.SystemColors.Window;
			this.panelOuter.Controls.Add(this.panelGraph);
			this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelOuter.Location = new System.Drawing.Point(0, 42);
			this.panelOuter.Name = "panelOuter";
			this.panelOuter.Size = new System.Drawing.Size(492, 304);
			this.panelOuter.TabIndex = 2;
			// 
			// cmNode
			// 
			this.cmNode.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.mcNode,
																				   this.mcDeleteNode});
			// 
			// mcNode
			// 
			this.mcNode.Index = 0;
			this.mcNode.Text = "&Change Node Name";
			this.mcNode.Click += new System.EventHandler(this.mcNode_Click);
			// 
			// mcDeleteNode
			// 
			this.mcDeleteNode.Index = 1;
			this.mcDeleteNode.Text = "Remove &Node";
			this.mcDeleteNode.Click += new System.EventHandler(this.mcDeleteNode_Click);
			// 
			// menuTSP
			// 
			this.menuTSP.Index = 2;
			this.menuTSP.Text = "Travelling &Salesman";
			this.menuTSP.Click += new System.EventHandler(this.menuTSP_Click);
			// 
			// GraphAlgorithmsForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(492, 346);
			this.Controls.Add(this.panelOuter);
			this.Controls.Add(this.tbOperations);
			this.Menu = this.mainMenu;
			this.Name = "GraphAlgorithmsForm";
			this.Text = "Graph Algorithms";
			this.panelOuter.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new GraphAlgorithmsForm());
		}

		private void menuFileExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void menuWindowSize_Click(object sender, System.EventArgs e)
		{
			WindowSizeDialog wsd = new WindowSizeDialog(panelGraph.Width, panelGraph.Height);
			if (wsd.ShowDialog() == DialogResult.OK)
			{
				panelGraph.Width = wsd.Width;
				panelGraph.Height = wsd.Height;
			}
		}

		private void panelGraph_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			DrawGraph(g, e.Graphics);
		}

		private void DrawGraph(Graph gph, Graphics g)
		{
			int i;
			Node node;
			for (i=0; i<gph.Nodes.Count; i++)
			{
				node = gph.GetNode(i);
				if (i == highlightedNode)
				{
					g.FillEllipse(Brushes.Orange, node.X-gph.NodeSize, node.Y-gph.NodeSize, 2*gph.NodeSize, 2*gph.NodeSize);
					g.DrawEllipse(Pens.Black, node.X-gph.NodeSize, node.Y-gph.NodeSize, 2*gph.NodeSize, 2*gph.NodeSize);
				}
				else
					g.DrawEllipse(Pens.Black, node.X-gph.NodeSize, node.Y-gph.NodeSize, 2*gph.NodeSize, 2*gph.NodeSize);
				Rectangle r = new Rectangle(node.X-gph.NodeSize, node.Y-gph.NodeSize, 2*gph.NodeSize, 2*gph.NodeSize);
				StringFormat fmt = new StringFormat();
				fmt.Alignment = StringAlignment.Center;
				fmt.LineAlignment = StringAlignment.Center;
				g.DrawString(node.Name, this.Font, Brushes.Black, r, fmt);
			}
			DrawLinks(g);
		}

		private void panelGraph_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Graphics pg = panelGraph.CreateGraphics();
			int i, distance, j;
			bool selected = false;			// node
			bool selectedLink = false;		// link
			Node node;
			int begX, begY, endX, endY;
			int A, B, C;					// line coefficients
			int A1, B1, C1;					// first perpendicular line coeff's
			int A2, B2, C2;					// second perpendicular line coeff's
			float d;						// distance of the point from the line
			int s1, s2;						// side on which the point lies

			if (operation == Operations.Select || operation == Operations.NewLink || operation == Operations.ShortestPath)
			{
				if (dragging == false || (dragging == true && firstNode != -1))	// selecting
				{
					// iterate through nodes
					for (i=0; i<g.Nodes.Count; i++)
					{
						node = g.GetNode(i);
						distance = (int)Math.Floor(Math.Sqrt((e.X - node.X)*(e.X - node.X) + (e.Y - node.Y)*(e.Y - node.Y)));
						if (distance <= g.NodeSize)
						{
							DrawNode(node, true);	// sets highlighted node value
							selected = true;
							for (j=0; j<i; j++)
								DrawNode(g.GetNode(j), false);
							for (j=i+1; j<g.Nodes.Count; j++)
								DrawNode(g.GetNode(j), false);
							break;
						}
					}
					// iterate through links, only when there aren't any nodes selected
					if (selected == false)
					{
						foreach (Node n in g.Nodes)
						{
							begX = n.X;
							begY = n.Y;
							foreach (Link l in n.Links)
							{
								endX = l.DestNode.X;
								endY = l.DestNode.Y;
								// determine line equation crossing (begX, begY) and (endX, endY) points
								A = begY - endY;
								B = endX - begX;
								C = begX*endY - begY*endX;
								// first test - calculate the distance
								d = Math.Abs(A*e.X+B*e.Y+C) / (float)Math.Sqrt(A*A+B*B);
								if (d <= 5.0f)
								{
									// second test - calculate the perpendicular lines
									// first perpendicular line
									A1 = B;
									B1 = -A;
									C1 = -B*begX + A*begY;
									s1 = A1*e.X + B1*e.Y + C1;
									// second perpendicular line
									A2 = B;
									B2 = -A;
									C2 = -B*endX + A*endY;
									s2 = A2*e.X + B2*e.Y + C2;
									//
									if ((s1<0 && s2>0) || (s1>0 && s2<0))
									{
										selectedLink = true;
										highlightedLink = l;
										panelGraph.Refresh();
										goto end;	// not elegant but I had to...
									}
								}
							}
						}
					}
					end:
					if (selected == false)
					{
						if (this.highlightedNode != -1)
						{
							Node n = g.GetNode(this.highlightedNode);
							DrawNode(n, false);
						}
						highlightedNode = -1;
					}

					if (selectedLink == false)
					{
						if (this.highlightedLink != null)
						{
							DrawLink(pg, highlightedLink.SrcNode.X, highlightedLink.SrcNode.Y, highlightedLink.DestNode.X, highlightedLink.DestNode.Y, highlightedLink.Weight, false);
						}
						highlightedLink = null;
						panelGraph.Refresh();
					}
				}
				else if (dragging == true && operation == Operations.Select)
				{
					// move 
					if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
					{
						int diffX = e.X - this.selX;
						int diffY = e.Y - this.selY;
						node = g.GetNode(highlightedNode);
						node.X += diffX;
						node.Y += diffY;
						panelGraph.Refresh();
						selX = e.X;
						selY = e.Y;
					}
						// dragging finished
					else if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
					{
						dragging = false;
						panelGraph_MouseMove(this, e);	// refresh selections
					}
				}
				else if (dragging == true && operation == Operations.NewLink)
				{
					// ... nothing
				}
			}
		}

		public void DrawNode(Node node, bool highlighted)
		{
			Graphics pg = panelGraph.CreateGraphics();
			// draw circle representing the node
			if (highlighted == true)
			{
				pg.FillEllipse(Brushes.Orange, node.X-g.NodeSize, node.Y-g.NodeSize, 2*g.NodeSize, 2*g.NodeSize);
				highlightedNode = node.Number;
			}
			else
			{
				pg.FillEllipse(Brushes.White, node.X-g.NodeSize, node.Y-g.NodeSize, 2*g.NodeSize, 2*g.NodeSize);
			}
			pg.DrawEllipse(Pens.Black, node.X-g.NodeSize, node.Y-g.NodeSize, 2*g.NodeSize, 2*g.NodeSize);
			// draw text inside the node
			Rectangle r = new Rectangle(node.X-g.NodeSize, node.Y-g.NodeSize, 2*g.NodeSize, 2*g.NodeSize);
			StringFormat fmt = new StringFormat();
			fmt.Alignment = StringAlignment.Center;
			fmt.LineAlignment = StringAlignment.Center;
			pg.DrawString(node.Name, this.Font, Brushes.Black, r, fmt);
		}

		private void panelGraph_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (operation == Operations.NewNode)
				{
					g.AddNode(e.X, e.Y);
					panelGraph.Refresh();
				}
				else if (operation == Operations.Select)
				{
					if (highlightedNode != -1)
					{
						dragging = true;
						selX = e.X;
						selY = e.Y;
					}
				}
				else if (operation == Operations.NewLink || operation == Operations.ShortestPath)
				{
					if (highlightedNode != -1 && firstNode == -1)
					{
						dragging = true;
						selX = e.X;
						selY = e.Y;
						firstNode = highlightedNode;
						highlightedNode = -1;
					}
					if (highlightedNode != -1 && firstNode != -1)
					{
						dragging = false;
						secondNode = highlightedNode;
						highlightedNode = -1;
						// add link or display shortest path window
						switch (operation)
						{
							case Operations.NewLink:
								g.AddLink(g.GetNode(firstNode), g.GetNode(secondNode));
								if (this.graphType == GraphType.Undirected)
									g.AddLink(g.GetNode(secondNode), g.GetNode(firstNode));
								break;
							case Operations.ShortestPath:
								ShortestPath sp = new ShortestPath(g, g.GetNode(firstNode), g.GetNode(secondNode));
								ShortestPathForm spf = new ShortestPathForm();
								spf.Graph = g;
								spf.panelGraph.Size = this.panelGraph.Size;
								spf.Path = sp.Path;
								spf.Show();
								operation = Operations.Select;
								break;
						}
						firstNode = -1;
						secondNode = -1;
						highlightedNode = -1;
						panelGraph.Refresh();
						panelGraph_MouseMove(this, e);
					}
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				// context menu
				if (operation == Operations.Select && highlightedLink != null)
				{
					this.cmLink.Show(panelGraph, new Point(e.X, e.Y));
				}
				else if (operation == Operations.Select && highlightedNode != -1)
				{
					this.cmNode.Show(panelGraph, new Point(e.X, e.Y));
				}
			}
		}

		private void DrawLink(Graphics grfx, int begX, int begY, int endX, int endY, int cost, bool highlighted)
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
				if (graphType == GraphType.Directed)
				{
					grfx.DrawLine(pen, kX-10, midY-5, kX, midY);
					grfx.DrawLine(pen, kX-10, midY+5, kX, midY);
				}
			}
			// link
			grfx.DrawLine(Pens.Black, midX-length/2+g.NodeSize, midY, kX, midY);
			// arrow /direction/, if applicable
			if (graphType == GraphType.Directed)
			{
				grfx.DrawLine(Pens.Black, kX-10, midY-5, kX, midY);
				grfx.DrawLine(Pens.Black, kX-10, midY+5, kX, midY);
			}
			// weight /cost/
			RectangleF r = new RectangleF(midX-40, midY-20, 80, 20);
			StringFormat fmt = new StringFormat();
			fmt.Alignment = StringAlignment.Center;
			fmt.LineAlignment = StringAlignment.Center;
			grfx.Transform = new Matrix();	// back to standard transformation
			grfx.DrawString(cost.ToString(), this.Font, Brushes.Black, r, fmt); 
		}

		private void DrawLinks(Graphics grfx)
		{
			foreach (Node n in g.Nodes)
			{
				foreach (Link l in n.Links)
				{
					if (l != highlightedLink)
						DrawLink(grfx, n.X, n.Y, l.DestNode.X, l.DestNode.Y, l.Weight, false);
					else
					{
						DrawLink(grfx, n.X, n.Y, l.DestNode.X, l.DestNode.Y, l.Weight, true);
					}
				}
			}
		}

		private void PushButton(int index)
		{
			int i;
			for (i=0; i<index; i++)
				tbOperations.Buttons[i].Pushed = false;
			tbOperations.Buttons[i].Pushed = true;
			for (i=index+1; i<tbOperations.Buttons.Count; i++)
				tbOperations.Buttons[i].Pushed = false;
		}

		private void tbOperations_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.Text)
			{
				case "Select":
					panelGraph.Cursor = Cursors.Default;
					PushButton(0);
					operation = Operations.Select;
					break;
				case "Node":
					panelGraph.Cursor = Cursors.Cross;
					PushButton(1);
					operation = Operations.NewNode;
					break;
				case "Link":
					panelGraph.Cursor = Cursors.Cross;
					PushButton(2);
					operation = Operations.NewLink;
					break;
			}
		}

		/// <summary>
		/// changes cost of the link
		/// </summary>
		private void mcChangeCost_Click(object sender, System.EventArgs e)
		{
			EditCost ec = new EditCost();
			ec.Cost = highlightedLink.Weight;
			ec.ShowDialog();
			highlightedLink.Weight = ec.Cost;
			if (graphType == GraphType.Undirected)
			{
				Link l = highlightedLink.DestNode.FindLink(highlightedLink.SrcNode);
				l.Weight = ec.Cost;
			}
			panelGraph.Refresh();
		}

		/// <summary>
		/// removes the link from the graph 
		/// </summary>
		private void mcRemoveLink_Click(object sender, System.EventArgs e)
		{
			highlightedLink.SrcNode.RemoveLink(highlightedLink.DestNode);
			if (graphType == GraphType.Undirected)
				highlightedLink.DestNode.RemoveLink(highlightedLink.SrcNode);
			panelGraph.Refresh();
		}

		/// <summary>
		/// changes name of the node
		/// </summary>
		private void mcNode_Click(object sender, System.EventArgs e)
		{
			EditName en = new EditName();
			en.Name = g.GetNode(highlightedNode).Name;
			en.ShowDialog();
			g.GetNode(highlightedNode).Name = en.Name;
			panelGraph.Refresh();
		}

		/// <summary>
		/// Minimum Spanning Tree
		/// </summary>
		private void menuMST_Click(object sender, System.EventArgs e)
		{
			try
			{
				MST mst = new MST(this.g);
				MSTForm mstf = new MSTForm();
				mstf.panelGraph.Size = this.panelGraph.Size;
				mstf.Graph = this.g;
				mstf.MSTLinks = mst.MSTLinks;
				mstf.Show();
			}
			catch(Exception)
			{
				MessageBox.Show("Something is wrong - probably the graph is not connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void menuDirected_Click(object sender, System.EventArgs e)
		{
			menuDirected.Checked = true;
			menuUndirected.Checked = false;
			menuMST.Enabled = false;
			graphType = GraphType.Directed;
			panelGraph.Refresh();
		}

		private void menuUndirected_Click(object sender, System.EventArgs e)
		{
			menuUndirected.Checked = true;
			menuDirected.Checked = false;
			menuMST.Enabled = true;
			graphType = GraphType.Undirected;
			panelGraph.Refresh();
		}

		/// <summary>
		/// Shortest Path
		/// </summary>
		private void menuShortestPath_Click(object sender, System.EventArgs e)
		{
			operation = Operations.ShortestPath;	
		}

		private void mcDeleteNode_Click(object sender, System.EventArgs e)
		{
			g.RemoveNode(g.GetNode(highlightedNode));
			highlightedNode = -1;
			panelGraph.Refresh();
		}

		private void menuTSP_Click(object sender, System.EventArgs e)
		{
			// first determine the minimum spanning tree
			try
			{
				TSP tsp = new TSP(this.g);
				//tsp.PreOrder(copy.GetNode(0));
				TSPForm tspf = new TSPForm();
				tspf.panelGraph.Size = this.panelGraph.Size;
				tspf.Graph = tsp.Copy;
				tspf.TSPLinks = tsp.Tour;
				tspf.Show();
			}
			catch
			{
			}
		}

	}
}
