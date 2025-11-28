using System;
using GraphAlgorithms.Implementations;

namespace GraphAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Graph Theory Fundamentals: BFS and DFS ===\n");

            var graph = new AdjacencyListGraph<int>();

            // 1 -- 2 -- 4
            // |    |
            // 3 -- 5

            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 5);
            graph.AddVertex(6);

            Console.WriteLine("Adjacency List:");
            graph.PrintGraph();
            Console.WriteLine("--------------------------------------------");

            graph.BFS(1);

            graph.DFS(1);
        }
    }
}