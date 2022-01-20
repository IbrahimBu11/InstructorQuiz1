using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    
    private int health = 100;
    private int Ballnum = 0;
    private int damage = 20;

    [SerializeField]
    float reversePush = 5f;

    public bool isBall1 = false;

    public Rigidbody rb;

    public GameObject[] balls;
    public GameObject explosion;
    // Start is called before the first frame update
    private void OnEnable()
    {
        health = 100;
    }
    void Start()
    {
        //To Check Which BallSize is the script attached to
        checkGameObject();
        rb = GetComponent<Rigidbody>();

        //Add random velocity in the start
        rb.velocity = new Vector3(Random.Range(-5, 5), 2, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        //checkGameObject();
        //Destroy gameobject and reset health so prefab is reset
        if (health < 0)
        {
            ResetnKill();
        }

    }
    private void ResetnKill()
    {
        health = 100;
        Destroy(gameObject);
    }
    //take damage and trigger fission
    void takeDamage(int damage)
    {
                
        health -= damage;
        if (health < 0) { 
            if(!isBall1)
            Fission(Ballnum);            
        }

        

    }
    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "environment")
        //{
        //    rb.velocity =  -rb.velocity;
        //}
        if(collision.gameObject.name == "WallDown")
        {
            rb.velocity += Vector3.up * reversePush;
        }
        if (collision.gameObject.name == "RightWall")
        {
            rb.velocity += Vector3.left * reversePush;
        }
        if (collision.gameObject.name == "LeftWall")
        {
            rb.velocity += Vector3.right * reversePush;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //takeDamage(damage);
        if (other.gameObject.name.StartsWith("Bullet")) { 
            if (!isBall1)
            Fission(Ballnum);
        ResetnKill();
        
        Destroy(other.gameObject);
        }
    }
    void checkGameObject()
    {        
        if (gameObject.name.StartsWith("Ball3")) 
        { 
            damage = 20;
            Ballnum = 1;
        }
        if (gameObject.name.StartsWith("Ball2"))  
        {
            damage = 30;
            Ballnum = 0;
        }
        if (gameObject.name.StartsWith("Ball1")) { 
            damage = 50;
            isBall1 = true;            
        }

    }
    void Fission(int Ballnum)
    {
        
        
            for (int i = 0; i < 2; i++)
            {
                Instantiate(balls[Ballnum], transform.position, balls[Ballnum].transform.rotation);
                GameObject ex = Instantiate(explosion, transform.position, explosion.transform.rotation);
                Destroy(ex, 1f);
            }
        
    }
}
