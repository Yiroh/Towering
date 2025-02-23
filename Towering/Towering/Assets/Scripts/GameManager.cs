using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private bool gameEnded;

    [Header("In Game UI")]
    public TMP_Text towerHPText;
    public TMP_Text cubesText;
    public TMP_Text gemsText;
    public GameObject helpPanel;

    [Header("Game Ended UI")]
    public TMP_Text gemsGainedText;
    public GameObject gameOverUI;

    //void Awake ()
    //{
        //DontDestroyOnLoad(gameObject);
    //}

    void Start () 
    {
        gameEnded = false;
    }

	// Update is called once per frame
	void Update () {
		if (gameEnded)
			return;

		if (PlayerStats.towerHP <= 0)
		{
			EndGame();
		}

        if (!gameEnded)
        {
            towerHPText.text = "Tower HP: " + Mathf.Round(PlayerStats.towerHP).ToString();
            cubesText.text = "Cubes: " + Mathf.Round(PlayerStats.Cubes).ToString();
            gemsText.text = "Gems: " + Mathf.Round(PlayerStats.Gems).ToString();
        }
	}

    public void Town () 
    {
        // They can't come back to their session
        //Retry();
        EndGame();
        SceneManager.LoadScene(1);
    }

    public void Help ()
    {
        if (helpPanel != null)
        {
            helpPanel.SetActive(true);
        }
    }

    public void Settings ()
    {
        // Give the player their gems, they can't come back
        //Retry();
        EndGame();
        // Now leave
        SceneManager.LoadScene("Settings");
    }

    public void CloseHelp ()
    {
        if (helpPanel != null)
        {
            helpPanel.SetActive(false);
        }
    }

	void EndGame ()
	{
		gameEnded = true;
		Debug.Log("Game Over!");

        GameObject enemySpawner = GameObject.Find("Enemy Spawner");
        WaveSpawner waveSpawner = enemySpawner.GetComponent<WaveSpawner>();

        if(waveSpawner.waveIndex != 1)
        {
            PlayerStats.Gems += waveSpawner.waveIndex;
            gemsGainedText.text = "You have gained " + waveSpawner.waveIndex + " gems!";
        }
        else
            gemsGainedText.text = "You did not gain any gems!";

        GameObject tower = GameObject.FindGameObjectWithTag("Player");
        if (tower != null)
            tower.SetActive(false);

        gameOverUI.SetActive(true);
	}

    public void Retry ()
    {
        // Reset all fields
        GameObject towerRef = GameObject.FindGameObjectWithTag("Player");
        if (towerRef != null)
            towerRef.SetActive(true);
        PlayerStats playerStats = towerRef.GetComponent<PlayerStats>();
        playerStats.Reset();

        GameObject enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        if(enemyObject != null)
        {
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            enemy.Reset();
        }

        GameObject canvasObject = GameObject.Find("Canvas");
        Shop shop = canvasObject.GetComponent<Shop>();
        shop.ResetShop();

        // Destroy all enemies, reset wave.
        GameObject enemySpawner = GameObject.Find("Enemy Spawner");
        WaveSpawner waveSpawner = enemySpawner.GetComponent<WaveSpawner>();

        // Give gems
        if(waveSpawner.waveIndex > 1 && gemsGainedText != null)
            gemsGainedText.text = "You have gained " + waveSpawner.waveIndex + " gems!";
        else if (gemsGainedText != null)
            gemsGainedText.text = "You did not gain any gems!";

        waveSpawner.Reset();

        // Now leave
        gameEnded = false;
        if (gameOverUI != null)
        gameOverUI.SetActive(false);
    }

    void OnEnable ()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);

        if(scene.name == "InGame")
        {
            GameObject towerRef = GameObject.FindGameObjectWithTag("Player");
            towerRef.SetActive(true);
            Retry();
        }
    }
}