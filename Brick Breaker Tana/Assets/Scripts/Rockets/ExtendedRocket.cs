using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtendedRocket : MonoBehaviour
{
    public float speed = 10f;
	[SerializeField]
	private GameObject bullet;
	public int lives;
	private Text lifeText;
	private GameObject lifeParent;
	[SerializeField]
	private GameObject life;
	void Start()
	{
		lifeText = GameObject.FindGameObjectWithTag("LifeText").GetComponent<Text>();
		lifeParent = GameObject.FindGameObjectWithTag("LifeParent").gameObject;
		lives = lifeParent.transform.childCount;
		lifeText.text = $"x{lifeParent.transform.childCount}";
	}
	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");

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
	private void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == MyTags.BulletPowerUp_Tag)
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
		else if(target.gameObject.tag==MyTags.ExtendedPowerUp_Tag)
		{
			SoundManager.instance.PowerUpSoundFX();

			Destroy(target.gameObject);
		}
	}
	void LoadBullets()
	{
		if (gameObject.active)
		{
			Vector2 temp1, temp2;
			Debug.Log(transform.position.ToString());
			temp1.x = transform.position.x + 0.39f;
			temp1.y = transform.position.y;
			Debug.Log(temp1.ToString());
			temp2.x = transform.position.x - 0.39f;
			temp2.y = transform.position.y;
			Debug.Log(temp2.ToString());

			GameObject newBullet1 = Instantiate(bullet, temp1, Quaternion.identity);
			GameObject newBullet2 = Instantiate(bullet, temp2, Quaternion.identity);
		}

	}
}
