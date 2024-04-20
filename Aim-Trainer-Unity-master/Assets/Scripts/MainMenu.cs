using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;
    public GameObject menu;
    public GameObject experienceQuestion;

    public void Play()
    {
        menu.SetActive(false);
        experienceQuestion.SetActive(true);
    }

    public void OnYes()
    {
        PlayerPrefs.SetString("experience", "Experinced player");
        SceneManager.LoadScene(firstLevel);
    }

    public void OnNo()
    {
        PlayerPrefs.SetString("experience", "Inexperinced player");
        SceneManager.LoadScene(firstLevel);
    }

    public void ExitGame()
    {
        Application.Quit();

        // In the editor , stop playing the game
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
