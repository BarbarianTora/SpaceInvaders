 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterManager : MonoBehaviour {

	public GameObject Fighter = null;

	private const int MAX_FIGHTERS = 4;
	private const int CENTER_X = 0;
	private const int CENTER_Y = 0;
	private const int CENTER_Z = 4;

	private const int SIZE_X = 13;
	private const int SIZE_Y = 13;
	private const int SIZE_Z = 13;

	[SerializeField] 
	private Vector3 center = new Vector3( CENTER_X, CENTER_Y, CENTER_Z );
	[SerializeField]
	private Vector3 size = new Vector3( SIZE_X, SIZE_Y, SIZE_Z );

	[SerializeField]
	private int fighterQuantity = 0;

	void OnEnable()
	{
		BulletScript.OnHitTarget += DecreaseFighterQuantity;
	}

	void OnDisable()
	{
		BulletScript.OnHitTarget -= DecreaseFighterQuantity;
	}
			
	void Start () 
	{
		//SpawnFighter();
	}

	void Update () 
	{
		if ( fighterQuantity < MAX_FIGHTERS )
		{
			SpawnFighter();
		}
	}

	private void DecreaseFighterQuantity()
	{
		Debug.Log ("Hit fihgter");
		fighterQuantity--;
	}

	public void SpawnFighter()
	{
		Vector3 pos = center + new Vector3 ( Random.Range( -size.x / 2, size.x / 2 ),
											 Random.Range( -size.y / 2, size.y / 2 ),
											 Random.Range( -size.z / 2, size.z / 2 ) );
		
		transform.position = pos;

		ObjectPooler.Instance.SpawnFromPool ( "Fighter", pos, Quaternion.identity );

		fighterQuantity++;
	
	}

	void OnDrawGizmos()
	{
		Gizmos.color = new Color( 0, 255, 255, 15 );
		Gizmos.DrawWireCube( center, size ) ;
	}
}
