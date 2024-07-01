[System.Serializable]
public class Score
{
    public int points;
    public string level;

    public Score(int points, string level)
    {
        this.points = points;
        this.level = level;
    }
}
