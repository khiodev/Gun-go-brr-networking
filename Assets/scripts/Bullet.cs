using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float lifeTime;
    public GameObject effect;


    private void Start()
    {
     

        Invoke("DestoryProjetile", lifeTime);
    }


    void DestoryProjetile()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {


         GameObject SpawnPartical = Instantiate(effect, transform.position, transform.rotation);

         Destroy(gameObject);
         Destroy(SpawnPartical, 3);


    }
}
