using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallParent : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;
    private GameObject lifeParent;
    [SerializeField]
    private Button buttonRestart;
    [SerializeField]
    private Button buttonMenu;
   
    private Text lifeText;
    private int lives;
    void Start()
    {
        lifeParent = GameObject.FindGameObjectWithTag("LifeParent").gameObject;
        lifeText = GameObject.FindGameObjectWithTag("LifeText").GetComponent<Text>();
        
    }
    void Update()
    {
        lives = lifeParent.transform.childCount;
        lifeText.text = $"x{lifeParent.transform.childCount}";
        if (gameObject.transform.childCount == 0)
        {
            
            lives = lifeParent.transform.childCount;
            if(lives==0)
            {
                lives = lifeParent.transform.childCount;
                lifeText.text = $"x{lifeParent.transform.childCount}";
                //GameManager.instance.Restart();
                buttonRestart.gameObject.SetActive(true);
                buttonMenu.gameObject.SetActive(true);                
                Time.timeScale = 0f;
            }
            else
            {
                GameObject lifeTest = lifeParent.transform.GetChild(0).gameObject;
                Destroy(lifeTest);
                lives = lifeParent.transform.childCount;
                lifeText.text = $"x{lifeParent.transform.childCount}";
                Vector2 temp;
                temp.x = 0;
                temp.y = 0;          
                GameObject newBall = Instantiate(ball, temp, Quaternion.identity);
                newBall.transform.parent = gameObject.transform;
                Rigidbody2D newBallBody = newBall.GetComponent<Rigidbody2D>();
                newBallBody.velocity = Vector2.down * 5f;
            }
        }
    }
   
    
}
