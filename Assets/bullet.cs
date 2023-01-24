using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    // Destroys the enemy if the bullet hits the enemy
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "Enemy(Clone)") {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);

    }
}
