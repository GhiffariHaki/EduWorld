using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class MenuButton : MonoBehaviour
{

    public GameObject menu;
    private bool activate = false;

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("MenuButton"))
        {
            if (activate == false)
            {
                activate = true;
                menu.SetActive(true);
            }
            else
            {
                activate = false;
                menu.SetActive(false);
            }

            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
        }

        if (CrossPlatformInputManager.GetButtonDown("LobbyButton"))
        {
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            goToLobby();
        }

        if (CrossPlatformInputManager.GetButtonDown("MainMenuButton"))
        {
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            goToMainMenu();
        }
    }

    void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void goToLobby()
    {
        SceneManager.LoadScene("GameLobby");
    }
}
