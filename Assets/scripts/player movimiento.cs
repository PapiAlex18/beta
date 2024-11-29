using UnityEngine;

public class playermovimiento : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform orientacion;

    public float playerheight = 2.0f;
    public float groundDrag;
    public LayerMask groundMask;
    private bool isGrounded;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    private bool readyToJump;

    private float horizontalinput;
    private float verticalinput;
    private Vector3 moveDirection;
    private Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        Myinput();
        CheckGround();
        Drag();
        SpeedControll();
    }   

    private void FixedUpdate()
    {
        MovePlayer();
    }   

    private void Myinput()
    {
        horizontalinput = Input.GetAxisRaw("Horizontal");
        verticalinput = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.Space) && readyToJump && isGrounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    
    private void MovePlayer()
    {
        moveDirection = orientacion.forward * verticalinput + orientacion.right * horizontalinput;
        if(isGrounded)
        {
        rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);
        }
        else
        {
        rb.AddForce(moveDirection.normalized * speed * airMultiplier, ForceMode.Force);
        }
    }


    private void CheckGround()

    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerheight * 0.5f + 0.2f, groundMask);
    }

    private void Drag()

    {
        if(isGrounded)
        {
        rb.linearDamping = groundDrag;
        }
        else
        {
        rb.linearDamping = 0;
        }

    }

    private void SpeedControll()

    {
        Vector3 flatvelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        if(flatvelocity.magnitude > speed)
        {

            Vector3 limitedVelocity = flatvelocity.normalized * speed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);

        }

    }

    private void Jump()

    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0,rb.linearVelocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()

    {
        readyToJump = true;
    }





}


