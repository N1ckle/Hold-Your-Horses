using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class acts as a manager for a player.
public class Player : MonoBehaviour { 

    [SerializeField]
    private Animator animator;

    [Header("PlayerMovement Variables")]
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpPower = 5f;
    // End PlayerMovement Variables

    [Header("CharacterCollision Variables")]
    [SerializeField]
    private CharacterCollision characterCollision;
    [SerializeField]
    private float distanceFromGroundToJump = .025f;
    // End PlayerCollision Variables

    [Header("BulletSpawner Variables")]
    [SerializeField]
    private BulletSpawner bulletSpawner;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject muzzleFlash;
    [SerializeField]
    private float bulletSpeed = 10f;
    [SerializeField]
    private KeyCode shootKey = KeyCode.J;
    // End BulletSpawner Variables

    [Header("Health Variables")]
    [SerializeField]
    private HealthManager healthManager;
    [SerializeField]
    private int health = 3;

  // Start is called before the first frame update
  void Start()
  { 
    playerMovement.setMoveSpeed(moveSpeed); // Sets the moveSpeed in the PlayerMovement script
    playerMovement.setJumpPower(jumpPower); // Sets the jumpPower in the PlayerMovement script
    playerMovement.setAnimator(animator); // Sets the animator
    // Sets distance from ground to be able to jump
    characterCollision.setDistanceFromGroundToJump(distanceFromGroundToJump); 
    bulletSpawner.setBullet(bullet); // Sets the bullet to be shot to the one given to this script
    bulletSpawner.setBulletSpeed(bulletSpeed); // Sets bullet speed
    bulletSpawner.setAnimator(animator); // Sets the animator
    bulletSpawner.setMuzzleFlash(muzzleFlash); // Sets the muzzleflash gameobject
    bulletSpawner.setShootKey(shootKey); // Sets the Keybind for shooting

    healthManager.setHealth(health); // Sets the health
  }

  // Update is called once per frame
  void Update()
  { 
    // If isGrounded is different in the two scripts set playerMovement's to playerCollision's
    if(characterCollision.getIsGrounded() != playerMovement.getIsGrounded()) {
      playerMovement.setIsGrounded(characterCollision.getIsGrounded());
    }

    // If collideLeft is different in the two scripts set playerMovement's to playerCollision's
    if(characterCollision.getCollideLeft() != playerMovement.getCollideLeft()) {
      playerMovement.setCollideLeft(characterCollision.getCollideLeft());
    }

    // If collideRight is different in the two scripts set playerMovement's to playerCollision's
    if(characterCollision.getCollideRight() != playerMovement.getCollideRight()) {
      playerMovement.setCollideRight(characterCollision.getCollideRight());
    }

    // If the direction that the player is facing is different than the direction bullets should 
    // move change the direction that bullets should move.
    if(playerMovement.getFacingRight() != bulletSpawner.getMoveRight()) {
      bulletSpawner.setMoveRight(playerMovement.getFacingRight());
    }

    // If the bullet spawner says not to move then set the player not to move, and the other
    // way around too
    if(bulletSpawner.getMovable() != playerMovement.getMovable()) {
      playerMovement.setMovable(bulletSpawner.getMovable());
    }
  }

  


}
