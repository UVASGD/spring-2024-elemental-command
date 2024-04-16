using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public bool grounded;

    // Footsteps 
    [Header("Wwise Events")]
    public AK.Wwise.Event myFootstep;

    // Wwise
    private bool footstepIsPlaying = false;
    private float lastFootstepTime = 0;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    [SerializeField] private ElementManager em;
    [SerializeField] private float airGravity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        em = FindObjectOfType<ElementManager>();

        // Wwise
        lastFootstepTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.isPaused == false){ //locks player inputs when paused
        // check if on ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f);

        MyInput();
        SpeedControl();
        //handle drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

        //KEEP AN EYE ON THIS IF WE NEED TO DO THIS
        //rb.freezeRotation = true;

        }

    }

    void FixedUpdate()
    {
        MovePlayer();

        if (em.state == ElementManager.Element.Air)
        {
            // rb.useGravity = false;
            rb.AddForce(new Vector3(0, -1.0f, 0) * rb.mass * airGravity);  
        }
    }

    private void MyInput()
    {
        if (Pause.isPaused == false){ //locks jump input while paused
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
        }

    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on ground
        if(grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);

        // footstep sounds
        if ((!footstepIsPlaying) && (horizontalInput != 0 || verticalInput != 0)) {
            myFootstep.Post(gameObject);
            lastFootstepTime = Time.time;
            footstepIsPlaying = true;
        }

        else{
            if (moveSpeed >1){
                if (Time.time - lastFootstepTime > 60/moveSpeed*Time.deltaTime){
                footstepIsPlaying = false;
                }
            }
        }

        }else{
        //in air
            rb.AddForce(moveDirection.normalized * moveSpeed * airMultiplier * 10f, ForceMode.Force);
        }

  

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if too fast
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        //reset y
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

}
