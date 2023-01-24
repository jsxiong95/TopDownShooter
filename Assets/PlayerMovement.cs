using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector2 inputVector = Vector2.zero;

    [SerializeField] GameObject RockPrefab;
    [SerializeField] Rigidbody2D rb;

    Vector2 playerMove;

    Vector2 mousePos;

    public Camera cam;

    [Header("Designer Variables")]
    [SerializeField] public float moveSpeed = 500f;
    [SerializeField] public float velocityDampening = .99f;

    // Update is called once per frame
    void Update() {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
            inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        } else {
            inputVector = Vector2.zero;
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        
    }

    // Handles the Physics
    private void FixedUpdate() {
        rb.AddForce(inputVector * moveSpeed * Time.deltaTime);
        rb.velocity *= velocityDampening;

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }


    // Deactivates the player if they hit the enemy, AKA lose
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Enemy(Clone)") {
            Debug.Log(collision.gameObject.name);
            gameObject.SetActive(false);
        }

    }



    }
