using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{   
    private int health; // The health of this character
    private bool dead = false; // If the character is dead

    public void OnCollisionEnter2D(Collision2D collision) {
      
      if(collision.collider.tag == "Bullet") {
        GameObject bullet = collision.gameObject;
        // Removes the amount of damage the bullet does from health
        health -= bullet.GetComponent<BulletBehavior>().getDamage(); 
      }
    }

    // Begin Getters and Setters
    public int getHealth() {
      return this.health;
    }

    public void setHealth(int health) {
      this.health = health;
    }
    // End Getters and Setters
}
