using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

	[SerializeField] private float fighterSpeed = 0.2f;

	private const float _xMax = 6f;
	private const float _zMax = 9.17f ;
	private const float _xMin = -6f;
	private const float _zMin = -2.53f;

	private const float _pi = 3.141592f;
	private const float _period = 180f;
	private const float _halfPeriod = 90f;

	private float _x;
	private float _z;
	private float _time;
	private float _angle;

	public float lookSpeed = 10;
	private Vector3 _curLoc;
	private Vector3 _prevLoc;

	void Start () 
	{
		_curLoc = transform.position;

		_x = Random.Range(-fighterSpeed, fighterSpeed);
		_z = Random.Range(-fighterSpeed, fighterSpeed);
		_angle = Mathf.Atan2(_x, _z) * (_period / _pi) + _halfPeriod;
		transform.localRotation = Quaternion.Euler(0, _angle, 0);
	}

	void Update () 
	{

		_time += Time.deltaTime;

		if (transform.localPosition.x > _xMax) 
		{
			_x = Random.Range(-fighterSpeed, 0.0f);
			//_angle = Mathf.Atan2( _x, _z ) * ( _period/ _pi ) + _halfPeriod;
			//transform.localRotation = Quaternion.Euler( 0, _angle, 0 );
			_time = 0.0f; 
		}

		if (transform.localPosition.x < _xMin) 
		{
			_x = Random.Range(0.0f, fighterSpeed);
			//_angle = Mathf.Atan2(_x, _z) * (_period / _pi ) + _halfPeriod;
			//transform.localRotation = Quaternion.Euler(0, _angle, 0); 
			_time = 0.0f; 
		}

		if (transform.localPosition.z > _zMax) 
		{
			_z = Random.Range(-fighterSpeed, 0.0f);
			//_angle = Mathf.Atan2( _x, _z ) * ( _period / _pi ) + _halfPeriod;
			//transform.localRotation = Quaternion.Euler( 0, _angle, 0 ); 
			_time = 0.0f; 
		}

		if (transform.localPosition.z < _zMin) 
		{
			_z = Random.Range(0.0f, fighterSpeed);
			//_angle = Mathf.Atan2( _x, _z ) * ( _period / _pi ) + _halfPeriod;
			//transform.localRotation = Quaternion.Euler( 0, _angle, 0 );
			_time = 0.0f; 
		}


		if (_time > 1.0f ) 
		{
			_x = Random.Range(-fighterSpeed, fighterSpeed);
			_z = Random.Range(-fighterSpeed, fighterSpeed);
			//_angle = Mathf.Atan2( _x, _z ) * ( _period / _pi ) + _halfPeriod;
			//transform.localRotation = Quaternion.Euler( 0, _angle, 0 );
			_time = 0.0f;
		}

		Vector3 newPosition = new Vector3(transform.localPosition.x + _x,
										  transform.localPosition.y,
										  transform.localPosition.z + _z);

		transform.localPosition = newPosition;
		 
		_prevLoc = _curLoc;
		_curLoc = transform.position;

		transform.rotation = Quaternion.Lerp (transform.rotation,  
								   Quaternion.LookRotation(transform.position - _prevLoc),
								   Time.fixedDeltaTime * lookSpeed);
					
	}
}
