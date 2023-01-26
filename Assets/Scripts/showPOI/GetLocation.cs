using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System;

public class GetLocation : MonoBehaviour, ILocationListener
{
	public TencentLocationService location;
	// 从回调函数中获取locInfo的传递变量
	private string mylocInfo;
	public class LocPoint
	{
		public double Lat;
		public double Lon;
	}
	// 我的定位
	public static LocPoint myPoint;

	/// <summary>
	/// 通过回调实时获取定位结果
	/// </summary>
	/// <param name="locInfo"></param>
	public void OnLocationUpdate(string locInfo)
	{
		Debug.Log("TestLocation OnLocationUpdate: " + Util.ParseLocationInfo(locInfo).ToString());
		// 先将locInfo传出来
		mylocInfo = locInfo;
		// myPoint获得double类型的经纬度
		SetMyLocation(myPoint);
	}

	// myPoint类获得double类型的经纬度
	public void SetMyLocation(LocPoint myPoint)
	{
		string[] strlocArray = mylocInfo.Split(',');
		myPoint.Lat = Convert.ToDouble(strlocArray[0]);
		myPoint.Lon = Convert.ToDouble(strlocArray[1]);
	}

	void Start()
	{
		Debug.Log("TestLocation Start()");


	}

	int time = 0;
	void Update()
	{
		if (time == 0 && location.status == TencentLocationServiceStatus.Ready)
		{
			location.Start();

			time++;
		}
		else
		{
			Debug.Log("UnityLocation status: " + location.status + ", errorCode: " + location.errorCode);
		}

	}

	private void AuthenFailClick()
	{
		Debug.Log("AuthenFailClick");
		PlayerPrefs.SetString(PlayerPrefsUtil.API_KEY, "");
	}
	public void StartCor()
	{
		if (location.status == TencentLocationServiceStatus.Ready)
		{
			location.Start();
		}
	}

	public void StopClick()
	{
		Debug.Log("TestLocation StopClick");
		location.Stop();
	}

	//打印当前线程ID. 
	public static void PrintCurrentThread(string debugInfo)
	{
		Debug.Log(debugInfo + " current thread is: " + Thread.CurrentThread.ManagedThreadId.ToString());
	}
}
