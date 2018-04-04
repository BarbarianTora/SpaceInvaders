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

	[SerializeField]
	private FighterManager _fighterManager = null;

	void Awake()
	{
		_curRigidBody = GetComponent<Rigidbody>();
		_curTransform = transform;
		_fighterManager = GameObject.FindObjectOfType<FighterManager> ();
	}

	void OnEnable()
	{
		_curRigidBody.AddForce (_curTransform.forward * _bulletSpeed);
		//OnObjectSpawn();
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
		gameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider col)
	{
//		StartCoroutine (DelayHitFighter (col));
		GameObject explosion = Instantiate(_explotion, _curTransform.position, Quaternion.identity);
		col.gameObject.SetActive (false);
		_fighterManager.SpawnFighter ();
		gameObject.SetActive(false);
		Destroy (explosion, 2);


	}

//	private IEnumerator DelayHitFighter(Collider col)
//	{
//		GameObject explosion = Instantiate(_explotion, _curTransform.position, Quaternion.identity);
//
//		col.gameObject.SetActive (false);
//
//		//yield return new WaitForEndOfFrame ();
//
//		//col.gameObject.GetComponent<PoolObject> ().Deactivate ();
//
//		yield return new WaitForEndOfFrame ();
//
//		_fighterManager.SpawnFighter ();
//
//		yield return new WaitForEndOfFrame ();
//
//		gameObject.SetActive(false);
//
//		yield return new WaitForSeconds (2f);
//
//		Destroy (explosion);
//
//	}

}
