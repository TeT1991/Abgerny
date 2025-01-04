using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePush;
using UnityEngine.SceneManagement;

public class GameAnalytics : MonoBehaviour
{
    public void CountLevelReset()
    {
        string resetLevelCountName = "RESET_LEVEL";

        int count = GetValue(resetLevelCountName) + 1;

        Debug.Log(count);

        PlayerPrefs.SetInt(resetLevelCountName, count);

        GP_Analytics.Goal(resetLevelCountName, count);
    }

    public void CountButtonUse(string name)
    {
        string eventName = "BUTTON_ID_" + name + "_USED";

        int count = GetValue(eventName) + 1;

        PlayerPrefs.SetInt(eventName, count);

        GP_Analytics.Goal(eventName, PlayerPrefs.GetInt(eventName));
    }

    private int GetValue(string eventName)
    {
        int value = 0;

        if (PlayerPrefs.HasKey(eventName))
        {
            value = PlayerPrefs.GetInt(eventName);
        }
        else
        {
            InitKey(eventName);
        }

        return value;
    }

    private void InitKey(string eventName)
    {
        int value = 0;

        PlayerPrefs.SetInt(eventName, value);
    }
}
