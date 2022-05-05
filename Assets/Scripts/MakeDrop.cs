using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDrop : MonoBehaviour
{
    public GameObject Pickup;
    public void rewardDrop() {
        Instantiate(Pickup, transform.position, Quaternion.identity);
    }
}
