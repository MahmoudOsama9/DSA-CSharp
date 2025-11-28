using System;
using GraphAlgorithms.Implementations;

namespace GraphAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("=== Graph Theory Fundamentals: BFS and DFS ===\n");

            //var graph = new AdjacencyListGraph<int>();

            //// 1 -- 2 -- 4
            //// |    |
            //// 3 -- 5

            //graph.AddEdge(1, 2);
            //graph.AddEdge(1, 3);
            //graph.AddEdge(2, 4);
            //graph.AddEdge(2, 5);
            //graph.AddEdge(3, 5);
            //graph.AddVertex(6);

            //Console.WriteLine("Adjacency List:");
            //graph.PrintGraph();
            //Console.WriteLine("--------------------------------------------");

            //graph.BFS(1);

            //graph.DFS(1);

            Console.WriteLine("=== Topological Sort (Directed Acyclic Graph) ===\n");

            var courseGraph = new AdjacencyListGraph<string>();

            courseGraph.AddEdge("Math", "Physics", isBidirectional: false);
            courseGraph.AddEdge("Physics", "Advanced Mechanics", isBidirectional: false);
            courseGraph.AddEdge("Math", "Statistics", isBidirectional: false);
            courseGraph.AddEdge("Programming", "Statistics", isBidirectional: false);
            courseGraph.AddVertex("History");

            Console.WriteLine("Course Graph Dependencies:");
            courseGraph.PrintGraph();
            Console.WriteLine("-------------------------------------------------");

            var sortedOrder = courseGraph.TopologicalSort();

            Console.WriteLine($"Recommended Course Order (Total Ordering):");
            Console.WriteLine($"[{string.Join(" -> ", sortedOrder)}]");

            Console.ReadKey();
        }
    }
}