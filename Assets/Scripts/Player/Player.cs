using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class acts as a manager for a player.
public class Player : MonoBehaviour { 

    [Header("PlayerMovement Variables")]
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpPower = 5f;
    // End PlayerMovement Variables

    [Header("PlayerCollision Variables")]
    [SerializeField]
    private PlayerCollision playerCollision;
    [SerializeField]
    private float distanceFromGroundToJump = .025f;
    // End PlayerCollision Variables

    [Header("BulletSpawner Variables")]
    [SerializeField]
    private BulletSpawner bulletSpawner;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float bulletSpeed = 10f;
    // End BulletSpawner Variables

  // Start is called before the first frame update
  void Start()
  { 
    playerMovement.setMoveSpeed(moveSpeed); // Sets the moveSpeed in the PlayerMovement script
    playerMovement.setJumpPower(jumpPower); // Sets the jumpPower in the PlayerMovement script
    // Sets distance from ground to be able to jump
    playerCollision.setDistanceFromGroundToJump(distanceFromGroundToJump); 
    bulletSpawner.setBullet(bullet); // Sets the bullet to be shot to the one given to this script
    bulletSpawner.setBulletSpeed(bulletSpeed); // Sets bullet speed
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

    // If the direction that the player is facing is different than the direction bullets should 
    // move change the direction that bullets should move.
    if(playerMovement.getFacingRight() != bulletSpawner.getMoveRight()) {
      bulletSpawner.setMoveRight(playerMovement.getFacingRight());
    }
  }

  


}
