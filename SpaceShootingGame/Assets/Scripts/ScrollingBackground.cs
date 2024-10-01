using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    /*public float speed;
    [SerializeField]
    private Renderer bgRenderer;

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2 (speed*Time.deltaTime, 0);
    }*/
    public float horizontal_speed = 0.2f;
    public float vertical_speed = 0.2f;

    private Renderer re;

    void Start()
    {
        re=GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 offset = new Vector2 (Time.time *horizontal_speed, Time.time *vertical_speed);
        re.material.mainTextureOffset=offset;
    }
}
