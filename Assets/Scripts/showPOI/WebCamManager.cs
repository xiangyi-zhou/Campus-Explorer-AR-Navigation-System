using UnityEngine;
using System.Collections;

public class WebCamManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

		WebCamTexture webcamTexture = new WebCamTexture ();

		//如果有后置摄像头，调用后置摄像头
		for (int i = 0; i < WebCamTexture.devices.Length; i++) {
			if (!WebCamTexture.devices [i].isFrontFacing) {
				webcamTexture.deviceName = WebCamTexture.devices [i].name;
				break;
			}
		}

		Renderer renderer = GetComponent<Renderer>();  
		renderer.material.mainTexture = webcamTexture;  
		webcamTexture.Play();  
	}
}
