using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public Button StartButton;

    public void hitStart ()
    {
        SceneManager.LoadScene(1);
    }
}
