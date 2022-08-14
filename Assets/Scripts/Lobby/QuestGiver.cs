using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public GameObject questmenu;
    public Text titleQuest, descQuest, rewardQuest, highscoreQuest, playcountQuest;
    public float highscore;
    public int playcount;

    void Start()
    {
        if(quest.title == "Sinonim")
        {
            if (PlayerPrefs.HasKey("HighScoreSinonim") && PlayerPrefs.HasKey("PlayCountSinonim"))
            {
                highscore = PlayerPrefs.GetFloat("HighScoreSinonim");
                playcount = PlayerPrefs.GetInt("PlayCountSinonim");
            }
            else
            {
                PlayerPrefs.SetFloat("HighScoreSinonim", 0);
                PlayerPrefs.SetInt("PlayCountSinonim", 0);
                highscore = 0;
                playcount = 0;
                Debug.Log("Ada HighScorenya");
            }
        }
        else if (quest.title == "Antonim")
        {
            if (PlayerPrefs.HasKey("HighScoreAntonim") && PlayerPrefs.HasKey("PlayCountAntonim"))
            {
                highscore = PlayerPrefs.GetFloat("HighScoreAntonim");
                playcount = PlayerPrefs.GetInt("PlayCountAntonim");
            }
            else
            {
                PlayerPrefs.SetFloat("HighScoreAntonim", 0);
                PlayerPrefs.SetInt("PlayCountAntonim", 0);
                highscore = 0;
                Debug.Log("Ada HighScorenya");
            }
        }
        else
        {
            if (PlayerPrefs.HasKey("HighScore") && PlayerPrefs.HasKey("PlayCount"))
            {
                highscore = PlayerPrefs.GetFloat("HighScore");
                playcount = PlayerPrefs.GetInt("PlayCount");
            }
            else
            {
                PlayerPrefs.SetFloat("HighScore", 0);
                PlayerPrefs.SetInt("PlayCount", 0);
                highscore = 0;
                Debug.Log("Ada HighScorenya");
            }
        }
    }

    public void OpenQuestWindow()
    {
        questmenu.SetActive(true);
        titleQuest.text = quest.title;
        descQuest.text = quest.description;
        rewardQuest.text = quest.reward.ToString();
        highscoreQuest.text = highscore.ToString("0.0");
        playcountQuest.text = playcount.ToString();
    }
}
