using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class bg : MonoBehaviour
{
    public float bgSpeed;
    float bgPositionX;
    float bg1PositionX;

    void Start()
    {
        bgPositionX = transform.position.x;
        bg1PositionX = GameObject.Find("bg1_0 (1)").transform.position.x;

    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + bgSpeed, transform.position.y, transform.position.z);
        if (transform.position.x < (bg1PositionX * -1f))
        {
            transform.position = new Vector3(bg1PositionX, transform.position.y, transform.position.z);

        }
    
    }

}
