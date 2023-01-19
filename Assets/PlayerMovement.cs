using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector2 inputVector = Vector2.zero;

    [SerializeField] GameObject RockPrefab;
    [SerializeField] Rigidbody2D rb;

    Vector2 playerMove;

    [Header("Designer Variables")]
    [SerializeField] public float moveSpeed = 500f;
    [SerializeField] public float velocityDampening = .99f;

    
    // Start is called before the first frame update
    void Start()
    {
        // inefficient way - VERY EXPENSIVE USING GETCOMPONENTS
        //rb = GetComponent<Rigidbody2D>();

        print("Print Statement");
        Debug.Log("Debug.log");
        Debug.LogWarning("Debug.logWarning");
        Debug.LogError("Debug.LogError");
    }

    // Update is called once per frame
    void Update()
    {
        //playerMove.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
            inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        } else {
            inputVector = Vector2.zero;
        }
        

        if (Input.GetButtonDown("Fire1")) {
            SpawnRock();
        }
    }

    private void FixedUpdate() {
        rb.AddForce(inputVector * moveSpeed * Time.deltaTime);
        rb.velocity *= velocityDampening;
    }

    private void SpawnRock() {
        Vector2 spawnPosition = new Vector2(Random.Range(-10, 10), 6);
        Instantiate(RockPrefab, spawnPosition, Quaternion.identity);
    }
}
