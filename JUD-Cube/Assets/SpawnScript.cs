using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject star;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1f, 3f);
        InvokeRepeating("SpawnStar", 3f, 5f);
    }

    void Spawn()
    {
        Instantiate(enemy, enemy.transform);
        
    }
    void SpawnStar()
    {
        Instantiate(star, new Vector3(Random.Range(-6, 6), 8, 0), transform.rotation);
    }
}
