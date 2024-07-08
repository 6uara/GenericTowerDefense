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
        myDijkstra = new Dijkstra();
        CalculatePath();
    }
    void CalculatePath()
    {
        PointInfo id = startWaypoint.GetComponent<PointInfo>();
        myDijkstra.Dijks(GDManager.Instance.grafo, id.ID);

        GameObject targetObject = GDManager.Instance.Vertices[GDManager.Instance.Vertices.Length -1];
        int targetIndex = GDManager.Instance.grafo.Vert2Indice(targetObject);
        for (int i=0; i< myDijkstra.nodos.Length;i++)
        {
            print("Nodo de myDijkstra "+myDijkstra.nodos[i]);
        }

        string[] pathToTarget = myDijkstra.nodos[targetIndex].Split(',');
        int[] pathID = new int[pathToTarget.Length];
        pathPositions = new Vector3[pathToTarget.Length];
        for (int i = 0; i < pathToTarget.Length; i++)
        {
            pathID[i] = System.Convert.ToInt32(pathToTarget[i]);
        }
        for(int a = 0; a<pathToTarget.Length;a++)
        {
            for(int d = 0; d < GDManager.Instance.Vertices.Length;d++)
            {
                if(pathID[a] == GDManager.Instance.Vertices[d].GetComponent<PointInfo>().ID )
                {
                    pathPositions[a] = GDManager.Instance.Vertices[d].transform.position;
                }
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