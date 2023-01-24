using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{

    // Update is called once per frame
    void Update() {
        // Check for off screen
        if (transform.position.y < -6) {
            Destroy(gameObject);
        }
    }
}
