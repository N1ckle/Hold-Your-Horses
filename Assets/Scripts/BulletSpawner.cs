using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

  
  private GameObject bullet;

  private float bulletSpeed = 0f;
  private bool moveRight = true;

  private bool canShoot = true;
  

  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    if(Input.GetKeyDown(KeyCode.J)) {
      if(canShoot) {
        
        GameObject currentBullet = Instantiate(bullet, transform.position, transform.rotation);

        BulletBehavior bulletBehavior = currentBullet.GetComponent<BulletBehavior>();
        bulletBehavior.setMoveRight(this.moveRight);
        bulletBehavior.setBulletSpeed(this.bulletSpeed);
        
      }
    }
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
  // End Getters and Setters
}
