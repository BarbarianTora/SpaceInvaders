using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsManager : MonoBehaviour
{
	PoolManager objectPooler;
	public Button _fireButton = null;

	[SerializeField]
	private AudioSource bulletAudio = null;

	[SerializeField]
	private GameObject _bullet = null;

	private Transform _cameraMainTransform;

	void Start()
	{ 
		PoolManager.instance.CreatePool (_bullet, 5);
		_fireButton.onClick.AddListener(OnButtonDown);  
		bulletAudio = GetComponent<AudioSource>();

		_cameraMainTransform = Camera.main.transform;
	}

	void OnButtonDown()
	{
		Fire();
	} 

	void Fire()
	{
		bulletAudio.Play();
		PoolManager.instance.ReuseObject (_bullet, _cameraMainTransform.position, _cameraMainTransform.rotation);
	}
}
