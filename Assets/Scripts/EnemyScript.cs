using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	void Start () 
	{

		StartCoroutine ( "Move" );

	}

	void Update () 
	{

		transform.Translate( Vector3.forward * 3f * Time.deltaTime ); 

	}

	IEnumerator Move() {

			while (true) 
		{
			yield return new WaitForSeconds ( 3.5f );
			transform.eulerAngles += new Vector3 ( 0, 180f, 0 );
		}
	}
}