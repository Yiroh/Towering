using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

	private bool gameEnded = false;

    public TMP_Text towerHPText;
    public TMP_Text cubesText;
    public TMP_Text gemsText;
    public TMP_Text gemsGainedText;
    public GameObject gameOverUI;

	// Update is called once per frame
	void Update () {
		if (gameEnded)
			return;

		if (PlayerStats.towerHP <= 0)
		{
			EndGame();
		}

        towerHPText.text = "Tower HP: " + Mathf.Round(PlayerStats.towerHP).ToString();
        cubesText.text = "Cubes: " + Mathf.Round(PlayerStats.Cubes).ToString();
        gemsText.text = "Gems: " + Mathf.Round(PlayerStats.Gems).ToString();
	}

	void EndGame ()
	{
		gameEnded = true;
		Debug.Log("Game Over!");

        GameObject enemySpawner = GameObject.Find("Enemy Spawner");
        WaveSpawner waveSpawner = enemySpawner.GetComponent<WaveSpawner>();
        PlayerStats.Gems += waveSpawner.waveIndex;
        gemsGainedText.text = "You have gained " + waveSpawner.waveIndex + " gems!";

        gameOverUI.SetActive(true);
	}

    public void Retry ()
    {
        // Reset all fields
        gameOverUI.SetActive(false);

        GameObject towerRef = GameObject.Find("Tower");
        PlayerStats playerStats = towerRef.GetComponent<PlayerStats>();
        playerStats.Reset();

        GameObject enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.Reset();

        GameObject canvasObject = GameObject.Find("Canvas");
        Shop shop = canvasObject.GetComponent<Shop>();
        shop.ResetShop();

        // Destroy all enemies, reset wave.

        GameObject enemySpawner = GameObject.Find("Enemy Spawner");
        WaveSpawner waveSpawner = enemySpawner.GetComponent<WaveSpawner>();
        waveSpawner.Reset();

        gameEnded = false;
    }

}