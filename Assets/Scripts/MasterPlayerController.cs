using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;
using System;

public class MasterPlayerController : MonoBehaviour
{
    public Transform midlePoint;
    public float speed;
    public Transform crumb;
    [SerializeField] Light2D lightSpot;
    Rigidbody rbody;
    Vector2 inputs;

    private void Start()
    {
        lightSpot = GetComponentInChildren<Light2D>();
        rbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        RotateLightAround();
    }
    void RotateLightAround()
    {
        inputs = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputs = inputs.normalized;
        this.gameObject.transform.RotateAround(midlePoint.position, Vector3.fwd, inputs.x * speed * Time.deltaTime);
    }
}