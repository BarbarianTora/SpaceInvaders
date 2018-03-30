 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

	public Vector3 center;
	public Vector3 size;
	public int FighterQuantity = 1;

	public GameObject Fighter;

	void Start () 
	{
		SpawnFighter ();
			
	}
	
	void Update () 
	{
		if (FighterQuantity <4 )
		{
			SpawnFighter ();
		}
	}

	public void SpawnFighter()
	{
		Vector3 pos = center + new Vector3 ( Random.Range( -size.x / 2, size.x / 2 ),
											 Random.Range( -size.y / 2, size.y / 2 ),
											 Random.Range( -size.z / 2, size.z / 2 ) );
		Instantiate(Fighter, pos, Quaternion.identity);
		FighterQuantity++;
	
	}

	void OnDrawGizmos()
	{
		Gizmos.color = new Color(0, 255, 255, 15);
		Gizmos.DrawWireCube( center, size ) ;
	}
}
