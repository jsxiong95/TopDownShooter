using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [Header("Prefab References")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 3.5f;


    private void Awake() {
        // singleton
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        // This breaks the entire program, inquire about it
        //DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start() {
        ResumeGame();
        // spawn the enemy every so seconds
        StartCoroutine(spawnEnemy(spawnInterval, enemyPrefab));
    }

    // Spawns the Enemy in a given time
    private IEnumerator spawnEnemy(float interval, GameObject enemy) {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-3f, 3f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

    // Resumes the game after EndLevel.cs pauses it
    void ResumeGame() {
        Time.timeScale = 1;
    }

}
