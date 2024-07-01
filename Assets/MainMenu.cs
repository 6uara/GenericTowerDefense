using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TheSceneManager sceneManager;
    public Button button1;
    public Button button2;
    public TextMeshProUGUI scoreText;
    private void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<TheSceneManager>();
        if (sceneManager.GetTutorialCompleted())
        {
            button1.interactable = true;
            button2.interactable = true;
        }
        else
        {
            button1.interactable = false;
            button2.interactable = false;
        }
        LoadScores();
    }

    public void LoadLevelByBranch(bool isRight)
    {
        sceneManager.LoadBranch(isRight);
    }

    public void LoadFirstLevel()
    {
        sceneManager.LoadFirstLevel();
    }

    public void LoadScores()
    {
        string path = Application.persistentDataPath + "/scores.dat";
        BinaryFormatter formatter = new BinaryFormatter();
        List<Score> scores = new List<Score>();

        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            scores = (List<Score>)formatter.Deserialize(stream);
            stream.Close();
        }
        else
        {
            Debug.LogWarning("No se encontró ningún dato de guardado.");
        }

        DisplayHighestScores(scores);
    }

    private void DisplayHighestScores(List<Score> scores)
    {
        // Diccionario para almacenar la puntuación más alta por nivel
        Dictionary<string, int> highestScores = new Dictionary<string, int>();

        // Obtener la puntuación más alta por nivel
        foreach (Score score in scores)
        {
            if (!highestScores.ContainsKey(score.level))
            {
                highestScores[score.level] = score.points;
            }
            else
            {
                if (score.points > highestScores[score.level])
                {
                    highestScores[score.level] = score.points;
                }
            }
        }

        // Convertir a lista de pares clave-valor para ordenar manualmente
        List<KeyValuePair<string, int>> sortedScores = new List<KeyValuePair<string, int>>(highestScores);

        // Ordenar la lista manualmente por puntuación descendente
        sortedScores.Sort((x, y) => y.Value.CompareTo(x.Value));

        // Mostrar las puntuaciones ordenadas en el texto
        scoreText.text = "";
        foreach (var pair in sortedScores)
        {
            scoreText.text += pair.Key + " score : " + pair.Value + "\n";
        }
    }
}
