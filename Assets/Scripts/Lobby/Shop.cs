using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Shop : MonoBehaviour
{
    public GameObject shopMenu;
    public PlayerData player;

    public ItemShop noHat;
    public ItemShop wizardHat;
    public ItemShop warriorHat;
    public ItemShop blueHat;
    public ItemShop greenHat;
    public ItemShop redHat;
    public ItemShop BlackSkin;
    public ItemShop WhiteSkin;
    public ItemShop CreamSkin;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerData>();
        shopMenu = GameObject.Find("UIShopMenu");
        noHat = GameObject.Find("NoHat").GetComponent<ItemShop>();
        wizardHat = GameObject.Find("WizardHat").GetComponent<ItemShop>();
        warriorHat = GameObject.Find("WarriorHat").GetComponent<ItemShop>();
        blueHat = GameObject.Find("BlueHat").GetComponent<ItemShop>();
        greenHat = GameObject.Find("GreenHat").GetComponent<ItemShop>();
        redHat = GameObject.Find("RedHat").GetComponent<ItemShop>();
        BlackSkin = GameObject.Find("BlackSkin").GetComponent<ItemShop>();
        WhiteSkin = GameObject.Find("WhiteSkin").GetComponent<ItemShop>();
        CreamSkin = GameObject.Find("CreamSkin").GetComponent<ItemShop>();

        shopMenu.SetActive(false);

        if (PlayerPrefs.HasKey("SetShop"))
        {
            if((PlayerPrefs.GetInt("WizardHat")) > 0)
            {
                wizardHat.setCost(0);
            }
            if ((PlayerPrefs.GetInt("WarriorHat")) > 0)
            {
                warriorHat.setCost(0);
            }
            if ((PlayerPrefs.GetInt("BlueHat")) > 0)
            {
                blueHat.setCost(0);
            }
            if ((PlayerPrefs.GetInt("GreenHat")) > 0)
            {
                greenHat.setCost(0);
            }
            if ((PlayerPrefs.GetInt("RedHat")) > 0)
            {
                redHat.setCost(0);
            }
            if ((PlayerPrefs.GetInt("WhiteSkin")) > 0)
            {
                WhiteSkin.setCost(0);
            }
            if ((PlayerPrefs.GetInt("CreamSkin")) > 0)
            {
                CreamSkin.setCost(0);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SetShop", 0);
            PlayerPrefs.SetInt("WizardHat", 0);
            PlayerPrefs.SetInt("WarriorHat", 0);
            PlayerPrefs.SetInt("BlueHat", 0);
            PlayerPrefs.SetInt("GreenHat", 0);
            PlayerPrefs.SetInt("RedHat", 0);
            PlayerPrefs.SetInt("WhiteSkin", 0);
            PlayerPrefs.SetInt("CreamSkin", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("NoHat"))
        {
            if (player.coin >= noHat.cost)
            {
                player.coin = player.coin - noHat.cost;
                noHat.spriteChangeHat();
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            }
        }
        if (CrossPlatformInputManager.GetButtonDown("WarriorHat"))
        {
            if (player.coin >= warriorHat.cost)
            {
                player.coin = player.coin - warriorHat.cost;
                warriorHat.spriteChangeHat();
                PlayerPrefs.SetInt("WarriorHat", 2);
                PlayerPrefs.SetInt("Coin", player.coin);
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            }
        }
        if (CrossPlatformInputManager.GetButtonDown("WizardHat"))
        {
            if (player.coin >= wizardHat.cost)
            {
                player.coin = player.coin - wizardHat.cost;
                wizardHat.spriteChangeHat();
                PlayerPrefs.SetInt("WizardHat", 2);
                PlayerPrefs.SetInt("Coin", player.coin);
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            }
        }
        if (CrossPlatformInputManager.GetButtonDown("BlueHat"))
        {
            if (player.coin >= blueHat.cost)
            {
                player.coin = player.coin - blueHat.cost;
                blueHat.spriteChangeHat();
                PlayerPrefs.SetInt("BlueHat", 2);
                PlayerPrefs.SetInt("Coin", player.coin);
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            }
        }
        if (CrossPlatformInputManager.GetButtonDown("RedHat"))
        {
            if (player.coin >= redHat.cost)
            {
                player.coin = player.coin - redHat.cost;
                redHat.spriteChangeHat();
                PlayerPrefs.SetInt("RedHat", 2);
                PlayerPrefs.SetInt("Coin", player.coin);
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            }
        }
        if (CrossPlatformInputManager.GetButtonDown("GreenHat"))
        {
            if (player.coin >= greenHat.cost)
            {
                player.coin = player.coin - greenHat.cost;
                greenHat.spriteChangeHat();
                PlayerPrefs.SetInt("GreenHat", 2);
                PlayerPrefs.SetInt("Coin", player.coin);
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            }
        }
        if (CrossPlatformInputManager.GetButtonDown("BlackSkin"))
        {
            if (player.coin >= BlackSkin.cost)
            {
                player.coin = player.coin - BlackSkin.cost;
                BlackSkin.spriteChangeBody();
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            }
        }
        if (CrossPlatformInputManager.GetButtonDown("WhiteSkin"))
        {
            if (player.coin >= WhiteSkin.cost)
            {
                player.coin = player.coin - WhiteSkin.cost;
                WhiteSkin.spriteChangeBody();
                PlayerPrefs.SetInt("WhiteSkin", 2);
                PlayerPrefs.SetInt("Coin", player.coin);
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            }
        }
        if (CrossPlatformInputManager.GetButtonDown("CreamSkin"))
        {
            if (player.coin >= CreamSkin.cost)
            {
                player.coin = player.coin - CreamSkin.cost;
                CreamSkin.spriteChangeBody();
                PlayerPrefs.SetInt("CreamSkin", 2);
                PlayerPrefs.SetInt("Coin", player.coin);
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
            }
        }
    }

    public void OpenShopWindow()
    {
        shopMenu.SetActive(true);
    }
}
