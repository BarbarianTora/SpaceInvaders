using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsManager : MonoBehaviour
{
	PoolManager objectPooler;
	public Button _fireButton;

	[SerializeField]
	private AudioSource bulletAudio = null;

	[SerializeField]
	private GameObject _bullet = null;

	void Start()
	{ 
		PoolManager.instance.CreatePool (_bullet, 5);
		_fireButton.onClick.AddListener(OnButtonDown);  
		bulletAudio = GetComponent<AudioSource>();
	}

	void OnButtonDown()
	{
		Fire();
	} 

	void Fire()
	{
		bulletAudio.Play();
		PoolManager.instance.ReuseObject (_bullet, transform.position, Quaternion.identity);
	}
}
