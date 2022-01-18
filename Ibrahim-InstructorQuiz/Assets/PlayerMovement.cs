using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float horizontal;
    public float speed = 10f;
    public int health = 100;

    public Slider hp;
    public GameObject text;

    private bool canShoot = true;
    public bool gameOver = false;

    public GameObject bullet;
    public Transform shooter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hp.value = health;

        horizontal = Input.GetAxis("Horizontal");
        Movement();
        if(Input.GetKey(KeyCode.Space) && canShoot)
        StartCoroutine(Shoot());
        if (gameOver)
        {
            Time.timeScale = 0.5f;
            text.SetActive(true);
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }

        
    }
    void Movement()
    {
        KeepInBounds();
        transform.Translate(Vector3.right * horizontal * Time.deltaTime * speed);
    }
    void KeepInBounds()
    {
        if (transform.position.x > 13)
            transform.position = new Vector3(13, 0, 0);
        if (transform.position.x < -13)
            transform.position = new Vector3(-13, 0, 0);
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        Instantiate(bullet, shooter.position, bullet.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        canShoot = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Balls")
        {
            TakeDamage();
        }
    }
    void TakeDamage()
    {
        health -= 20;
        if(health <= 0)
        {
            gameOver = true;

        }
    }
    //void Shoot()
    //{
    //    Instantiate(bullet, shooter.position, bullet.transform.rotation);
    //}

}



