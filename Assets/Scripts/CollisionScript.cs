using UnityEngine;
using System.Collections;

public class collisionScript : MonoBehaviour {

	private int _quantity;

	void Start () 
	{
		_quantity = GameObject.Find( "Spawner" ).GetComponent<SpawnerScript>().FighterQuantity;

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

		Destroy (gameObject);

		_quantity++;

	}

}