using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLevel : MonoBehaviour
{
    public GameObject win;
    public GameObject gameOverPanel;

    private bool pause = false;

    void Update() {

        // if the player crosses the finish line throw up the winning text and restart button
        if (pause == true) {
            gameOverPanel.SetActive(true);
            win.SetActive(true);
        }

    }

    public void Restart() {
        SceneManager.LoadScene("SampleScene");
        print("here");
    }

    // Collision to check if the Player crosses into the finish line
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.name);
        PauseGame();

    }

    // Pauses the game
    void PauseGame() {
        Time.timeScale = 0;
        pause = true;
    }

}


