using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int health;

    void Start() {
        health = 5;

        if (PlayerPrefs.HasKey("Health")) {
            health = PlayerPrefs.GetInt("Health");
        }

        UpdateHUD();
    }

    public void Damage(int damage) {
        health -= damage;

        if(health <= 0) {
            health = 0;
            StartCoroutine(Die());
        }

        UpdateHUD();
    }

    public void UpdateHUD() {
        //GameObject.Find("Canvas - HUD").GetComponent<HUDManager>().SetPlayersHealth(health);
        GameObject canvas = GameObject.Find("Canvas - HUD");
        HUDManager hudManager = canvas.GetComponent<HUDManager>();
        hudManager.SetPlayersHealth(health);
    }

    public IEnumerator Die() {
        //animacje itd
        yield return new WaitForSeconds(0);
        PlayerPrefs.SetInt("Health", 5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
