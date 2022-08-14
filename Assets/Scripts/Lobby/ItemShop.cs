using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShop : MonoBehaviour
{
    [Header("Sprite To Change")]
    public SpriteRenderer bodyPartHat, bodyPartHead, bodyPartBody, bodyPartLeg1, bodyPartLeg2;

    [Header("The Sprite")]
    public Sprite optionsHat, optionsHead, optionsBody, optionsLeg1, optionsLeg2;

    [Header("Harga Item")]
    public int cost;

    public Text coinText;

    public void setCost(int gold)
    {
        cost = gold;
    }

    public void spriteChangeHat()
    {
        bodyPartHat.sprite = optionsHat;
        cost = 0;
    }

    public void spriteChangeBody()
    {
        bodyPartHead.sprite = optionsHead;
        bodyPartBody.sprite = optionsBody;
        bodyPartLeg1.sprite = optionsLeg1;
        bodyPartLeg2.sprite = optionsLeg2;
        cost = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = cost.ToString();
    }
}
