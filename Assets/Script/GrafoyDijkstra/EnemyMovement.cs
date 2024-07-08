using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject startWaypoint; // Starting waypoint
    public GameObject goalWaypoint; // End waypoint
    public float movementSpeed = 2;
    private string goalName = "FinalPoint";
    private Vector3[] pathPositions;
    private Dijkstra myDijkstra;
    private int nodosrecorridos;
    
    void Start()
    {
        CalculatePath();
    }
    void CalculatePath()
    {
        if (GDManager.Instance == null)
        {
            Debug.LogError("GDManager instance is not found!");
            return;
        }

        myDijkstra = gameObject.AddComponent<Dijkstra>(); // Ensuring Dijkstra is a component of the GameObject
        myDijkstra.Dijks(GDManager.Instance.grafo, startWaypoint);

        GameObject targetObject = GameObject.Find(goalName);
        if (targetObject == null)
        {
            Debug.LogError("Target object not found: " + goalName);
            return;
        }

        int targetIndex = GDManager.Instance.grafo.Vert2Indice(targetObject);
        string[] pathToTarget = myDijkstra.nodos[targetIndex].Split(',');

        Debug.Log("Path to Target: " + string.Join(", ", pathToTarget)); // Log the path

        pathPositions = new Vector3[pathToTarget.Length];
        for (int i = 0; i < pathToTarget.Length; i++)
        {
            Debug.Log("Finding GameObject: " + pathToTarget[i]);
            GameObject node = GameObject.Find(pathToTarget[i]);
            if (node != null)
            {
                pathPositions[i] = node.transform.position;
                Debug.Log("Found GameObject: " + pathToTarget[i] + " at position: " + node.transform.position);
            }
            else
            {
                Debug.LogError("Node not found: " + pathToTarget[i]);
            }
        }
        nodosrecorridos = 0;
    }

    IEnumerator FollowPath()
    {
        for (int i = 0; i < pathPositions.Length; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 targetPosition = pathPositions[i];
            float journeyLength = Vector3.Distance(startPosition, targetPosition);
            float startTime = Time.time;

            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                float distCovered = (Time.time - startTime) * movementSpeed;
                float fractionOfJourney = distCovered / journeyLength;
                transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
                yield return null;
            }
            
            // Ensure the enemy reaches the exact target position
            transform.position = targetPosition;
        }
    }
}