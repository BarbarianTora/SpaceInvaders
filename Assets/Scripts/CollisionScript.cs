using UnityEngine;
using System.Collections;

public class collisionScript : MonoBehaviour {

	void Start () 
	{

	}

	void Update () 
	{

	}

	void OnTriggerEnter (Collider col)
	{
		GameObject explosion = Instantiate(Resources.Load( "WFXMR_ExplosiveSmoke", typeof( GameObject ) ) ) as GameObject;
		explosion.transform.position = transform.position;
		Destroy(col.gameObject);
		Destroy (explosion, 2);


		if (GameObject.FindGameObjectsWithTag("Player").Length == 0){

			GameObject enemy =  Instantiate( Resources.Load( "Fighter",  typeof( GameObject ) ) ) as GameObject;
			GameObject enemy1 = Instantiate( Resources.Load( "Fighter1", typeof( GameObject ) ) ) as GameObject;
			GameObject enemy2 = Instantiate( Resources.Load( "Fighter2", typeof( GameObject ) ) ) as GameObject;
			GameObject enemy3 = Instantiate( Resources.Load( "Fighter3", typeof( GameObject ) ) ) as GameObject;

		}

		Destroy (gameObject);


	}

}