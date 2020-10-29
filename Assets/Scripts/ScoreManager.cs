using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.SetSaveManager(this);
    }

    public void SaveScore(int score)
    {
        if (PlayerPrefs.GetInt("bestScore") < score)
        {
            PlayerPrefs.SetInt("bestScore", score);
        }
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt("bestScore");
    }
}
