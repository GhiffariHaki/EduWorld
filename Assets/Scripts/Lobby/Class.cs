using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Class : MonoBehaviour
{
    public GameObject classMenu, buttonChange;
    public PlayerData player;
    public int level;
    public Text levelreq;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerData>();
    }



    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.playerLevel);

        if (CrossPlatformInputManager.GetButtonDown("AntiClass"))
        {
            player.playerClass = 1;
            PlayerPrefs.SetInt("Class", player.playerClass);

        }
        if (CrossPlatformInputManager.GetButtonDown("WarriorClass"))
        {
            player.playerClass = 2;
            PlayerPrefs.SetInt("Class", player.playerClass);
        }
        if (CrossPlatformInputManager.GetButtonDown("WizardClass"))
        {
            player.playerClass = 3;
            PlayerPrefs.SetInt("Class", player.playerClass);
        }
    }

    public void OpenClassWindow()
    {
        classMenu.SetActive(true);

        if (player.playerLevel < 2)
        {
            buttonChange.gameObject.SetActive(false);
        }
        else if (player.playerLevel == 3)
        {
            levelreq.gameObject.SetActive(false);
        }
    }
}
