using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourController : MonoBehaviour
{
    public float runSpeed, sprintSpeed;
    public float jumpForce;
    bool isGrounded;
    bool isWallRunning;

    Rigidbody rb;

    float horiz, verti;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        horiz = Input.GetAxisRaw("Horizontal");
        verti = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if(horiz == 0 && verti == 0) return;
        rb.velocity = new Vector3(horiz* runSpeed , rb.velocity.y, verti* runSpeed);

    }

    void Jump()
    {
        if(!isGrounded) return;

        isGrounded = false;
        rb.AddForce(transform.up * jumpForce);
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.transform.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other) 
    {
        if(other.transform.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
