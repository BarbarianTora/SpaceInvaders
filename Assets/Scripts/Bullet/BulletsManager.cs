using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsManager : MonoBehaviour
{
	ObjectPooler objectPooler;
	public Button _fireButton;

	AudioSource bulletAudio;

	void Start()
	{ 
		_fireButton.onClick.AddListener( OnButtonDown );  
		bulletAudio = GetComponent<AudioSource>();
	}

	void OnButtonDown()
	{
		Fire();
	} 

	void Fire()
	{
		ObjectPooler.Instance.SpawnFromPool ( "Bullet", transform.position, Quaternion.identity );
		bulletAudio.Play();
	}
}
