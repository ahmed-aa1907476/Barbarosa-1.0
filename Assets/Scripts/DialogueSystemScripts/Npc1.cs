using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using StarterAssets;

public class Npc1 : MonoBehaviour
{
    public GameObject triggerText;
    public GameObject DialogueObject;
   // public FirstPersonController rigid;
    private StarterAssetsInputs starterAssetsInputs;


    void Start()
    {
        DialogueObject.SetActive(false); 
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            triggerText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //starterAssetsInputs.shoot = false;
                GameObject.Find("PlayerArmature").GetComponent<ThirdPersonController>().LockCameraPosition = false;
                other.gameObject.GetComponent<PlayerData>().DialogueNumber = 1;
                
                DialogueObject.SetActive(true);
               // rigid.enabled = false;
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                UnityEngine.Cursor.visible = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DialogueObject.SetActive(false);
        triggerText.SetActive(false);
    }
}
