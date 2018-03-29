using UnityEngine;
using System.Collections;

public class collisionScript : MonoBehaviour {

	//for this to work both need colliders, one must have rigid body (spaceship) the other must have is trigger checked.
	void OnTriggerEnter (Collider col)
	{
		GameObject explosion = Instantiate(Resources.Load("SmallExplosionEffect", typeof(GameObject))) as GameObject;
		explosion.transform.position = transform.position;
		Destroy(col.gameObject);
		Destroy (explosion, 2);


		if (GameObject.FindGameObjectsWithTag("Player").Length == 0){

			GameObject enemy = Instantiate(Resources.Load("Enemy", typeof(GameObject))) as GameObject;
			GameObject enemy1 = Instantiate(Resources.Load("Enemy1", typeof(GameObject))) as GameObject;
			GameObject enemy2 = Instantiate(Resources.Load("Enemy2", typeof(GameObject))) as GameObject;
			GameObject enemy3 = Instantiate(Resources.Load("Enemy3", typeof(GameObject))) as GameObject;

		}

		Destroy (gameObject);


	}

}