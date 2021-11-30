using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLateral : MonoBehaviour
{
    public float speed = 5;
    private PlayerController playerControllerScript;
    private float LimX = 14;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.Translate(Vector3.right * Time.deltaTime * speed);
       

        if (transform.position.x > LimX)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < -LimX)
        {
            Destroy(gameObject);
        }
    }
}
