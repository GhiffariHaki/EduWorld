using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    private Rigidbody2D MyRigidBody2D;

    public static PlayerData Instance;

    public string playerName;
    public int coin, playerClass, playerLevel, playcount;

    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerName = PlayerPrefs.GetString("PlayerName");
        }
        else
        {
            PlayerPrefs.SetString("PlayerName", "Udin");
            Debug.Log("Jadi Udin");
            playerName = PlayerPrefs.GetString("PlayerName");
        }

        if (PlayerPrefs.HasKey("Coin"))
        {
            coin = PlayerPrefs.GetInt("Coin");
        }
        else
        {
            PlayerPrefs.SetInt("Coin", 0);
            coin = PlayerPrefs.GetInt("Coin");
        }

        if (PlayerPrefs.HasKey("Class"))
        {
            playerClass = PlayerPrefs.GetInt("Class");
        }
        else
        {
            PlayerPrefs.SetInt("Class", 1);
            playerClass = PlayerPrefs.GetInt("Class");
        }

        if (PlayerPrefs.HasKey("Level"))
        {
            if (PlayerPrefs.HasKey("PlayCountAntonim"))
            {
                playcount += PlayerPrefs.GetInt("PlayCountAntonim");
            }
            if (PlayerPrefs.HasKey("PlayCountSinonim"))
            {
                playcount += PlayerPrefs.GetInt("PlayCountSinonim");
            }
            if (PlayerPrefs.HasKey("PlayCount"))
            {
                playcount += PlayerPrefs.GetInt("PlayCount");
            }
            if(playcount < 4)
            {
                PlayerPrefs.SetInt("Level", 1);
            }
            else if (playcount < 9)
            {
                PlayerPrefs.SetInt("Level", 2);
            }
            else
            {
                PlayerPrefs.SetInt("Level", 3);
            }
            playerLevel = PlayerPrefs.GetInt("Level");
        }
        else
        {
            PlayerPrefs.SetInt("Level", 1);
            playerLevel = PlayerPrefs.GetInt("Level");
        }

        MyRigidBody2D = GetComponent<Rigidbody2D>();

        if(Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
