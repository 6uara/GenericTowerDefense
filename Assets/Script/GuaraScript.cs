using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GuaraScript : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private GameObject drop;
    [SerializeField] private int health;
    [SerializeField] private float speed = 2f; // Enemy movement speed

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    private GameObject[] waypoints; // Array de Waypoints
    private List<Node> nodes; // List of nodes representing the game map
    private List<Node> path;

    private GameObject start; // Punto de inicio
    private GameObject end; // Punto final

    [SerializeField] private Node startPoint; // Punto de inicio
    [SerializeField] private Node endPoint; // Punto final

    private int randomNum;

    void Start()
    {
        start = GameObject.FindGameObjectWithTag("StartPoint");
        end = GameObject.FindGameObjectWithTag("EndPoint");
        startPoint.position = start.transform.position;
        endPoint.position = end.transform.position;
        nodes = CreateNodesFromMap(); // Crea nodos a partir de waypoints provistos
        path = FindShortestPath(startPoint, endPoint);// define el camino a seguir
    }
    void Update()
    {
        if (path != null && path.Count > 0)
        {

            Node targetNode = path[0]; // define el nodo objetivo
            Vector3 targetPosition = targetNode.position; // define la posicion objetivo
            Vector2 direction = (targetPosition- transform.position).normalized;
            rb.velocity = direction * speed;
            if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)// chequea si ya esta en la pos
            {
                path.RemoveAt(0); // Saca el nodo de la lista
            }
        }
        else
        {
            Destroy(gameObject);// llego al final
        }
    }
    private List<Node> CreateNodesFromMap()
    {
        List<Node> nodes = new List<Node>(); // crea una lista de nodos
        nodes.Add(startPoint); // asigna primero el starting point
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");// encuentra todos los waypoints
        foreach (GameObject way in waypoints) // recorre los waypoints
        {
            Node w = new Node(way.transform.position); // crea un nodo a partir del waypoint actual
            nodes.LastOrDefault().next = w; // hace que el ult de la lista apunte al que vamos a añadir
            nodes.Add(w); // añadimos el nodo a la lista
        }
        return nodes; // devolvemos la lista de nodos
    }
    private List<Node> FindShortestPath(Node startPosition, Node endPosition)
    {
        List<Node> unvisited = new List<Node>(nodes); // Todos los nodos no visitados
        Node current = startPoint; // nodo actual
        path.Add(startPoint);// añadimos el nodo actual(startingpoint) a la lista
        unvisited.Remove(current);// lo sacamos de la lista de nodos no visitados
        while (unvisited.Count > 0) //mientras la cantidad de nodos no visitados sea >0
        {
            path.Add(GetClosestNode(unvisited,current)); // añade el nodo mas cercano
            unvisited.Remove(current); // Lo remueve de la lista

            if (current == endPosition) // si el nodo actual es el nodo final
            {
                return path; // asd
            }
        }
        return null;
    }
    private float GetDistance(Node node1, Node node2)
    {
        return Vector3.Distance(node1.position, node2.position);
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
        public Node next;

        public Node(Vector3 position)
        {
            this.position = position;
        }
    }
    public Node GetClosestNode(List<Node> unvisited,Node current)
    {
        Node saved = null; // nodo a devolver
        float MinDistance = float.MaxValue; // variable para sacar el mas cercano
        foreach (Node node in unvisited) //recorrer todos los nodos
        {
            if(GetDistance(current,node) < MinDistance) //si esta mas cerca que el mas cercano registrado
            {
                MinDistance = GetDistance(current,node); // asigna la minima distancia
                saved = current; // guarda el nodo
            }
        }
        return saved;
    }

        public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) 
        {
            Die();
        }
    }


    public void Die()
    {
        Destroy(gameObject);
        randomNum = UnityEngine.Random.Range(0,3);
        var pos = new Vector3(transform.position.x,transform.position.y,transform.position.z -4);
        if(randomNum == 0)
        {
          Instantiate(drop,pos,transform.rotation);  
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Castle"))
        {
            collision.gameObject.GetComponent<MainCastle>().TakeDamage(5);
            //enemyDied?.Invoke();
            Destroy(gameObject);
        }
    }
}
