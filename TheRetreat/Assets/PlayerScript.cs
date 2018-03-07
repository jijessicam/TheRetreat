using System.Collections;using System.Collections.Generic;using UnityEngine;public class PlayerScript : MonoBehaviour {    private Rigidbody rb;    public float movementSpeed = 5.0f;    public float turningSpeed = 100.0f;    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        transform.Rotate(0, horizontal, 0);
        transform.Translate(0, 0, vertical);
    }}