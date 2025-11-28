using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAlgorithms.Implementations
{
    public class AdjacencyListGraph<T> where T : notnull
    {
        private Dictionary<T, List<T>> adjacencyList;
        public AdjacencyListGraph()
        {
            adjacencyList = new Dictionary<T, List<T>>();
        }

        public void AddVertex(T vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = new List<T>();
            }
        }

        public void AddEdge(T source, T destination, bool isBidirectional = true)
        {
            if (!adjacencyList.ContainsKey(source)) AddVertex(source);

            if (!adjacencyList.ContainsKey(destination)) AddVertex(destination);

            adjacencyList[source].Add(destination);

            if (isBidirectional)
            {
                adjacencyList[destination].Add(source);
            }
        }

        public bool HasEdge(T source, T destination)
        {
            if (adjacencyList.ContainsKey(source))
            {
                return adjacencyList[source].Contains(destination);
            }
            return false;
        }

        public IList<T> GetNeighbors(T vertex)
        {
            if (adjacencyList.ContainsKey(vertex))
            {
                return adjacencyList[vertex];
            }
            return new List<T>();
        }

        public void BFS(T startVertex)
        {
            if (!adjacencyList.ContainsKey(startVertex)) return;

            var visited = new HashSet<T>();
            var queue = new Queue<T>();

            visited.Add(startVertex);
            queue.Enqueue(startVertex);

            Console.Write($"BFS starting at {startVertex}: ");

            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();
                Console.Write($"{currentVertex} ");

                foreach (var neighbor in adjacencyList[currentVertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            Console.WriteLine();
        }

        public void DFS(T startVertex)
        {
            if (!adjacencyList.ContainsKey(startVertex)) return;

            var visited = new HashSet<T>();
            Console.Write($"DFS starting at {startVertex}: ");
            DFSRecursive(startVertex, visited);
            Console.WriteLine();
        }

        private void DFSRecursive(T vertex, HashSet<T> visited)
        {
            visited.Add(vertex);
            Console.Write($"{vertex} ");
            foreach (var neighbor in adjacencyList[vertex])
            {
                if (!visited.Contains(neighbor))
                {
                    DFSRecursive(neighbor, visited);
                }
            }
        }

        public List<T> TopologicalSort() {
            var visited = new HashSet<T>();
            var recursionStack = new HashSet<T>();
            var stack = new Stack<T>();

            foreach (var vertex in adjacencyList.Keys) {
                if (!visited.Contains(vertex)) {
                    TopologicalSortDFS(vertex, visited, recursionStack, stack);
                }
            }

            return new List<T>(stack);
        }

        public void TopologicalSortDFS(T vertex, HashSet<T> visited, HashSet<T> recursionStack, Stack<T> stack)
        {
            visited.Add(vertex);
            recursionStack.Add(vertex);

            if (adjacencyList.ContainsKey(vertex)) {
                foreach (var neighbor in adjacencyList[vertex]) {
                    if (!visited.Contains(neighbor)) {
                        TopologicalSortDFS(neighbor, visited, recursionStack, stack);
                    }
                }
            }

            recursionStack.Remove(vertex);
            stack.Push(vertex);
        }

        public void PrintGraph()
        {
            foreach (var kvp in adjacencyList)
            {
                Console.WriteLine($"{kvp.Key} -> {string.Join(", ", kvp.Value)}");
            }
        }
    }
}
