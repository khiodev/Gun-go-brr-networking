using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth = 100;
    public EnemyHealthBar healthBar;
    public GameObject slider;

    public float speed = 5;
    private Transform target;


    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {

        if (Vector2.Distance(transform.position, target.position) < 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            slider.SetActive(true);
            TakeDamage(20);
        }
    }


}
