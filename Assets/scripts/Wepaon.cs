using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wepaon : MonoBehaviour
{

    public float offset;

    public GameObject projectile;
    public GameObject shotPoint;
    public GameObject shootPointTwo;

    public int currentAmmo = 5;
    public TextMeshProUGUI ammoText;
    public int maxAmmo;
    public float reloadTime;
    private bool isClicked = true;



    private float timeBtwShots;
    public float startTimeBtwShots;

    public float speed;


    void Reload()
    {
        currentAmmo = maxAmmo;
        isClicked = true;
    }

    private void Update()
    {

        if (currentAmmo == 0)
        {
            isClicked = false;
            Invoke("Reload", 1);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            isClicked = false;
            Invoke("Reload", 1);
        }


        ammoText.text = currentAmmo.ToString() + "/" + maxAmmo.ToString();

        Vector3 diffrence = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(diffrence.y, diffrence.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);

        if (timeBtwShots <= 0)
        {

            if(isClicked == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    currentAmmo -= 1;

                    if (currentAmmo < maxAmmo)
                    {
                        Shoot();
                    }



                    timeBtwShots = startTimeBtwShots;
                }
            }


            
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }





        void Shoot()
        {

            if(shotPoint.activeSelf)
            {
            GameObject SpawnBulletOne = Instantiate(projectile, shotPoint.transform.position, shotPoint.transform.rotation);
            SpawnBulletOne.GetComponent<Rigidbody2D>().AddForce(transform.right * speed);

                
            }

            if(shootPointTwo.activeSelf)
            {
            GameObject SpawnBulletTwo = Instantiate(projectile, shootPointTwo.transform.position, shootPointTwo.transform.rotation);
            SpawnBulletTwo.GetComponent<Rigidbody2D>().AddForce(transform.right * speed);
                
            }


            
        }
    }

    
}
