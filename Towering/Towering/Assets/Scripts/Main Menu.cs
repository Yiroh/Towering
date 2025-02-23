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

    // Permanent Upgrades
    public void Workshop ()
    {
        // Either have a UI for this or switch to a separate scene.
    }

    // Play Towering
    public void Tower ()
    {
        // Switch to InGame Scene
        SceneManager.LoadScene(sceneName:"InGame");
    }

    public void Settings ()
    {
        // Either have a UI for this or switch to a separate scene.
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
