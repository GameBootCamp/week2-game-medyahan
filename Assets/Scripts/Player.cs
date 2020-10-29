using UnityEngine;

public class Player
{
    private int score;

    public int GetScore()
    {
        return score;
    }

    public void ScoreKeeper(int point)
    {
        score += point;
    }
}
