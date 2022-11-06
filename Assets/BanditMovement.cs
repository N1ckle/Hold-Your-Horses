using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditMovement : MonoBehaviour {
  
  private Rigidbody2D bandit;
  private float moveSpeed;
  private bool collideLeft = false; // If the bandit is collided with something on the left
  private bool collideRight = false; // If the bandit is collided with something on the right
  private Animator animator; // The bandit's animator
  private bool facingRight = true; // If the bandit is facing right
  private bool movable = true; // If the bandit can move
  private bool shouldMove = true; // If the bandit should move

  void Start() {
    bandit = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
  }

  
  void Update() {
    
    // If the bandit is in a state that it can move, make it move
    if(movable && shouldMove) {
      Vector3 movement = new Vector3(1, 0f, 0f);

      // If the bandit is colliding with the wall and facing it do not allow movement
      if(facingRight && collideRight) {
        movement.x = 0;
        facingRight = false;
      }
      else if(!facingRight && collideLeft) {
        movement.x = 0;
        facingRight = true;
      }

      // Set the animator to do the correct animation
      animator.SetFloat("speed", movement.x);

      if(facingRight) {
        transform.position += movement * moveSpeed * Time.deltaTime;
        transform.localScale = new Vector2(1,1);
      }
      else if(!facingRight) {
        transform.position -= movement * moveSpeed * Time.deltaTime;
        transform.localScale = new Vector2(-1,1);
      }

    }
  }

  // Begin Getters and Setters
  public float getMoveSpeed() {
    return this.moveSpeed;
  }

  public void setMoveSpeed(float moveSpeed) {
    this.moveSpeed = moveSpeed;
  }

  public bool getCollideLeft() {
    return this.collideLeft;
  }

  public void setCollideLeft(bool collideLeft) {
    this.collideLeft = collideLeft;
  }

  public bool getCollideRight() {
    return this.collideRight;
  }

  public void setCollideRight(bool collideRight) {
    this.collideRight = collideRight;
  }

  public bool getMovable() {
    return this.movable;
  }

  public void setMovable(bool movable) {
    this.movable = movable;
  }

  public bool getFacingRight() {
    return this.facingRight;
  }
  // End Getters and Setters
}
