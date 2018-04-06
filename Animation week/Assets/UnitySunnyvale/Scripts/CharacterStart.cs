using UnityEngine;
using System.Collections;

public class CharacterStart : MonoBehaviour
{
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.

	private bool _jump = false;				// Condition for whether the player should jump.	
    private bool _grounded = false;			// Whether or not the player is grounded.
	private Animator _animator;				// Reference to the player's animator component.
    private  bool _gameStarted = false;


    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    //the moment our character hits the ground we set the grounded to true 
    void OnCollisionEnter2D(Collision2D hit)
    {
        _grounded = true;
    }

    //the game start but we set the value of gamestarted to false to set our character s
    void Start()
    {
        _gameStarted = false;
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            // If the jump button is pressed and the player is grounded and the character is running forward then the player should jump.
            if ((_grounded == true) && (_gameStarted == true))
            {
                _jump = true;
                _grounded = false;
            }
            // if the game is set now to start the character will start to run forward in the FixedUpdate
            else
            {
                _gameStarted = true;
            }

        }
    }


    //everything in the physics we set in the fixupdate 
    void FixedUpdate()
    {
        // if game is started we move character forward...
        if (_gameStarted == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(10, GetComponent<Rigidbody2D>().velocity.y);
        }

        // If jump is set to true we are now adding quickly aforce to push the character up
        if (_jump == true)
        {
            // Add a vertical force to the player.
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

            // We set to false otherwise the ridig2D addforce would keep adding force
            _jump = false;
      }

    }

}
