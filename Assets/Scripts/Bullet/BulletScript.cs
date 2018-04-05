using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour, IPooledObjects 
{	
	private const string FIGHTER_TAG = "Fighter";
	private const string SPAWNER_NAME = "Spawner";

	[SerializeField]
	private float _bulletSpeed = 1500f;
	[SerializeField]
	private GameObject _explotion = null;
	[SerializeField]
	private FighterManager _fighterManager = null;

	private Rigidbody _curRigidBody = null;
	private Transform _curTransform = null;
	private GameObject _bullet = null;

	private Transform _cameraMainTransform;

	void Awake()
	{
		_bullet = gameObject;
		_curRigidBody = GetComponent<Rigidbody>();
		_curTransform = transform;
		_fighterManager = GameObject.FindObjectOfType<FighterManager> ();

		_cameraMainTransform = Camera.main.transform;
	}

	void OnEnable()
	{
		_curRigidBody.velocity = Vector3.zero;
		_curRigidBody.AddForce (_cameraMainTransform.forward * _bulletSpeed);
		OnObjectSpawn ();
	}

	public void OnObjectSpawn()
	{
		Invoke ("hideBullet", 2);
	}

	void hideBullet()
	{
		gameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == FIGHTER_TAG) 
		{
			PoolManager.instance.ReuseObject(_explotion, _curTransform.position, Quaternion.identity);

			_fighterManager.RespawnFighter (col.transform);

			_bullet.SetActive(false);

		}

	}
}
