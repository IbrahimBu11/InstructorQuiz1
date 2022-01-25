using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    public GameObject[] blocks;
    private int randomSlidernum;
    // Start is called before the first frame update
    void Start()
    {
        randomSlidernum = Random.Range(0, 5);
        blocks[randomSlidernum].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      // transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -2)
        {
            blocks[randomSlidernum].SetActive(true);
            Destroy(gameObject);            
        }
    }
}
