using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;

    bool isSprinting;
    bool isJumping;
    bool isGrounded;

    public float currentSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float airSpeed;

    float horizontalAxis;
    float verticalAxis;
    [SerializeField] float jumpForce;

    [SerializeField] float distToGround;
    [SerializeField] private LayerMask groundCheckMask;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift)) isSprinting = true;
        else isSprinting = false;

        
        if (Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
        }
        else isJumping = false;
    }

    private void FixedUpdate()
    {
        GroundCheck();
        SetSpeed();


        rb.velocity = transform.TransformDirection(new Vector3(horizontalAxis * currentSpeed, rb.velocity.y, verticalAxis * currentSpeed));

        
        if (isJumping && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isJumping = false;
        } 


    }


    
    void SetSpeed()
    {
        if (!isGrounded)
        {
            currentSpeed = airSpeed;
            return;
        }
        if (isSprinting) currentSpeed = sprintSpeed;
        else currentSpeed = walkSpeed;
    }
    
    void GroundCheck()
    {
        //Shoots Raycast down to Check if Player is Grounded
        if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f, groundCheckMask))
        {
            isGrounded = true;
            //Debug.Log("Is grounded");
        }

        else
        {
            isGrounded = false;
            isJumping = false;
            //Debug.Log("Is not grounded");
        }

    }
}
