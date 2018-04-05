 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterManager : MonoBehaviour {

	public GameObject Fighter = null;

	private const int MAX_FIGHTERS = 5;
	private const int CENTER_X = 0;
	private const int CENTER_Y = 0;
	private const int CENTER_Z = 4;

	private const int SIZE_X = 13;
	private const int SIZE_Y = 13;
	private const int SIZE_Z = 13;

	[SerializeField] 
	private Vector3 center = new Vector3(CENTER_X, CENTER_Y, CENTER_Z);
	[SerializeField]
	private Vector3 size = new Vector3(SIZE_X, SIZE_Y, SIZE_Z);
			
	void Start () 
	{
		for (int i = 0; i < MAX_FIGHTERS; i++) 
		{
			SpawnFighter ();
		}
	}

	public void RespawnFighter(Transform respawnFighterTransform)
	{
		Vector3 pos = center + new Vector3 (Random.Range(-size.x / 2f, size.x / 2f),
											Random.Range(-size.y / 2f, size.y / 2f),
											Random.Range(-size.z / 2f, size.z / 2f));

		respawnFighterTransform.position = pos;
	}

	public void SpawnFighter()
	{
		
		Vector3 pos = center + new Vector3 (Random.Range(-size.x / 2, size.x / 2),
											Random.Range(-size.y / 2, size.y / 2),
											Random.Range(-size.z / 2, size.z / 2));

		Instantiate (Fighter, pos, Quaternion.identity);
	}


	void OnDrawGizmos()
	{
		Gizmos.color = new Color(0, 255, 255, 15);
		Gizmos.DrawWireCube(center, size) ;
	}
}
