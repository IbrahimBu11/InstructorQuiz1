using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    [SerializeField]
    private float scaleSpeed = 10;
    [SerializeField]
    private float rotateSpeed = 50;

    private Vector3 initialScale, currentScale, maximumScale;

    private Color[] colors = {Color.blue, Color.red, };
    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        maximumScale = new Vector3(5, 5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        currentScale = transform.localScale;

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Rotation();

        
        Scale();
    }
    
    void Rotation()
    {
        transform.Rotate(Vector3.up * horizontal * rotateSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * vertical * rotateSpeed * Time.deltaTime);
    }
    void Scale()
    {
        if (Input.GetKey(KeyCode.Space))
        {
          if (!CompareVector3s(currentScale,maximumScale))
               transform.localScale += Vector3.one * Time.deltaTime * scaleSpeed;               
        }
        else if (!CompareVector3s(currentScale, initialScale))
            transform.localScale -= Vector3.one * Time.deltaTime * scaleSpeed;
    }
    bool CompareVector3s(Vector3 one, Vector3 two)
    {
        int x = Mathf.CeilToInt(one.x);
        int y = Mathf.CeilToInt(one.y);
        int z = Mathf.CeilToInt(one.z);
        Vector3 oneC = new Vector3(x, y, z);

        int x1 = Mathf.CeilToInt(two.x);
        int y1 = Mathf.CeilToInt(two.y);
        int z1 = Mathf.CeilToInt(two.z);
        Vector3 twoC = new Vector3(x1, y1, z1);

        if (oneC == twoC)
            return true;
        else
            return false;
    }
}
