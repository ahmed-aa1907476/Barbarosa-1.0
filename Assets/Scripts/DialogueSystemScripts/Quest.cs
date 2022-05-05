using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour
{
    public GameObject questUI1;
    public TextMeshProUGUI showQuest1;
    public GameObject questUI2;
    public TextMeshProUGUI showQuest2;
    public GameObject questUI4;
    public TextMeshProUGUI showQuest4;
    public TextMeshProUGUI showQuestSon;
    public GameObject questMarker;
    public GameObject questMarkerSon;

    private int questKillCount = 0;
    public int tempKills = 0;
    private int sonCount = 0;
    public int state = 0;
    bool enteredQuest1 = false;
    bool alreadyPlayedQuest1 = false;
    bool enteredQuest2 = false;
    bool alreadyPlayedQuest2 = false;
    bool enteredQuest4 = false;
    bool alreadyPlayedQuest4 = false;

    //  public AudioClip sound;
    // private AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        //audio = GetComponent<AudioSource>();
        showQuest1.text = " ";
        questUI1.SetActive(false);
        showQuest2.text = " ";
        questUI2.SetActive(false);
        showQuest4.text = " ";
        questUI4.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !alreadyPlayedQuest1 && !enteredQuest1 && state == 0) {
            questUI1.SetActive(true);
            showQuest1.text = " ";


            // audio.PlayOneShot(sound, 5);
            alreadyPlayedQuest1 = true;
            enteredQuest1 = true;
        }
        if (other.tag == "Player" && !alreadyPlayedQuest2 && !enteredQuest2 && state == 1)
        {
            showQuest1.text = " ";
            questUI2.SetActive(true);
            showQuest2.text = " ";
            // audio.PlayOneShot(sound, 5);
            alreadyPlayedQuest2 = true;
            enteredQuest2 = true;
        }
        if (other.tag == "Player" && !alreadyPlayedQuest4 && !enteredQuest4 && state == 3)
        {
            showQuestSon.text = " ";
            questUI4.SetActive(true);
            showQuest4.text = " ";
             enteredQuest4 = true;
             alreadyPlayedQuest4 = true;
            //RETURN TO MAIN MENU
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && state == 0) {
            //  Destroy(showQuest);
            Destroy(questUI1);
            questMarker.SetActive(false);
            showQuest1.text = "Task 1 Activated -\nEnemies Killed: " + questKillCount.ToString() + "/4";
        }
        if (other.tag == "Player" && state == 1)
        {
            //  Destroy(showQuest);
            Destroy(questUI2);
            questMarker.SetActive(false);
            showQuest2.text = "Task 2 Activated -\nEnemies Killed: " + questKillCount.ToString() + "/4\n" + 
                "Find Sidd's Son: " + sonCount.ToString() + "/1";
        }
        if (other.tag == "Player" && state == 3) {
            showQuestSon.text = " "; 
            Destroy(questUI4);
            questMarker.SetActive(false);
            showQuest4.text = "Thank You for playing the game";
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            //RETURN TO MAIN MENU
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        if (tempKills != questKillCount && state == 0)
        {
            questKillCount = tempKills;
            showQuest1.text = "Task 1 Activated -\nEnemies Killed: " + questKillCount + "/4";
        }
        if (tempKills != questKillCount && state == 1)
        {
            questKillCount = tempKills;
            showQuest2.text = "Task 2 Activated -\nEnemies Killed: " + questKillCount.ToString() + "/4\n" +
                "Find Sidd's Son: " + sonCount.ToString() + "/1";
        }
        if (questKillCount == 4)
        {
            if (state == 0)
            {
                showQuest1.text = "Return to Villager Sidd!";
            }
            questMarker.SetActive(true);
            state++;
            tempKills = 0;
            questKillCount = 0;
        }
        if (state == 2) {
            GameObject.Find("VillagerSonCube").GetComponent<GetSonQuest>().state = this.state;
            questMarkerSon.SetActive(true);
            showQuest2.text = " Find the Son ";
        }
    }
}
