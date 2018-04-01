using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour, IPooledObjects 
{	
	public delegate void HitTargetHandler();
	public static event HitTargetHandler OnHitTarget;

	private const string SPAWNER_NAME = "Spawner";

	[SerializeField]
	private float _bulletSpeed = 1500f;

	[SerializeField]
	private GameObject _explotion = null;

	private Rigidbody _curRigidBody = null;
	private Transform _curTransform = null;

	private int _quantity;

	void Awake()
	{
		_curRigidBody = GetComponent<Rigidbody>();
		_curTransform = transform;
	}

	void OnEnable()
	{
		_curRigidBody.AddForce (_curTransform.forward * _bulletSpeed);
		OnObjectSpawn();
	}

	void OnDisable()
	{
		_curRigidBody.velocity = Vector3.zero;
	}

	public void OnObjectSpawn()
	{
		Invoke ("hideBullet", 2);
	}

	void hideBullet()
	{
		gameObject.SetActive( false );
	}

	void OnTriggerEnter( Collider col )
	{
		GameObject explosion = Instantiate(_explotion, _curTransform.position, Quaternion.identity);

		//Destroy(col.gameObject);

		col.gameObject.SetActive(false);

		Destroy (explosion, 2);

		if (OnHitTarget != null)
			OnHitTarget ();

		gameObject.SetActive(false);
	}

}
