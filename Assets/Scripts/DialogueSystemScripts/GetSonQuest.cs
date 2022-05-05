using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetSonQuest : MonoBehaviour
{
    public GameObject questUISon;
    //public GameObject questUI2;
    public TextMeshProUGUI showQuestSon;
    public TextMeshProUGUI showQuest2;
    public int state = 0;
    bool enteredQuestSon = false;
    bool alreadyPlayedQuestSon = false;
    public GameObject questionMark;
    private int killCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !alreadyPlayedQuestSon && !enteredQuestSon && this.state == 2)
        {
            showQuest2.text = " ";
           // questUI2.SetActive(false);
            questUISon.SetActive(true);
            showQuestSon.text = " ";
            showQuest2.text = " ";
            // audio.PlayOneShot(sound, 5);
            alreadyPlayedQuestSon = true;
            enteredQuestSon = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && state == 2)
        {
            //  Destroy(showQuest);
            Destroy(questUISon);
            questionMark.SetActive(false);
            showQuest2.text = " ";
            showQuestSon.text = "Return to Sidd on first island";
            GameObject.Find("VillageQuest").GetComponent<Quest>().state = 3;
            state++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        questionMark.SetActive(false);
        showQuestSon.text = " ";
        questUISon.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
