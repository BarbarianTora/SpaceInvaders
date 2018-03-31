using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WebCamScript : MonoBehaviour {

	public GameObject webCameraPlane; 

	void Start () 
	{
		if ( Application.isMobilePlatform ) 
			{
				GameObject cameraParent = new GameObject ( "camParent" );
				cameraParent.transform.position = this.transform.position;
				this.transform.parent = cameraParent.transform;
				cameraParent.transform.Rotate ( Vector3.left, 90 );
			} 

		Input.gyro.enabled = true;

		WebCamTexture webCameraTexture = new WebCamTexture();
		webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
		webCameraTexture.Play();

	}
		
	void Update () 
	{

		Quaternion cameraRotation = new Quaternion ( Input.gyro.attitude.x, Input.gyro.attitude.y,
													-Input.gyro.attitude.z, -Input.gyro.attitude.w );
		this.transform.localRotation = cameraRotation;

	}
}
