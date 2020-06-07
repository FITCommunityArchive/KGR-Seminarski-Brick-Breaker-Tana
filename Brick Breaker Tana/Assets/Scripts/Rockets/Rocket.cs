using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
	public float speed = 10f;
	public int lives;
	[SerializeField]
	private GameObject extended;
	[SerializeField]
	private GameObject bullet;
	private Text lifeText;
	private GameObject lifeParent;
	[SerializeField]
	private GameObject life;
	void Start()
	{
		//extended = GameObject.FindGameObjectWithTag("ExtendedRocket");
		lifeText = GameObject.FindGameObjectWithTag("LifeText").GetComponent<Text>();
		lifeParent = GameObject.FindGameObjectWithTag("LifeParent").gameObject;
		lives = lifeParent.transform.childCount;
		//lifeText.text = $"x{lifeParent.transform.childCount}";
		Debug.Log(PlayerPrefs.GetInt("levelAt"));
	}
	void FixedUpdate()
	{
		
		float h = Input.GetAxisRaw("Horizontal");
		lives = lifeParent.transform.childCount;
		if (h > 0)
		{
			Vector3 temp = transform.position;
			temp.x += speed * Time.deltaTime;
			transform.position = temp;
		}

		if (h < 0)
		{
			Vector3 temp = transform.position;
			temp.x -= speed * Time.deltaTime;
			transform.position = temp;
		}
	}
	//void Update()
	//{
	//	if (lives == 0)
	//	{
	//		GameManager.instance.Restart();
	//	}
	//}

	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag ==MyTags.ExtendedPowerUp_Tag)
		{
			
			Destroy(target.gameObject);
			SoundManager.instance.PowerUpSoundFX();
			extended.transform.position = gameObject.transform.position;
			extended.transform.rotation = gameObject.transform.rotation;
			extended.SetActive(true);
			gameObject.SetActive(false);

			
			Invoke("LoadAgain", 10);
		}
		else if(target.gameObject.tag==MyTags.BulletPowerUp_Tag)
		{
			Destroy(target.gameObject);
			SoundManager.instance.PowerUpSoundFX();
			Invoke("LoadBullets", 1);
			Invoke("LoadBullets", 2);
			Invoke("LoadBullets", 3);
			Invoke("LoadBullets", 4);
			Invoke("LoadBullets", 5);
			Invoke("LoadBullets", 6);
			Invoke("LoadBullets", 7);
			Invoke("LoadBullets", 8);
			Invoke("LoadBullets", 9);
		}
		else if (target.transform.tag == MyTags.Heart_Tag)
		{
			GameObject newLife = Instantiate(life);
			newLife.transform.parent = lifeParent.transform;
			lifeText.text = $"x{lifeParent.transform.childCount}";
			SoundManager.instance.PowerUpSoundFX();
		}
	}
	
	void LoadAgain()
	{
		gameObject.transform.position = extended.transform.position;
		gameObject.transform.rotation = extended.transform.rotation;
		gameObject.SetActive(true);
		extended.SetActive(false);
	}

	void LoadBullets()
	{
		if(gameObject.active)
		{
			Vector2 temp1, temp2;
			Debug.Log(transform.position.ToString());
			temp1.x = transform.position.x + 0.39f;
			temp1.y = transform.position.y+0.1f;
			Debug.Log(temp1.ToString());
			temp2.x = transform.position.x - 0.39f;
			temp2.y = transform.position.y+0.1f;
			Debug.Log(temp2.ToString());

			GameObject newBullet1 = Instantiate(bullet, temp1, Quaternion.identity);
			GameObject newBullet2 = Instantiate(bullet, temp2, Quaternion.identity);
		}
		
	}




}
