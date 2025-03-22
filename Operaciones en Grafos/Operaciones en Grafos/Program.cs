using System;
using System.Collections.Generic;

class Graph
{
    private Dictionary<int, List<int>> adjList;
    private bool isDirected;
    public Graph(bool directed = false)
    {
        adjList = new Dictionary<int, List<int>>();
        isDirected = directed;
    }
    public void AddNode(int node)
    {
        if (!adjList.ContainsKey(node))
            adjList[node] = new List<int>();
    }
    public void AddEdge(int from, int to)
    {
        if (!adjList.ContainsKey(from))
            AddNode(from);
        if (!adjList.ContainsKey(to))
            AddNode(to);

        adjList[from].Add(to);
        if (!isDirected)
            adjList[to].Add(from);
    }
    public void BFS(int start)
    {
        if (!adjList.ContainsKey(start)) return;

        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            Console.Write(node + " ");

            foreach (var neighbor in adjList[node])
            {
                if (!visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }
        }
        Console.WriteLine();
    }
    public void DFS(int start)
    {
        if (!adjList.ContainsKey(start)) return;

        var visited = new HashSet<int>();
        DFSHelper(start, visited);
        Console.WriteLine();
    }
    private void DFSHelper(int node, HashSet<int> visited)
    {
        Console.Write(node + " ");
        visited.Add(node);

        foreach (var neighbor in adjList[node])
        {
            if (!visited.Contains(neighbor))
                DFSHelper(neighbor, visited);
        }
    }
    public void Display()
    {
        foreach (var node in adjList)
        {
            Console.Write(node.Key + ": " + string.Join(", ", node.Value));
            Console.WriteLine();
        }
    }
}
class Program
{
    static void Main()
    {
        Graph graph = new Graph(directed: false);

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Quiero agregar nodo");
            Console.WriteLine("2. Quiero agregar arista");
            Console.WriteLine("3. Quiero mostrar el grafo");
            Console.WriteLine("4. BFS");
            Console.WriteLine("5. DFS");
            Console.WriteLine("6. Quiero salir del menu");
            Console.Write("Elija una opción: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Favor de ingresar un nodo: ");
                    int node = int.Parse(Console.ReadLine());
                    graph.AddNode(node);
                    break;
                case 2:
                    Console.Write("Favor de ingresar el nodo origen: ");
                    int from = int.Parse(Console.ReadLine());
                    Console.Write("Favor de ingresar el nodo destino: ");
                    int to = int.Parse(Console.ReadLine());
                    graph.AddEdge(from, to);
                    break;
                case 3:
                    graph.Display();
                    break;
                case 4:
                    Console.Write("Favor de ingresar el nodo de inicio para BFS: ");
                    int bfsStart = int.Parse(Console.ReadLine());
                    graph.BFS(bfsStart);
                    break;
                case 5:
                    Console.Write("Favor de ingresar el nodo de inicio para DFS: ");
                    int dfsStart = int.Parse(Console.ReadLine());
                    graph.DFS(dfsStart);
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Esta opción no es válida.");
                    break;
            }
        }
    }
}