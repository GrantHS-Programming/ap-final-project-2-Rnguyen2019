using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidBodyComponent;

    //public CharacterController controller;
    [Header("Movement")]
    public float movementSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    bool grounded;
    bool doubleJump;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    [SerializeField] private int bananas;
    public float multiplierValue;

    private static Player _instance;
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Player is null.");
            }
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    Vector3 moveDirection;

    //Rigidbody Constrain;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
        rigidBodyComponent.freezeRotation = true;
        bananas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight);
        if (grounded)
        {
            doubleJump = true;
        }

            MyInput();
            SpeedControl();

        if (grounded)
        {
            rigidBodyComponent.drag = groundDrag;
        }
        else
        {
            rigidBodyComponent.drag = 0;
        }

        UImanager.Instance.UpdateBananaText(bananas);
    }

    private void FixedUpdate()
    {
        if (!Input.GetMouseButton(1))
        {
            MovePlayer();
        }
        
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //doubleJump = true;
        if (Input.GetKey(jumpKey) && readyToJump && (grounded || doubleJump))
        {
            if (doubleJump)
            {
                doubleJump = false;
            }
            readyToJump = false;

            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
        {
            rigidBodyComponent.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rigidBodyComponent.AddForce(moveDirection.normalized * movementSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rigidBodyComponent.velocity.x, 0f, rigidBodyComponent.velocity.z);

        if (flatVel.magnitude > movementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * movementSpeed;
            rigidBodyComponent.velocity = new Vector3(limitedVel.x, rigidBodyComponent.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rigidBodyComponent.velocity = new Vector3(rigidBodyComponent.velocity.x, 0f, rigidBodyComponent.velocity.z);

        rigidBodyComponent.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    public void addBanana()
    {
        bananas += (int)(1 * multiplierValue);
    }
}

