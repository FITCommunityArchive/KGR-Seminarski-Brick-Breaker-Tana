using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void PlayGame()
    {
        SoundManager.instance.MenuSoundFX();
        SceneManager.LoadScene("LevelSelection");
    }
    public void ExitGame()
    {
        SoundManager.instance.MenuSoundFX();

        Application.Quit();
    }
    public void BackGame()
    {
        SoundManager.instance.MenuSoundFX();

        SceneManager.LoadScene("Menu");
    }
    public void RestartScene()
    {
        SoundManager.instance.MenuSoundFX();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
