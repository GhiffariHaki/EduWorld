using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuAtas : MonoBehaviour
{
    PlayerData player;
    Text coinText;
    Text classText;
    Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerData>();

        coinText = GameObject.Find("CoinText").GetComponent<Text>();
        classText = GameObject.Find("ClassText").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = player.coin.ToString();
        if (player.playerClass == 1)
        {
            classText.text = "Anti";
        }
        else if (player.playerClass == 2)
        {
            classText.text = "Warrior";
        }
        else
        {
            classText.text = "Wizard";
        }
        levelText.text = player.playerLevel.ToString();
    }
}
