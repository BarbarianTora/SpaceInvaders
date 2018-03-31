using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {



	private int _quantity;
	private const string SPAWNER_NAME = "Spawner";

	void Start () 
	{
		_quantity = GameObject.Find(SPAWNER_NAME).GetComponent<SpawnerScript>().FighterQuantity;

	}


	private void OnEnable()
	{
		transform.GetComponent<Rigidbody>().WakeUp();
		Invoke("hideBullet", 2.0f);
	}

	void hideBullet()
	{
		gameObject.SetActive(false);
	}

	private void OnDisable()
	{
		transform.GetComponent<Rigidbody>().Sleep();
		CancelInvoke();
	}

	/*private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "enemy")
		{
			GameObject explosion = Instantiate(Resources.Load( "WFXMR_ExplosiveSmoke", typeof( GameObject ) ) ) as GameObject;
			explosion.transform.position = transform.position;
			Destroy(collision.gameObject);

			gameObject.SetActive(false);
			_quantity--;
		}
	}*/

	void OnTriggerEnter (Collider col)
	{
		GameObject explosion = Instantiate(Resources.Load( "WFXMR_ExplosiveSmoke", typeof( GameObject ) ) ) as GameObject;
		explosion.transform.position = transform.position;
		Destroy(col.gameObject);
		Destroy (explosion, 2);

		gameObject.SetActive(false);
		_quantity--;
	}



	/*void OnTriggerEnter (Collider col)
	{
		GameObject explosion = Instantiate(Resources.Load( "WFXMR_ExplosiveSmoke", typeof( GameObject ) ) ) as GameObject;
		explosion.transform.position = transform.position;
		Destroy(col.gameObject);
		Destroy (explosion, 2);

		Destroy (gameObject);

		_quantity--;

	} */



}
