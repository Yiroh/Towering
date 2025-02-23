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
        SceneManager.LoadScene("InGame");
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
