using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WebCamScript : MonoBehaviour 
{
	[SerializeField]
	private GameObject _webCameraPlane = null; 

	private const int QUATERPERIOD = 90;
	private Transform _curTransform = null;

	void Start () 
	{
		_curTransform = transform;

		if ( Application.isMobilePlatform ) 
		{
			GameObject cameraParent = new GameObject( "camParent" );
			cameraParent.transform.position = this.transform.position;
			this.transform.parent = cameraParent.transform;
			cameraParent.transform.Rotate( Vector3.left, QUATERPERIOD );
		} 

		Input.gyro.enabled = true;

		WebCamTexture webCameraTexture = new WebCamTexture();
		_webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
		webCameraTexture.Play();

	}
		
	void Update () 
	{
		Quaternion cameraRotation = new Quaternion( Input.gyro.attitude.x, Input.gyro.attitude.y,
										   -Input.gyro.attitude.z, -Input.gyro.attitude.w );
		
		_curTransform.localRotation = cameraRotation;

	}
}
