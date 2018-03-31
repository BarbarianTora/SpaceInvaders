using System.Collections;
using UnityEngine;

public class RandomPatrolScript : MonoBehaviour {

	public float speed;
	public Transform[] moveSpots;

	[SerializeField] private float minX = -6.1f;
	[SerializeField] private float maxX = 6.1f;
	[SerializeField] private float minY = 9.57f;
	[SerializeField] private float maxY = 21.74f;
	[SerializeField] private float minZ = -11.51f;
	[SerializeField] private float maxZ = 0.67f;

	private int j = 0;

	void Start()
	{
		j = Random.Range (0 , moveSpots.Length);
		for (int i = 0; i < moveSpots.Length; i++) 
		{
			moveSpots[i].position = new Vector3 ( Random.Range( minX , maxX ),
												  Random.Range( minY , maxY ), 
												  Random.Range( minZ , maxZ ) );	
		}		

	}


	void Update()
	{	
		
		transform.position = Vector3.MoveTowards ( transform.position, 
													moveSpots[j].position,
													speed * Time.deltaTime);
		j = Random.Range (0 , moveSpots.Length);
		for (int i = 0; i < moveSpots.Length; i++) 
		{	
		if ( Vector3.Distance (transform.position, moveSpots[j].position) < 0.2f ) 
			{
				moveSpots[i].position = new Vector3 ( Random.Range ( minX, maxX ),
													  Random.Range ( minY, maxY ), 
													  Random.Range ( minZ, maxZ ) );
			}
		}
	} 
	 
	
}
			
