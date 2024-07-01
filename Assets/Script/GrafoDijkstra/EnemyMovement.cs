using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject startWaypoint; // Starting waypoint
    public GameObject goalWaypoint; // End waypoint
    public float movementSpeed = 2;
    
    void Start()
    {
        CalculatePath();// Calcula el camino asumiendo que Start y End ya estan seteados
    }

    void CalculatePath()
    {
        Dijkstra.Instance.Dijks(GDManager.Instance.grafo, startWaypoint);//Usa Dijkstra para encontrar el camino mas corto

        // Retrieve the calculated path from start to goal waypoints
        string[] pathNodes = Dijkstra.Instance.nodos; // Consigue el camino generado
        if (pathNodes != null && pathNodes.Length > 0)
        {
            GameObject[] pathWaypoints = new GameObject[pathNodes.Length];// Convert pathNodes to GameObjects for movement
            for (int i = 0; i < pathNodes.Length; i++)
            {
                pathWaypoints[i] = GameObject.Find(pathNodes[i]);// Assuming pathNodes[i] is the name of the waypoint GameObject
            }
            MoveAlongPath(pathWaypoints);//mueve al enemigo en el camino
        }
    }

    public void MoveAlongPath(GameObject[] waypoints)
    {
        foreach (GameObject waypoint in waypoints)
        {
            if( waypoint != null)
            {
                Vector3 targetPosition = waypoint.transform.position;//mueve al enemigo al sig punto
                while (transform.position != targetPosition)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * movementSpeed);
                }
            }
        }
        //EnemyReachedGoal();//llego al final
    }

    void EnemyReachedGoal()
    {
        Destroy(gameObject); // Muere
    }
}