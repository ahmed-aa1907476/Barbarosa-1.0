using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRigidBody;
    public float speed = 10f;
    public float life = 3;

    private void Awake()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
        Destroy(gameObject, life);
    }

    private void Start()
    {
        bulletRigidBody.velocity = transform.forward * speed;
    }

}
