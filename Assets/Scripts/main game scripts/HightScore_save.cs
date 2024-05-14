using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HightScore_save
{
    //saving highscore data using PlayerPrefs
    public static int GetHightScore_save()
    {
        return PlayerPrefs.GetInt("High Score");
    }

    public static bool SetNewHighScore(int score)
    {
        int CurrentHighestScore = GetHightScore_save();
        if (score > CurrentHighestScore)
        {
            PlayerPrefs.SetInt("High Score", score);
            PlayerPrefs.Save();
            return true;
        }
        else
        {
            return false;
        }
    }
}
