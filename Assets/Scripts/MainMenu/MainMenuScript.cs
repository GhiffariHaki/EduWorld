using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class MainMenuScript : MonoBehaviour
{
    public GameObject menu;

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("StartGame"))
        {
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            SceneManager.LoadScene("GameLobby");
        }

        if (CrossPlatformInputManager.GetButtonDown("Options"))
        {
            menu.SetActive(true);
        }

        if (CrossPlatformInputManager.GetButtonDown("Cancel"))
        {
            menu.SetActive(false);
        }

        if (CrossPlatformInputManager.GetButtonDown("QuitGame"))
        {
            Debug.Log("Dah Out");
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            Application.Quit();
        }
    }
}
