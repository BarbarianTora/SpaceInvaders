using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionManager : MonoBehaviour 
{
	private const int EXPLOTIONS_COUNT = 5;

	[SerializeField]
	private GameObject _explotion = null;

	// Use this for initialization
	void Start () 
	{
		PoolManager.instance.CreatePool (_explotion, EXPLOTIONS_COUNT);
	}
}
