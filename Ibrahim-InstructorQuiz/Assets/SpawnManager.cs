using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Vector3 spawnPosition;

    public GameObject[] obstacles;

    private void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerMovement>().gameOver)
            CancelInvoke("SpawnObstacles");
    }
    void Start()
    {
        InvokeRepeating("SpawnObstacles", 2f, 5f);
    }

    void SpawnObstacles()
    {
        int randomNum = Random.Range(0,3);


        Instantiate(obstacles[randomNum], new Vector3(Random.Range(-10,10), Random.Range(4, 8), 0), obstacles[randomNum].transform.rotation);

    }

}
