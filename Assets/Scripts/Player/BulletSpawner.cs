using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

  private Animator animator; // The players animator
  private GameObject bullet; // The bullet to be fired
  private float bulletSpeed = 0f;
  private bool moveRight = true; // If the bullet should move right
  private bool canShoot = true; // If the player can shoot
  private GameObject muzzleFlash;
  private bool movable = true; // If the player should be able to move.
  private KeyCode shootKey; // The KeyBind for shooting
  // This is only for a NPC, ignore otherwise
  private bool shouldShoot = false;


  // TODO add a limit to number of times you can shoot
  
  // Start is called before the first frame update
  void Start() {
    
  }

  // Update is called once per frame
  void Update() {
    // ShootKey is for players and shouldShoot is for NPC
    if(Input.GetKeyDown(shootKey) || shouldShoot) {
      // Only shoot if capable of shooting and shooting animation is not in progress already
      if(canShoot && !animator.GetBool("shoot")) {
        
        // This is all of the animation components for the shooting animation
        animator.SetBool("shoot", true);
        Invoke("resetShoot", .4f);
        Invoke("shoot", .2f);
        
        shouldShoot = false; // For use with an npc
        
      }
    }
  }

  // This is all of the code that create each bullet
  private void shoot() {

    this.movable = false; // Dont let the player move

    // If the bullet will be going right then spawn the muzzleflash facing right, otherwise left
    if(moveRight) {
      muzzleFlash.transform.localScale = new Vector2(1,1);
    }
    else{
      muzzleFlash.transform.localScale = new Vector2(-1,1);
    }
    Instantiate(muzzleFlash, transform.position, transform.rotation);

    // Spawn bullet
    GameObject currentBullet = Instantiate(bullet, transform.position, transform.rotation);

    // Set bullet speed and direction
    BulletBehavior bulletBehavior = currentBullet.GetComponent<BulletBehavior>();
    bulletBehavior.setMoveRight(this.moveRight);
    bulletBehavior.setBulletSpeed(this.bulletSpeed);
  }

  // This resets the all of the shooting components
  private void resetShoot() {
    this.movable = true; // Allows the player to move
    animator.SetBool("shoot", false); // Changes the animation out of shooting animation
  }

  // Start Getters and Setters
  public float getBulletSpeed() {
    return this.bulletSpeed;
  }
  
  public void setBulletSpeed(float bulletSpeed) {
    this.bulletSpeed = bulletSpeed;
  }

  public bool getMoveRight() {
    return this.moveRight;
  }

  public void setMoveRight(bool moveRight) {
    this.moveRight = moveRight;
  }

  public GameObject getBullet() {
    return bullet;
  }

  public void setBullet(GameObject bullet) {
    this.bullet = bullet;
  }

  public void setAnimator(Animator animator) {
    this.animator = animator;
  }

  public bool getMovable() {
    return this.movable;
  }

  public void setMuzzleFlash(GameObject muzzleFlash) {
    this.muzzleFlash = muzzleFlash;
  } 
  
  public void setShootKey(KeyCode shootKey) {
    this.shootKey = shootKey;
  }

  public bool getShouldShoot() {
    return this.shouldShoot;
  }

  public void setShouldShoot(bool shouldShoot) {
    this.shouldShoot = shouldShoot;
  }
  // End Getters and Setters
}
