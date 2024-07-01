using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MainCastle castle;
    [SerializeField] private Spawner enemySpawner;

    public static GameManager Instance;
    private TheSceneManager sceneManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TheSceneManager>();
    }

    private void OnEnable()
    {
        castle.Defeat += Lose; // Suscribirse al evento Defeat del castillo
        enemySpawner.lastEnemy += Victory;
    }

    private void OnDisable()
    {
        castle.Defeat -= Lose; // Asegurarse de desuscribirse cuando el GameManager se desactive
        enemySpawner.lastEnemy -= Victory;
    }

    private void Victory()
    {
        Debug.Log(SceneManager.GetActiveScene().ToString());
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            sceneManager.FinishedTutorial();
            Debug.Log("Tutorial terminado..., desbloqueando niveles");
        }
        SaveScore(castle.GetHealth(), SceneManager.GetActiveScene().name);
        sceneManager.LoadNewScene("VictoryScene");
    }

    private void Lose()
    {
        sceneManager.LoadNewScene("LoseScene");
    }

    private void SaveScore(int score, string level)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/scores.dat";
        List<Score> scores;

        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            scores = (List<Score>)formatter.Deserialize(stream);
            stream.Close();
        }
        else
        {
            scores = new List<Score>();
        }

        scores.Add(new Score(score, level));

        FileStream saveStream = new FileStream(path, FileMode.Create);
        formatter.Serialize(saveStream, scores);
        saveStream.Close();

        Debug.Log("Saved " + score + " points in " + path);
    }
}

