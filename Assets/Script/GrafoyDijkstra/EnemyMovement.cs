using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject startWaypoint; // Starting waypoint
    public GameObject goalWaypoint; // End waypoint
    public float movementSpeed = 2;
    private string startname = "StartingPoint";
    private Vector3[] pathPositions;
    private Dijkstra myDijkstra;
    private int nodosrecorridos;
    private Vector3 target;
    [SerializeField] private EnemyData data;
    private int randomNum;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject drop;
    [SerializeField] private int health;
    private int targetIndex;
    private GameObject targetObject;
    
    void Start()
    {
        startWaypoint = GetClosestObject();
        print(startWaypoint);
        myDijkstra = new Dijkstra();
        CalculatePath();
    }
    void CalculatePath()
    {
        PointInfo id = startWaypoint.GetComponent<PointInfo>();
        myDijkstra.Dijks(GDManager.Instance.grafo, id.ID);
        if(id.ID != 0){
            targetObject = GameObject.Find("FinalPoint");
            targetIndex = GDManager.Instance.grafo.Vert2Indice(targetObject);
        }else{
            targetObject = GameObject.Find("FinalPoint2");
            targetIndex = GDManager.Instance.grafo.Vert2Indice(targetObject);
        }
        //GameObject targetObject = GDManager.Instance.Vertices[GDManager.Instance.Vertices.Length -1];
        //int targetIndex = GDManager.Instance.grafo.Vert2Indice(targetObject);
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
        target = pathPositions[0]; 
        nodosrecorridos = 0;
    }


    private void Update()
    {
        if (Vector2.Distance(target, transform.position) <= 0.1f)
        {
            nodosrecorridos++;
            if (nodosrecorridos >= pathPositions.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                target = pathPositions[nodosrecorridos];
            }
        }        
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }
        else
        {
            Vector2 direction = (target - transform.position).normalized;
            rb.velocity = direction * data.Speed;
        }
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

    private GameObject GetClosestObject()
    {
        float distanceToObj1 = 0;
        float distanceToObj2 = 0;
        GameObject startone = GameObject.Find("StartingPoint");
        GameObject starttwo = GameObject.Find("StartingPoint2");
        if(starttwo == null)
        {
            return startone;
        }else{
            distanceToObj1 = Vector3.Distance(gameObject.transform.position, startone.transform.position);
            distanceToObj2 = Vector3.Distance(gameObject.transform.position, starttwo.transform.position);
        }

        if (distanceToObj1 < distanceToObj2)
        {
            return startone;
        }
        else
        {
            return starttwo;
        }
    }


}