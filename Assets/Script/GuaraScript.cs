using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GuaraScript : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints; // Array of waypoint prefabs
    [SerializeField] private float speed = 2f; // Enemy movement speed

    private int currentWaypointIndex = 0; // Index of the current waypoint
    private List<Node> nodes; // List of nodes representing the game map
    private List<Node> path;

    private Vector3 startPoint;
    private Vector3 endPoint;

    void Start()
    {
        // Create nodes from the environment (replace with your map generation logic)
        nodes = CreateNodesFromMap(); // Implement this function to create nodes based on your map

        // Find the shortest path using Dijkstra's algorithm
        path = FindShortestPath(startPoint, endPoint);
    }
    void Update()
    {
        if (path != null && path.Count > 0)
        {
            // Move towards the next node in the path
            Node targetNode = path[0];
            Vector3 targetPosition = targetNode.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Check if reached the current node
            if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
            {
                path.RemoveAt(0); // Remove the reached node from the path
            }
        }
        else
        {
            // Enemy reached the end (or failed to find a path)
            Destroy(gameObject);
        }
    }
    private List<Node> CreateNodesFromMap()
    {
        // Implement logic to create nodes based on your map representation (e.g., grid, obstacles)
        // This could involve iterating through tiles, defining connections, and assigning costs
        // (replace with your specific map generation approach)
        List<Node> nodes = new List<Node>();
        // ... (your map processing logic)
        return nodes;
    }
    private List<Node> FindShortestPath(Vector3 startPosition, Vector3 endPosition)
    {
        // Dijkstra's Algorithm Implementation
        List<Node> unvisited = new List<Node>(nodes); // Todos los nodos no visitados
        Dictionary<Node, float> distances = new Dictionary<Node, float>(); // Distancias entre nodo y nodo
        foreach (Node node in nodes)
        {
            distances[node] = float.PositiveInfinity; // crea una distancia positiva para todos los nodos
        }
        distances[GetNodeFromPosition(startPosition)] = 0f; // El nodo comienzo tiene distancia 0
        while (unvisited.Count > 0) //mientras la cantidad de nodos no visitados sea >0
        {
            Node current = unvisited.OrderBy(node => distances[node]).FirstOrDefault(); //encontrar el nodo no visitado mas cercano
            unvisited.Remove(current); // Lo remueve de la lista

            if (current == GetNodeFromPosition(endPosition)) // si el nodo actual es el nodo final
            {
                return ReconstructPath(current); // rehacer el camino, aca deberia destruirse
            }

            foreach (Node neighbor in current.neighbors) // por cada nodo en current.neighbors
            {
                float tentativeDistance = distances[current] + GetDistance(current, neighbor); // calcular la distancia aproximada al nodo
                if (tentativeDistance < distances[neighbor])// si la distancia aproximada es mas corta actualizarla
                {
                    distances[neighbor] = tentativeDistance;
                }
            }
        }
        return null;
    }
    private float GetDistance(Node node1, Node node2)
    {
        // Calculate the distance between two nodes (replace with your distance calculation logic)
        // This could be Euclidean distance, Manhattan distance, or custom cost calculation based on terrain
        return Vector3.Distance(node1.position, node2.position);
    }
    private Node GetPredecessor(Node node)
    {
        // Replace with your logic to access the predecessor information stored within the Node class
        // This could involve adding a `predecessor` field to the Node class and setting it during Dijkstra's algorithm
        return null; // Replace with actual predecessor retrieval logic
    }
    private List<Node> ReconstructPath(Node endNode)
{
    List<Node> path = new List<Node>();
    path.Add(endNode);

    Node current = endNode;
    while (current != null)
    {
        // Traverse backwards using the predecessor information
        Node predecessor = GetPredecessor(current);
        if (predecessor != null)
        {
            path.Insert(0, predecessor); // Insert predecessor at the beginning
            current = predecessor;
        }
        else
        {
            // Reached the starting node (predecessor will be null)
            break;
        }
    }

    return path;
}
    private Node GetNodeFromPosition(Vector3 position)
    {
        // Find the node corresponding to the given position (based on your node creation logic)
        foreach (Node node in nodes)
        {
            if (node.position == position)
            {
                return node;
            }
        }
        return null; // Node not found
    }
    public class Node
    {
        public Vector3 position;
        public List<Node> neighbors = new List<Node>();

        public Node(Vector3 position)
        {
            this.position = position;
        }
    }

    // Implement Dijkstra's algorithm here for more complex pathfinding needs
    // (This example uses pre-defined waypoints for simplicity)
}
