using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInteraction : MonoBehaviour
{

    // Detection Point
    public Transform detectionPoint;
    // Detection Radius
    private const float detectionRadius = 0.2f;
    // Detection Layer
    public LayerMask detectionLayer;

    private GameObject NPC;

    // Update is called once per frame
    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                if(NPC.tag == "QuestGiver")
                {
                    SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
                    QuestGiver questgiver = (QuestGiver)NPC.GetComponent(typeof(QuestGiver));
                    questgiver.OpenQuestWindow();
                }
                if(NPC.tag == "Shop")
                {
                    SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
                    Shop shop = (Shop)NPC.GetComponent(typeof(Shop));
                    shop.OpenShopWindow();
                }
                if (NPC.tag == "Class")
                {
                    SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.click);
                    Class playerClass = (Class)NPC.GetComponent(typeof(Class));
                    playerClass.OpenClassWindow();
                }
            }
        }
    }

    void OnTriggerStay2D (Collider2D target)
    {
        NPC = target.gameObject;
    }

    bool InteractInput()
    {
        if (CrossPlatformInputManager.GetButtonDown("Interact"))
        {
            return true;
        }
        else return false;
    }

    bool DetectObject()
    {
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
    }
}
