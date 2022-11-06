using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    
  private Rigidbody2D player;
  private float moveSpeed = 5f;
  private float jumpPower = 5f;
  private bool isGrounded = false; // If the player is grounded
  private bool collideLeft = false; // If the player is collided with something on the left
  private bool collideRight = false; // If the player is collided with something on the right
  private Animator animator; // The players animator
  private bool facingRight = true; // If the player is facing right
  private bool movable = true; // If the player can move

  void Start() {
    player = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
  }

  void Update() {

    if(movable) { // If the player is capable of moving then update movement, otherwise don't

      jump(); // Makes the player jump if it is allowed

      // Sets variables for the players movement animations
      animator.SetBool("Grounded", isGrounded);
      animator.SetFloat("yVelocity", player.velocity.y);
      
      Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
      
      // If the player tries to move a direction that they have collided don't let them
      if(movement.x < 0 && collideLeft == true) {
        movement.x = 0;
      }
      else if(movement.x > 0 && collideRight == true) {
        movement.x = 0;
      }

      // More animation variables
      if (!isGrounded){ // if in the air, the running animation wont play
        animator.SetFloat("Speed", 0);
      }
      else if (isGrounded) {
        animator.SetFloat("Speed", Mathf.Abs(movement.x));
      }
      
      transform.position += movement * Time.deltaTime * moveSpeed; // Moves Player
      
      //turn that character to face the direction of movement
      if((Input.GetAxis("Horizontal") < 0 && transform.localScale.x > 0) ||
        (Input.GetAxis("Horizontal") > 0 && transform.localScale.x < 0)) {
          transform.localScale *= new Vector2(-1,1);
          // Sets the facing right value equal to the direction that the player is facing
          if(facingRight) {
            this.facingRight = false;
          }
          else {
            this.facingRight = true;
          }
        }
     }
    
  }

  private void jump() {
    if (Input.GetButtonDown("Jump")  && isGrounded == true){
      player.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
    }
  }

  // Begin Getters and Setters

  public float getMoveSpeed() {
    return this.moveSpeed;
  }

  public void setMoveSpeed(float moveSpeed) {
    this.moveSpeed = moveSpeed;
  }

  public float getJumpPower() {
    return this.jumpPower;
  }

  public void setJumpPower(float jumpPower) {
    this.jumpPower = jumpPower;
  }

  public bool getIsGrounded() {
    return this.isGrounded;
  }

  public void setIsGrounded(bool isGrounded) {
    this.isGrounded = isGrounded;
  }

  public bool getCollideRight() {
    return this.collideRight;
  }

  public void setCollideRight(bool collideRight) {
    this.collideRight = collideRight;
  }

  public bool getCollideLeft() {
    return this.collideLeft;
  }

  public void setCollideLeft(bool collideLeft) {
    this.collideLeft = collideLeft;
  }

  public bool getFacingRight() {
    return this.facingRight;
  }

  public void setAnimator(Animator animator) {
    this.animator = animator;
  }

  public bool getMovable() {
    return this.movable;
  }

  public void setMovable(bool movable) {
    this.movable = movable;
  }
  // End Getters and Setters


}
