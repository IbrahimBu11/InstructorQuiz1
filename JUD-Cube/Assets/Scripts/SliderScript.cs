using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderScript : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    private Quaternion InititalPosition, currentRotation, targetRotation;
    private int stars = 0,health = 100;
    private bool gameOver = false;

    public GameObject shutterEffect;
    public GameObject gameOverUI;

    public Slider slide;
    public Text starsUI;
    public float initialDeltaTime;

    [SerializeField]
    private float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        InititalPosition = transform.rotation;
        initialDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        starsUI.text = "Score : " + stars; 
        slide.value = health;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        InBounds();
        Move();
    }
    void Move()
    {
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
        
    }
    void InBounds()
    {
        if (transform.position.x > 6)
            transform.position = new Vector3(6, 2, 0);
        if (transform.position.x < -6)
            transform.position = new Vector3(-6, 2, 0);
    }
    IEnumerator Cooleffect()
    {
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime *= Time.timeScale;
        yield return new WaitForSeconds(.7f);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = initialDeltaTime;
    }
    IEnumerator ShutterEffect()
    {
        shutterEffect.SetActive(true);
        yield return new WaitForSeconds(.3f);
        shutterEffect.SetActive(false);

    }
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine("Cooleffect");
        
        ReduceHealth();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("star")) { 
            stars += 1;
            Destroy(other.gameObject);
        }


    }
    void ReduceHealth()
    {
        for (int i = 0; i < 5; i++)
        {
            StartCoroutine("ShutterEffect");
        }
        health -= 10;
        if (health <= 0) { 
            gameOver = true;
            gameOverUI.SetActive(true);
            StartCoroutine(waitforSeconds(2));

        }
    }
    IEnumerator waitforSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0);
    }
}
