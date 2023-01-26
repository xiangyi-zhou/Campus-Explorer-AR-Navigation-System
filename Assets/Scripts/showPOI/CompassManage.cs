using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CompassManage : MonoBehaviour {

	public Text txt;
	public Transform cam;

	// Use this for initialization
	void Start () {
		Input.location.Start ();
		Input.compass.enabled = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = Input.compass.trueHeading.ToString ();
		txt.text = txt.text + "||cam>" + cam.eulerAngles.y;

		txt.text = txt.text + "||Pcam>" + cam.parent.transform.eulerAngles.y;
		txt.text = txt.text + "||Gcam>" + cam.parent.parent.transform.eulerAngles.y;
		transform.rotation = Quaternion.Euler(0, cam.eulerAngles.y-Input.compass.trueHeading, 0);


		//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,Input.compass.magneticHeading, 0),Time.deltaTime*2);
	}
}
