using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Vector3 spawnPosition;

    public GameObject[] obstacles;
    public GameObject powerup;

    private void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerMovement>().gameOver)
        {
            CancelInvoke("SpawnObstacles");
            CancelInvoke("SpawnPowerUp");
        }
    }
    void Start()
    {
        InvokeRepeating("SpawnObstacles", 2f, 5f);
        InvokeRepeating("SpawnPowerUp", 5f, 10f);
    }
    void SpawnPowerUp()
    {
        Instantiate(powerup, new Vector3(Random.Range(-10, 10), 7, 0), powerup.transform.rotation);
    }

    void SpawnObstacles()
    {
        int randomNum = Random.Range(0, 3);


        Instantiate(obstacles[randomNum], new Vector3(Random.Range(-10, 10), Random.Range(4, 8), 0), obstacles[randomNum].transform.rotation);

    }

}
