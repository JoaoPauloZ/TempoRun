using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveSpeedStore;
	public float speedMultiplier;
	public float speedIncreaseMilestone;
	private float speedIncreaseMilestoneStore;
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;

	public float jumpForce;
	public float jumpTime;

	private bool stoppedJumping;
	private bool canDubleJump;

	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;

	private Rigidbody2D myRigidbody;
	//private Collider2D myCollider;

	private Animator myAnimator;

	private float jumpTimeCounter;

	public GameManager theGameManager;

	public AudioSource jumpSound;
	public AudioSource deathSound;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		//myCollider = GetComponent<BoxCollider2D> ();
		myAnimator = GetComponent<Animator> ();
		jumpTimeCounter = jumpTime;
		speedMilestoneCount = speedIncreaseMilestone;

		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;

		stoppedJumping = true;
	}
	
	// Update is called once per frame
	void Update () {

		//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		if (transform.position.x > speedMilestoneCount) {
			speedIncreaseMilestone += speedIncreaseMilestone * speedMultiplier;
			speedMilestoneCount += speedIncreaseMilestone;
			moveSpeed = moveSpeed * speedMultiplier;
			 
		}

		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			if (grounded) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				stoppedJumping = false;
				jumpSound.Play ();
			}
			if (!grounded && canDubleJump) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter = jumpTime;
				canDubleJump = false;
				stoppedJumping = false;
				jumpSound.Play ();
			}
		}

		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0) && !stoppedJumping) {
			if (jumpTimeCounter > 0) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}

		if (grounded) {
			jumpTimeCounter = jumpTime;
			canDubleJump = true;
		}

		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);

	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "KillBox") {
			theGameManager.RestartGame ();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;
			deathSound.Play ();
		}
	}

}
