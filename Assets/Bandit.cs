using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : MonoBehaviour {
  
  [SerializeField]
  private Animator animator;

  [Header("BanditMovement Variables")]
    [SerializeField]
    private BanditMovement banditMovement;
    [SerializeField]
    private float moveSpeed = 5f;

  [Header("BulletSpawner Variables")]
    [SerializeField]
    private BulletSpawner bulletSpawner;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject muzzleFlash;
    [SerializeField]
    private float bulletSpeed = 10f;

  [Header("CharacterCollision Variables")]
    [SerializeField]
    private CharacterCollision characterCollision;
  
  void Start() {
    banditMovement.setMoveSpeed(moveSpeed);

    bulletSpawner.setBullet(bullet); // Sets the bullet to be shot to the one given to this script
    bulletSpawner.setBulletSpeed(bulletSpeed); // Sets bullet speed
    bulletSpawner.setAnimator(animator); // Sets the animator
    bulletSpawner.setMuzzleFlash(muzzleFlash); // Sets the muzzleflash gameobject
    
    bulletSpawner.setShootKey(KeyCode.K); // TODO remove this. Only for testing purposes
  }

  
  void Update() {
    // If the bullet spawner says not to move then set the bandit not to move, and the other
    // way around too
    if(bulletSpawner.getMovable() != banditMovement.getMovable()) {
      banditMovement.setMovable(bulletSpawner.getMovable());
    }

    // If the direction that the player is facing is different than the direction bullets should 
    // move change the direction that bullets should move.
    if(banditMovement.getFacingRight() != bulletSpawner.getMoveRight()) {
      bulletSpawner.setMoveRight(banditMovement.getFacingRight());
    }

    // If collideLeft is different in the two scripts set banditMovement's to characterCollision's
    if(characterCollision.getCollideLeft() != banditMovement.getCollideLeft()) {
      banditMovement.setCollideLeft(characterCollision.getCollideLeft());
    }

    // If collideRight is different in the two scripts set banditMovement's to characterCollision's
    if(characterCollision.getCollideRight() != banditMovement.getCollideRight()) {
      banditMovement.setCollideRight(characterCollision.getCollideRight());
    }
  }
}
