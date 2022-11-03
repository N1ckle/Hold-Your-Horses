using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    
  private Rigidbody2D player;
  private float moveSpeed = 5f;
  private float jumpPower = 5f;
  private bool isGrounded = false;
  private bool collideLeft = false;
  private bool collideRight = false;

  void Start() {
    player = GetComponent<Rigidbody2D>();
  }

  void Update() {

    jump(); // Makes the player jump if it is allowed
    
    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
    
    // If the player tries to move a direction that they have collided don't let them
    if(movement.x < 0 && collideLeft == true) {
      movement.x = 0;
    }
    else if(movement.x > 0 && collideRight == true) {
      movement.x = 0;
    }
    
    transform.position += movement * Time.deltaTime * moveSpeed;
    

    //turn that character to face the direction of movement
    if((Input.GetAxis("Horizontal") < 0 && transform.localScale.x > 0) ||
      (Input.GetAxis("Horizontal") > 0 && transform.localScale.x < 0)) {
        transform.localScale *= new Vector2(-1,1);
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

  // End Getters and Setters


}
