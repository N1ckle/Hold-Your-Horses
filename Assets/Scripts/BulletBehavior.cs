using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    
  private float bulletSpeed = 0f;
  private bool moveRight = true;
  private Rigidbody2D rb2d;
  private int damage = 1; // TODO make this adjustable

  void Start() {
    rb2d = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate() {
    // If the bullet should move right then it will, othersise it will go left
    if(moveRight) {
      rb2d.MovePosition(rb2d.position + new Vector2(bulletSpeed, 0) * Time.deltaTime);
    }
    else {
      rb2d.MovePosition(rb2d.position - new Vector2(bulletSpeed, 0) * Time.deltaTime);
    }
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    Destroy(gameObject);
  } 

  // Start Gettters and Setters
  public void setMoveRight(bool moveRight) {
    this.moveRight = moveRight;
  }

  public bool getMoveRight() {
    return this.moveRight;
  }

  public void setBulletSpeed(float bulletSpeed) {
    this.bulletSpeed = bulletSpeed;
  }

  public float getBulletSpeed() {
    return this.bulletSpeed;
  }

  public int getDamage() {
    return this.damage;
  }  

  public void setDamage(int damage) {
    this.damage = damage;
  }
 // End Getters and Setters
}
