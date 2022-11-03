using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

  private bool isGrounded = false;
  private bool collideLeft = false;
  private bool collideRight = false;
  private float distanceFromGroundToJump = .025f;

  // The corners of the 
  [SerializeField]
  private GameObject topLeft, topRight, bottomRight, bottomLeft;

  // The x and y offsets are how far from the center the corners of the boxcollider are
  private float xOffset, yOffset; 

  void Start() {
    BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
    xOffset = boxCollider2D.size.x / 2;
    yOffset = boxCollider2D.size.y / 2;
  }

  void Update() {

    // The x and y position of the players transform
    float x = transform.position.x;
    float y = transform.position.y;

    // The positions of the corners of the boxcollider. 
    // The .02f is so that the player can fit through a 1 block gap
    topLeft.transform.position = new Vector3(x - xOffset, y + yOffset-.02f, 0);
    topRight.transform.position = new Vector3(x + xOffset, y + yOffset-.02f, 0);
    bottomRight.transform.position = new Vector3(x + xOffset, y - yOffset, 0);
    bottomLeft.transform.position = new Vector3(x - xOffset, y - yOffset, 0);

    // Raycast from the corners checking the sides and bottom
    RaycastHit2D bottomRightDown = Physics2D.Raycast(bottomRight.transform.position, Vector2.down,
        distanceFromGroundToJump);
    RaycastHit2D bottomRightRight = Physics2D.Raycast(bottomRight.transform.position, 
        Vector2.right, .025f);

    RaycastHit2D bottomLeftDown = Physics2D.Raycast(bottomLeft.transform.position, Vector2.down,
        distanceFromGroundToJump);
    RaycastHit2D bottomLeftLeft = Physics2D.Raycast(bottomLeft.transform.position, Vector2.left,
        .025f);

    RaycastHit2D topLeftLeft = Physics2D.Raycast(topLeft.transform.position, Vector2.left, .025f);

    RaycastHit2D topRightRight = Physics2D.Raycast(topRight.transform.position, Vector2.right, 
        .025f);

    // If there is a collision on the bottom, isGrounded is true
    if (bottomRightDown || bottomLeftDown) {
      this.isGrounded = true;
    }
    else {
      this.isGrounded = false;
    }

    // If there is a collision on the right, collideRight is true
    if (bottomRightRight || topRightRight) {
      this.collideRight = true;
    }
    else {
      this.collideRight = false;
    }

    // If there is a collision on the left, collideLeft = true;
    if (bottomLeftLeft || topLeftLeft) {
      this.collideLeft = true;
    }
    else {
      this.collideLeft = false;
    }


  }

  // Begin Getters and Setters
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

  public float getDistanceFromGroundToJump() {
    return this.distanceFromGroundToJump;
  }

  public void setDistanceFromGroundToJump(float distanceFromGroundToJump) {
    this.distanceFromGroundToJump = distanceFromGroundToJump;
  }
  // End Getters and Setters
}
