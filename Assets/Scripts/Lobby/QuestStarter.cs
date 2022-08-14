using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class QuestStarter : MonoBehaviour
{
    public GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("QuestStarter"))
        {
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            Player.transform.position = new Vector2((float)-1.45, 0);
            SceneManager.LoadScene("CombatAnalog");
        }
        if (CrossPlatformInputManager.GetButtonDown("QuestStarterSinonim"))
        {
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            Player.transform.position = new Vector2((float)-1.45, 0);
            SceneManager.LoadScene("CombatSinonim");
        }
        if (CrossPlatformInputManager.GetButtonDown("QuestStarterAntonim"))
        {
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            Player.transform.position = new Vector2((float)-1.45, 0);
            SceneManager.LoadScene("CombatAntonim");
        }
    }
}
