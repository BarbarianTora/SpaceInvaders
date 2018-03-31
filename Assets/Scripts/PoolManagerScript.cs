using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolManagerScript : MonoBehaviour
{

	float bulletSpeed = 1100;

	public GameObject bullet;
	public Button fireButton;

	AudioSource bulletAudio;

	List<GameObject> bulletList;

	void Start()
	{
		bulletList = new List<GameObject>();
		for (int i = 0; i < 5; i++)
		{
			GameObject objBullet = (GameObject)Instantiate(bullet);
			objBullet.SetActive(false);
			bulletList.Add(objBullet);
		}
		fireButton.onClick.AddListener( OnButtonDown ); 

		bulletAudio = GetComponent<AudioSource>();

	}

	void Fire()
	{

		for (int i = 0; i < bulletList.Count; i++)
		{
			if (!bulletList[i].activeInHierarchy)
			{
				bulletList[i].transform.position = transform.position;
				bulletList[i].transform.rotation = transform.rotation;
				bulletList[i].SetActive(true);
				Rigidbody tempRigidBodyBullet = bulletList[i].GetComponent<Rigidbody>();
				tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
				break;
			}
		}
		//Shoot
		/*GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);
        Destroy(tempBullet, 0.5f);*/

		bulletAudio.Play();

	}


	void OnButtonDown()
	{
		Fire();

	} 

	/*void OnButtonDown()
	{
		GameObject bullet = Instantiate(Resources.Load( "Bullet", typeof(GameObject ) ) ) as GameObject;
		Rigidbody rb = bullet.GetComponent<Rigidbody>();
		bullet.transform.rotation = Camera.main.transform.rotation;
		bullet.transform.position = Camera.main.transform.position;
		rb.AddForce( Camera.main.transform.forward * 500f );
		Destroy ( bullet, 3 );

		GetComponent<AudioSource> ().Play (); 

	} */

}
