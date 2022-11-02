using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement {
    
  private Transform player; // The GameObject that this should move
  private float moveSpeed;
  private float jumpPower;
  private bool isGrounded;
  private bool collideLeft;
  private bool collideRight;

  // Sets up this script with all of the variables from the Player class
  public PlayerMovement(Transform player, float moveSpeed, float jumpPower, bool isGrounded, 
      bool collideLeft, bool collideRight) {
        this.moveSpeed = moveSpeed;
        this.jumpPower = jumpPower;
        this.isGrounded = isGrounded;
        this.collideLeft = collideLeft;
        this.collideRight = collideRight;
      }

  // This class is used to pass all varaibles to the PlayerMovement script
  public void giveVariables(bool isGrounded, bool collideLeft, bool collideRight) {
    this.isGrounded = isGrounded;
    this.collideLeft = collideLeft;
    this.collideRight = collideRight;
  }

  // Updates the players movement
  public void update() {

    jump(); // Makes the player jump if it is allowed
    
    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
    
    // If the player tries to move a direction that they have collided don't let them
    //if(movement.x < 0 && collideLeft == true) {
      //movement.x = 0;
    //}
    //else if(movement.x > 0 && collideRight == true) {
      //movement.x = 0;
    //}
    
    player.position += movement * Time.deltaTime * moveSpeed;
    

    //turn that character to face the direction of movement
    if((Input.GetAxis("Horizontal") < 0 && player.transform.localScale.x > 0) ||
        (Input.GetAxis("Horizontal") > 0 && player.transform.localScale.x < 0)) {
            player.transform.localScale *= new Vector2(-1,1);
        }

    
  }

  private void jump() {
    
    if (Input.GetButtonDown("Jump")  && isGrounded == true){
      player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);


        
    }
    
  }


}
