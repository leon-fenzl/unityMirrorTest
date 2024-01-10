using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArtemia : MonoBehaviour
{
    public Camera cam;
    [SerializeField] float speed;
    Rigidbody rbody;
    Vector2 inputs;

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
        rbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        inputs = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rbody.velocity = new Vector3(inputs.x * speed * Time.deltaTime,this.transform.position.y, inputs.y * speed * Time.deltaTime);
    }
}
