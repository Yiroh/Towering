using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button WorkshopButton;
    public Button TowerButton;
    public Button SettingsButton;
    public Button HowToPlayButton;
    public Button HowToCloseButton;

    public GameObject HowToPanel;
    public GameObject UpgradesPanel;

    void Update ()
    {
        if (PlayerStats.instance != null)
            WorkshopButton.interactable = true;
        else 
            WorkshopButton.interactable = false;
    }

    // Permanent Upgrades
    public void Workshop ()
    {
        if (UpgradesPanel != null)
        {
            UpgradesPanel.SetActive(true);
        }
    }

    public void CloseWorkshop ()
    {
        if (UpgradesPanel != null)
        {
            UpgradesPanel.SetActive(false);
        }
    }

    // Play Towering
    public void Tower ()
    {
        // Switch to InGame Scene
        SceneManager.LoadSceneAsync("InGame").completed += (AsyncOperation operation) => 
        {
            // Access objects in the loaded scene here
            GameObject gameGM = GameObject.Find("GameManager");
            GameManager gameManager = gameGM.GetComponent<GameManager>();
            gameManager.Retry();
        };
    }

    public void Settings ()
    {
        SceneManager.LoadScene("Settings");
    }

    public void HowToPlay ()
    {
        if (HowToPanel != null)
        {
            HowToPanel.SetActive(true);
        }
    }

    public void HowToClose ()
    {
        if (HowToPanel != null)
        {
            HowToPanel.SetActive(false);
        }
    }
}
