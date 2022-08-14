using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class GameOver : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("RetryButton"))
        {
            RetryButton();
        }
        if (CrossPlatformInputManager.GetButtonDown("BackButton"))
        {
            BackButton();
        }
    }

    public void BackButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameLobby");
    }

    public void RetryButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
