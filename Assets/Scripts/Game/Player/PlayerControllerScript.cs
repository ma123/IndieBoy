using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {
	#if !UNITY_ANDROID && !UNITY_IOS && !UNITY_BLACKBERRY && !UNITY_WINRT_8_0 && !UNITY_WINRT_8_1
	private GunScript gunScript;
	#endif

	public float maxSpeed = 7f; // max rychlost ktoru moze ziskat hrac na osi x
	public bool facingRight = true; // smer otocenia vpravo true
	// private Animator anim;
	public Rigidbody2D rigidBodyPlayer;

	private bool grounded = false;
	public Transform groundCheck;
	private float groundRadius = 0.2f;
	public LayerMask whatIsGround; 
	public float jumpForce = 400f;

	private bool doubleJump = false;
	private float hInput = 0;

	public AudioClip jumpClip;			// pole audioclip pri skoku

	void Start () {
		Time.timeScale = 1; // po spustenie skriptu timeScale na 1 abz pokracovala hra aj po restarte
		rigidBodyPlayer = GetComponent<Rigidbody2D> ();
		//anim = GetComponent<Animator>();
		#if !UNITY_ANDROID && !UNITY_IOS && !UNITY_BLACKBERRY && !UNITY_WINRT_8_0 && !UNITY_WINRT_8_1
			gunScript = GetComponentInChildren<GunScript>();
        #endif
	}

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		print (grounded);
		//anim.SetBool ("Ground", grounded);

		if (grounded) {
			doubleJump = false;
		}

		//anim.SetFloat ("Vspeed", rigidBodyPlayer.velocity.y);

		/*if (!grounded) {
			return;
		}*/
	
		#if !UNITY_ANDROID && !UNITY_IOS && !UNITY_BLACKBERRY && !UNITY_WINRT_8_0 && !UNITY_WINRT_8_1
			Move(Input.GetAxis ("Horizontal"));
			if(Input.GetKeyDown(KeyCode.Space)) {
			  	  Jump();
			}
			if(Input.GetKeyDown(KeyCode.RightControl)) {
				gunScript.Shoot();
			}
			if(Input.GetKeyDown(KeyCode.RightAlt)) {
				gunScript.ChangeWeapon();
			}
        #else
		  Move (hInput);
        #endif
	}


	/* Jednoskok dvojskok */
	public void Jump () {
		if (grounded || !doubleJump) { // ak je na zemi alebo nie je doublejump
			//anim.SetBool ("Ground", false);

			AudioSource.PlayClipAtPoint(jumpClip, transform.position); // prehranie jump zvuku

			rigidBodyPlayer.AddForce (new Vector2 (0, jumpForce));   // prida v rigidbody Vektor2 y osi silu jumpForce
		
			if (!doubleJump && !grounded) { // ak nieje doublejump a nie je na zemi moze spravit doublejump
				doubleJump = true;
			}
		}
	}
	
	// pohyb po osi x
	public void Move(float moveSpeed) {
		//anim.SetFloat ("Speed", Mathf.Abs (moveSpeed));

		rigidBodyPlayer.velocity = new Vector2 (moveSpeed * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y); 

		if ((moveSpeed > 0) && !facingRight) {
			Flip ();
		} else { 
			if ((moveSpeed < 0) && facingRight) {
				Flip ();
			}
		}
	}

	// otocenie hraca
	private void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void StartMoving(float horizontalInput) {
		hInput = horizontalInput;
	}
}
