using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	private bool gyroBool;
	private Gyroscope gyro;
	private Quaternion rotFix;

	public void Start ()
	{
		Transform currentParent = transform.parent;
		GameObject camParent = new GameObject ("GyroCamParent");
		camParent.transform.position = transform.position;
		transform.parent = camParent.transform;
		GameObject camGrandparent = new GameObject ("GyroCamGrandParent");
		camGrandparent.transform.position = transform.position;
		camParent.transform.parent = camGrandparent.transform;
		camGrandparent.transform.parent = currentParent;

		gyroBool = SystemInfo.supportsGyroscope;

		if (gyroBool) {

			gyro = Input.gyro;
			gyro.enabled = true;

			if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
				camParent.transform.eulerAngles = new Vector3 (90, 90, 0);
			} else if (Screen.orientation == ScreenOrientation.Portrait) {
				camParent.transform.eulerAngles = new Vector3 (90, 180, 0);
			} else if (Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
				camParent.transform.eulerAngles = new Vector3 (90, 180, 0);
			} else if (Screen.orientation == ScreenOrientation.LandscapeRight) {
				camParent.transform.eulerAngles = new Vector3 (90, 180, 0);
			} else {
				camParent.transform.eulerAngles = new Vector3 (90, 180, 0);
			}

			if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
				rotFix = new Quaternion (0, 0,0.7071f,0.7071f);
			} else if (Screen.orientation == ScreenOrientation.Portrait) {
				rotFix = new Quaternion (0, 0, 1, 0);
			} else if (Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
				rotFix = new Quaternion (0, 0, 1, 0);
			} else if (Screen.orientation == ScreenOrientation.LandscapeRight) {
				rotFix = new Quaternion (0, 0, 1, 0);
			} else {
				rotFix = new Quaternion (0, 0, 1, 0);
			}

			//Screen.sleepTimeout = 0;
		} else {
			#if UNITY_EDITOR
			print("NO GYRO");
			#endif
		}
	}

	public void Update ()
	{
		if (gyroBool) {
			Quaternion quatMap;
			#if UNITY_IOS
			quatMap = gyro.attitude;
			#elif UNITY_ANDROID
			quatMap = new Quaternion(gyro.attitude.x,gyro.attitude.y,gyro.attitude.z,gyro.attitude.w);
			#endif
			transform.localRotation = quatMap * rotFix;
		}
	}
}
