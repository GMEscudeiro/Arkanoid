using UnityEngine;
using System;

public class PlayerControls : MonoBehaviour
{
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public float speed = 10.0f;
    public float boundX = 9.0f;
    private Rigidbody2D rb2d;

    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        var vel = rb2d.linearVelocity;
        if(Input.GetKey(moveLeft)){
            vel.x = -speed;
        }
        else if(Input.GetKey(moveRight)){
            vel.x = speed;
        }
        else{
            vel.x = 0;
        }

        rb2d.linearVelocity = vel;

        var pos = transform.position;
        if (pos.x + 0.8f > boundX){
            pos.x = boundX - 0.8f; 
        }
        else if (pos.x - 0.8f< -boundX){
            pos.x = -boundX + 0.8f;
        }

        transform.position = pos;
    }
}
