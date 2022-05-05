using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   // private int counter;
    private static int killCount = 0;

    [SerializeField] private float enemyHealth = 100f;
    public GameObject Pickup;

    [SerializeField] private HealthBar healthBar;

    [SerializeField] private HealthSystem healthSystem;

    [SerializeField] private bool isBossEnemy;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new HealthSystem((int) enemyHealth);
        healthBar.Setup(healthSystem);
        //counter = 0;
    }

    public void takeDamage (float damage) {
       enemyHealth = healthSystem.Damage((int) damage);
        if(enemyHealth == 0){
            Debug.Log("Enemy Dyinh");
            die();
        }

    }
    void die(){
         if(isBossEnemy){
          Instantiate(Pickup,transform.position, Quaternion.identity);
            Debug.Log("Medkit sapwns");
        }else{
          killCount++;
            GameObject.Find("VillageQuest").GetComponent<Quest>().tempKills = killCount;
            if (killCount == 4) {
                killCount = 0;
            }


        }
        
        Destroy(gameObject);
    } 
  /*   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
            counter += 1;
        }
        if (counter == 3) {
            Instantiate(Pickup, transform.position, Quaternion.identity);
            Destroy(gameObject);
            killCount++;
            GameObject.Find("VillageQuest").GetComponent<Quest>().tempKills = killCount;
            if (killCount == 4) {
                killCount = 0;
            }
        }
    } */
}
