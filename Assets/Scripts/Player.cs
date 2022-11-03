using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour { 

    // PlayerMovement Variables
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpPower = 5f;
    // End PlayerMovement Variables

    // PlayerCollision Variables
    [SerializeField]
    private PlayerCollision playerCollision;
    [SerializeField]
    private float distanceFromGroundToJump = .025f;
    // End PlayerCollision Variables


  // Start is called before the first frame update
  void Start()
  { 
    playerMovement.setMoveSpeed(moveSpeed); // Sets the moveSpeed in the PlayerMovement script
    playerMovement.setJumpPower(jumpPower); // Sets the jumpPower in the PlayerMovement script
    // Sets distance from ground to be able to jump
    playerCollision.setDistanceFromGroundToJump(distanceFromGroundToJump); 
  }

  // Update is called once per frame
  void Update()
  { 
    // If isGrounded is different in the two scripts set playerMovement's to playerCollision's
    if(playerCollision.getIsGrounded() != playerMovement.getIsGrounded()) {
      playerMovement.setIsGrounded(playerCollision.getIsGrounded());
    }

    // If collideLeft is different in the two scripts set playerMovement's to playerCollision's
    if(playerCollision.getCollideLeft() != playerMovement.getCollideLeft()) {
      playerMovement.setCollideLeft(playerCollision.getCollideLeft());
    }

    // If collideRight is different in the two scripts set playerMovement's to playerCollision's
    if(playerCollision.getCollideRight() != playerMovement.getCollideRight()) {
      playerMovement.setCollideRight(playerCollision.getCollideRight());
    }
  }

  


}
