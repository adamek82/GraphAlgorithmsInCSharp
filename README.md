# Graph Algorithms in C# (Windows Forms)

This repository contains a collection of graph algorithms implemented in C# (.NET 1.1) with a simple Windows Forms UI for creating and visualizing graphs. It demonstrates core data structures (`Graph`, `Node`, `Link`), utility components (`UnionFind`, `PriorityQueue`), and classic algorithms: Minimum Spanning Tree (MST), Shortest Path (Dijkstra), and an approximate Travelling Salesman Problem (TSP) solver.

---

## Project Structure

    /src
      |-- Graph.cs                    # In‑memory representation of the graph
      |-- Node.cs                     # Graph node with position and adjacency list
      |-- Link.cs                     # Edge between two nodes with weight
      |-- UnionFind.cs                # Disjoint‑set data structure for cycle detection
      |-- PriorityQueue.cs            # Min‑heap for selecting next edge/node (used by MST and Dijkstra)

      |-- MST.cs                      # Kruskal’s algorithm for Minimum Spanning Tree
      |-- ShortestPath.cs             # Dijkstra’s algorithm for shortest paths
      |-- TSP.cs                      # Approximate TSP via MST preorder + 2‑opt optimization

      |-- GraphAlgorithmsForm.cs      # Main form: add/remove nodes & links, invoke algorithms
      |-- GraphAlgorithmsForm.resx    # UI resources (strings, menus)
      |-- ShortestPathForm.cs         # Visualization of calculated shortest path
      |-- MSTForm.cs                  # Visualization of the MST (not shown here)
      |-- TSPForm.cs                  # Visualization of the TSP tour (not shown here)
      |-- MyPanel.cs                  # Custom panel for drawing graphs
      |-- EditCost.cs/.resx           # Dialog to change edge weights
      |-- EditName.cs/.resx           # Dialog to rename nodes
      |-- WindowSizeDialog.cs/.resx   # Dialog to adjust canvas size

    GraphAlgorithms.sln / GraphAlgorithms.csproj

> **Note:** `bin/` and `obj/` directories are excluded via `.gitignore`, since they contain generated build artifacts.

---

## Core Data Structures

### Graph
- Holds a list of `Node` objects (`ArrayList nodes`) and global metadata:
  - `name`, `nodeSize` (display radius)
  - `last_node_number` (auto‑incrementing ID)
  - `links` (total number of edges)
- Methods to add/remove nodes and links, reindexing when nodes are deleted.

### Node
- Represents a vertex with:
  - `number` (0‑based index), `name` (label)
  - `(x, y)` coordinates for drawing
  - `ArrayList links` of outgoing `Link` objects
- Methods to add/remove/find links by destination.

### Link
- Directed (or undirected via two opposite links) edge:
  - `SrcNode`, `DestNode` references
  - `Weight` (integer cost, default Euclidean distance)

### UnionFind
- Disjoint‑set structure for cycle detection in MST (Kruskal).
- Methods: `InitSets()`, `find(int)`, `setUnion(int,int)` with union by size.

### PriorityQueue
- Min‑heap supporting `enqueue(item, priority, data)` and `dequeue(out priority, out data)`.
- Used in both MST (to sort edges) and Dijkstra (to pick next node by tentative distance).

---

## Algorithms

### Minimum Spanning Tree (MST)
Implemented in `MST.cs` using **Kruskal's algorithm**:
1. Collect all undirected edges (each link once).
2. Enqueue edges into a `PriorityQueue` keyed by weight.
3. Initialize `UnionFind` sets for each node.
4. Dequeue edges in ascending order; if their endpoints are in different sets, union them and add to the MST list.
5. Continue until `V-1` edges are chosen.

**Output:** `ArrayList MSTLinks` containing the selected `Link` objects.

### Shortest Path (Dijkstra)
Implemented in `ShortestPath.cs`:
1. Initialize distance to the start node as 0, others as ∞.
2. Use `PriorityQueue` to pick the unvisited node with the smallest tentative distance.
3. For each outgoing link, if going through the current node yields a shorter path, update the node’s father and enqueue it with the new priority.
4. Stop when the target node is dequeued.
5. Reconstruct path by following the `fathers[]` array backwards from the destination.

**Output:** `ArrayList Path` listing `Node` objects from destination back to source.

### Travelling Salesman Problem (Approximate)
Implemented in `TSP.cs` using a **MST‑based heuristic + 2‑opt optimization**:
1. Build a complete graph (`full`) by adding Euclidean links between every pair of nodes.
2. Compute its MST (`MST full`).
3. Copy the MST's edges into a new subgraph (`copy`).
4. Perform a **preorder traversal** of the MST to list nodes (`tourNodes`).
5. Form an initial tour by connecting consecutive nodes in `tourNodes` and returning to the start.
6. Improve the tour via **2‑opt swaps**: iteratively reverse segments if it shortens the total cost.

**Output:** `ArrayList Tour` of `Link` objects representing the final circuit.

---

## UI Overview

- **GraphAlgorithmsForm**: Main window where users can:
  - **Select**: Move or edit nodes/links via context menus.
  - **Node**: Click to add new nodes.
  - **Link**: Click two nodes to connect them.
  - **Algorithms** menu to run MST, Shortest Path, or TSP.
- **ShortestPathForm**, **MSTForm**, **TSPForm**: Pop-up windows that render results with highlighted nodes/edges.
- **Dialogs**: `EditCost` (edge weight), `EditName` (node label), `WindowSizeDialog`.

Drawing is handled in a custom `MyPanel` subclass, using GDI+ (`Graphics`, `Matrix`) for layout and transformation.

---

## Building & Running

1. Open `GraphAlgorithms.sln` in **Visual Studio .NET 2003** (or newer with .NET 1.1 support).  
2. Build the solution (ensuring `PriorityQueue.cs` is included).  
3. Run the `GraphAlgorithms` project.

---

## Acknowledgments

Inspired by standard graph algorithm textbooks and GDI+ tutorials.
