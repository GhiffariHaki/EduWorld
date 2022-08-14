using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class QuitButton : MonoBehaviour
{

    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("QuitButton"))
        {
            menu.SetActive(false);
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
        }
    }
}
