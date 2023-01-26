using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;


public class TestLocation : MonoBehaviour, ILocationListener {

	public TencentLocationService location;
	private Transform canvasTras;
	private Button startBtn, stopBtn, authenFailBtn;


	int count = 0;
	public void OnLocationUpdate(string locInfo)
	{
		Debug.Log("TestLocation OnLocationUpdate: " + Util.ParseLocationInfo (locInfo).ToString());
		Text btnText = startBtn.transform.Find ("Text").GetComponent<Text> ();
		btnText.text = "第" + count++ + "次定位数据: " + locInfo;
	}

	void Awake()
	{
		
	}


	void Start () {

		Debug.Log ("TestLocation Start()");

		canvasTras = GameObject.Find ("Canvas").transform;

		startBtn = canvasTras.Find ("Start").GetComponent<Button>();
		startBtn.onClick.AddListener (StartCor);

		stopBtn = canvasTras.Find ("Stop").GetComponent<Button> ();
		stopBtn.onClick.AddListener (StopClick);

		authenFailBtn = canvasTras.Find ("Authentic").GetComponent<Button> ();
		authenFailBtn.onClick.AddListener (AuthenFailClick);
	}

	int time = 0;

	void Update () 
	{
		if (time == 0 && location.status == TencentLocationServiceStatus.Ready) {
			location.Start ();	

			time++;
		}
		else 
		{
			Debug.Log ("UnityLocation status: " + location.status + ", errorCode: " + location.errorCode);
		}
			
	}

	private void AuthenFailClick()
	{
		Debug.Log ("AuthenFailClick");
		PlayerPrefs.SetString (PlayerPrefsUtil.API_KEY, "");
	}


	public void StartCor()
	{
		if (location.status == TencentLocationServiceStatus.Ready) {
			location.Start ();
		}
	}

	public void StopClick()
	{
		Debug.Log ("TestLocation StopClick");
		location.Stop ();
	}


	//打印当前线程ID. 
	public static void PrintCurrentThread(string debugInfo)
	{
		Debug.Log (debugInfo + " current thread is: " + Thread.CurrentThread.ManagedThreadId.ToString ());
	}



}
