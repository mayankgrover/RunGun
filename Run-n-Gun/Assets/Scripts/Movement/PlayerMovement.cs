using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public UltimateJoystick joystick;
    public GameObject Player;

    public float PlayerSpeed;
    public float JumpHeight;

    private Rigidbody2D ridigbody2D;

    private bool isTouchingPlatform;
    private bool didJump;

    public void PlayerJumped()
    {
        didJump = true;
    }

    void Awake()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<UltimateJoystick>();
        if (joystick == null) {
            Debug.LogError("Could not find joystick!");
            DestroyObject(this);
        }

        ridigbody2D = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        joystick.ResetPosition();
	}

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform") {
            isTouchingPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform") {
            isTouchingPlatform = false;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    if (joystick.JoystickPosition != Vector2.zero)
	    {
	        //Debug.Log("Joystick position: " + joystick.JoystickPosition);
	        Vector3 target = Player.transform.position;
	        if (IsMovingLeft()) {
	            target = Vector3.left;
	        } else if (IsMovingRight()) {
	            target = Vector3.right;
	        }

	        //Player.transform.position = Vector3.MoveTowards(Player.transform.position, target, Time.deltaTime*PlayerSpeed);
	        ridigbody2D.AddForce(target*PlayerSpeed, ForceMode2D.Force);
	    } else if(isTouchingPlatform && !DidPlayerJump()) {
	        ridigbody2D.velocity = Vector2.zero;
	    }

	    if (DidPlayerJump()) {
	        didJump = false;
            ridigbody2D.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            Debug.Log("Applying jump force!");
	    }
	}

    private bool DidPlayerJump()
    {
        return didJump;
    }

    private bool IsMovingLeft()
    {
        return joystick.JoystickPosition.x < 0;
    }

    private bool IsMovingRight()
    {
        return joystick.JoystickPosition.x > 0;
    }
}
