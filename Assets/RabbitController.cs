using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour {
    Rigidbody rb;
    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        UpdateMovement();
    }

    void UpdateMovement() {
        var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Debug.Log(input.x);
        rb.velocity = transform.forward*input.z;
        rb.angularVelocity = new Vector3(0, input.x*10, 0);
    }
}