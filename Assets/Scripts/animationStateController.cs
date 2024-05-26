using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    // Public variables
    public float acceleration = 2.0f;
    public float deceleration = 1.0f;
    public float maxSpeed = 5.0f;
    public float rotationSpeed = 200.0f;
    public float gravity = -9.81f;

    // Private Variables
    private int zVelocityHash;
    private int xVelocityHash;
    private int isMoveHash;
    private int isJumpHash;
    private int isBackHash;
    private int isRightHash;
    private int isLeftHash;
    private float zVelocity = 0.0f;
    private float xVelocity = 0.0f;
    private float yVelocity = 0.0f;
    private bool isGrounded;
    private float jumfForwardForce;
    private bool isRunningSoundPlaying = false;

     Animator animator;
    CharacterController characterController;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        // Get Component Reference
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        //Improve performance, string converted to int data type
        zVelocityHash = Animator.StringToHash("zVelocity");
        xVelocityHash = Animator.StringToHash("xVelocity");
        isMoveHash = Animator.StringToHash("isMove");
        isJumpHash = Animator.StringToHash("isJump");
        isRightHash = Animator.StringToHash("isRight");
        isLeftHash = Animator.StringToHash("isLeft");
        isBackHash = Animator.StringToHash("isBack");
    }

    // Update is called once per frame
    void Update()
    {
        // Catch User Inputs
        bool isForwardPress = Input.GetKey("w");
        bool isBackPress = Input.GetKey("s");
        bool isLeftPress = Input.GetKey("a");
        bool isRightPress = Input.GetKey("d");
        bool isJumpPress = Input.GetKeyDown("space");

        // Check if the character is grounded
        isGrounded = characterController.isGrounded;

        // Forward and backward movement
        if (isForwardPress && zVelocity < 1.0f)
        {
            zVelocity += Time.deltaTime * acceleration;
        }
        if (isBackPress && zVelocity > -1.0f)
        {
            zVelocity -= Time.deltaTime * acceleration;
        }
        // Reduce velocity when free
        if (!isForwardPress && !isBackPress && zVelocity != 0.0f)
        {
            zVelocity = Mathf.MoveTowards(zVelocity, 0.0f, Time.deltaTime * deceleration);
        }

        // Rotate character when pressing "a" or "d"
        if (isLeftPress)
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        if (isRightPress)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Jump logic
        if (isGrounded)
        {
            if (isJumpPress)
            {
                yVelocity = 8;
                jumfForwardForce += zVelocity * Time.deltaTime * 75; // add forword force when jump
                audioManager.PlaySFX(audioManager.jump); // Insert Jump Sound Effect
            }
        }
        else if(yVelocity > 0)
        {
            yVelocity += gravity * Time.deltaTime;
        }
        // Reset jumfForwardForce by decrement from deltaTime
        jumfForwardForce = Mathf.MoveTowards(jumfForwardForce, 0.0f, Time.deltaTime);


        // Update animator parameters
        animator.SetFloat(zVelocityHash, zVelocity);
        animator.SetFloat(xVelocityHash, xVelocity);
        animator.SetBool(isMoveHash, isForwardPress);
        animator.SetBool(isJumpHash, isJumpPress);
        animator.SetBool(isRightHash, isRightPress);
        animator.SetBool(isLeftHash, isLeftPress);
        animator.SetBool(isBackHash, isBackPress);

        // Calculate movement and bind to charactor component
        Vector3 move = new Vector3(0, yVelocity / maxSpeed, jumfForwardForce) * maxSpeed * Time.deltaTime;
        characterController.Move(transform.TransformDirection(move));

        // Play running sound when a movement key is pressed and stop
        bool isMoving = isForwardPress || isBackPress || isLeftPress || isRightPress;
        if (isMoving && isGrounded && !isRunningSoundPlaying)
        {
            audioManager.PlayMusic(audioManager.run);
            isRunningSoundPlaying = true;
        }
        else if ((!isMoving || !isGrounded) && isRunningSoundPlaying)
        {
            audioManager.StopMusic();
            isRunningSoundPlaying = false;
        }   
        Debug.Log(jumfForwardForce + "  " + zVelocity);
    }
}
