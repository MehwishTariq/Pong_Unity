using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Transform pad;

    private float speed = 4.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        pad = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {        
        pad.Translate(0f, Input.GetAxis(pad.tag) * speed * Time.deltaTime,0f);
    }
      
}
