using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Grafo grafo; // Instance of the graph manager
    public GameObject startWaypoint; // Starting waypoint for the enemy
    public GameObject goalWaypoint; // Goal waypoint for the enemy
    public float movementSpeed = 2;
    
    void Start()
    {
        // Assuming grafo and startWaypoint/goalWaypoint are initialized or set elsewhere
        CalculatePath();
    }

    void CalculatePath()
    {
        // Use Dijkstra's algorithm to find the shortest path from startWaypoint to goalWaypoint
        Dijkstra.Dijks(grafo, startWaypoint);

        // Retrieve the calculated path from start to goal waypoints
        string[] pathNodes = Dijkstra.nodos;
        if (pathNodes != null && pathNodes.Length > 0)
        {
            // Convert pathNodes to GameObjects for movement
            GameObject[] pathWaypoints = new GameObject[pathNodes.Length];
            for (int i = 0; i < pathNodes.Length; i++)
            {
                // Assuming pathNodes[i] is the name of the waypoint GameObject
                pathWaypoints[i] = GameObject.Find(pathNodes[i]);
            }

            // Start enemy movement along the path
            StartCoroutine(MoveAlongPath(pathWaypoints));
        }
    }

    IEnumerator MoveAlongPath(GameObject[] waypoints)
    {
        foreach (GameObject waypoint in waypoints)
        {
            // Move enemy to the next waypoint
            Vector3 targetPosition = waypoint.transform.position;
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * movementSpeed);
                yield return null;
            }
            yield return new WaitForSeconds(0.5f); // Optional delay between waypoints
        }

        // Reached the goal waypoint, handle enemy reaching destination
        EnemyReachedGoal();
    }

    void EnemyReachedGoal()
    {
        // Implement behavior when the enemy reaches the goal waypoint (e.g., attack, destroy, etc.)
        Destroy(gameObject); // Example: destroy the enemy GameObject
    }
}