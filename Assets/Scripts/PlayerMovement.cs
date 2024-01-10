using UnityEngine;
/*using System.Collections;
using System.Collections.Generic;
using UnityEditor;*/

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rbody;
    Vector2 inputs;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        PlayAnimations();
    }
    void Move()
    {
        inputs = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rbody.velocity = inputs*speed*Time.deltaTime;
    }
    void PlayAnimations()
    {
        return;
    }
}
