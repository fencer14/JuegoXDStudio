using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody rb;
    public float speedWalk = 2f;
    public float tmouseVer = Input.GetAxis("Vertical");
    public float tmouseHor = Input.GetAxis("Horizontal");

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        float mouseVer = Input.GetAxis("Vertical");
        float mouseHor = Input.GetAxis("Horizontal");
        Vector3 inputPepa = new Vector3(mouseHor, 0, mouseVer);
        rb.velocity = inputPepa * speedWalk * Time.deltaTime;
    }
}
