using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDone : MonoBehaviour
{

    public GameObject gameOverPanel;

    // Update is called once per frame
    void Update() {
        // Check to see if the player is active or null, and draw the game over panel if true
        if (GameObject.FindGameObjectWithTag("Player") == null || !GameObject.FindGameObjectWithTag("Player").activeSelf) {
            gameOverPanel.SetActive(true);
            //print("here");
        }

    }

    // restart the game
    public void Restart() {
        SceneManager.LoadScene("SampleScene");
        print("here");
    }
}
