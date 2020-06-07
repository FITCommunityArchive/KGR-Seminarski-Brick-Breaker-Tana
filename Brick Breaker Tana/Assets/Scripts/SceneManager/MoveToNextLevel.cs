using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;
    GameObject brickparent;
    [SerializeField]
    private Button buttonMenu;
    [SerializeField]
    private Button buttonNextLevel;
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        brickparent = GameObject.FindGameObjectWithTag(MyTags.BrickParent_Tag);
        
    }

    void Update()
    {
        if (brickparent.transform.childCount==0)
        {
            if (SceneManager.GetActiveScene().buildIndex == 7) /* < Change this int value to whatever your
                                                                   last level build index is on your
                                                                   build settings */
            {
                SceneManager.LoadScene(8);
                
            }
            else
            {
                      
                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
                buttonNextLevel.gameObject.SetActive(true);
                buttonMenu.gameObject.SetActive(true);
                Time.timeScale = 0f;
                
            }
        }
    }
    public void LoadNextLvl()
    {
        SceneManager.LoadScene(nextSceneLoad);
    }
    

    
}
