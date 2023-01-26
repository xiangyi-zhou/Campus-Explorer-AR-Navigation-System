using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebNavigator : MonoBehaviour
{
    UniWebView webView;
    public string strWebCulture;
    public string strWebMain;
    public string strWeb;
    public Slider navSlider;

    void Start()
    {
        //strWebCulture = "https://apis.map.qq.com/place_cloud/search/nearby?location&filter=x.category=2&table_id=0oBhd1VBje6oiBLvn1&key=BTPBZ-Y3SWX-ILX4Y-TVIT6-XVOUH-4DB74";
        //strWebMain = "https://apis.map.qq.com/place_cloud/search/nearby?location&filter=x.category=1&table_id=0oBhd1VBje6oiBLvn1&key=BTPBZ-Y3SWX-ILX4Y-TVIT6-XVOUH-4DB74";
        strWeb = "https://t.map.qq.com/HSYgFRun";

        EventCenter.AddListener(EventDefine.ShowNavWeb, NavWebSearch);
        EventCenter.AddListener(EventDefine.NavViewReset, NavViewReset);
        EventCenter.AddListener(EventDefine.NavViewMode, NavViewMode);
        EventCenter.AddListener(EventDefine.ChangeNavViewAlpha, ChangeNavViewAlpha);
        EventCenter.AddListener(EventDefine.ModeScan, CloseView);
        EventCenter.AddListener(EventDefine.ModePOI, CloseView);
    }

    void Update()
    {
        
    }
    /// <summary>
    /// 发出url请求 显示导航界面
    /// </summary>
    public void NavWebSearch()
    {
        var webViewGameObject = new GameObject("UniWebView");
        webView = webViewGameObject.AddComponent<UniWebView>();

        webView.Frame = new Rect(0, Screen.height / 13 + Screen.height / 39, Screen.width, Screen.height - Screen.height * 2 / 13 - Screen.height / 39);
        webView.Load(strWeb);
        webView.Show();
    }
    public void NavViewReset()
    {
        var webViewGameObject = new GameObject("UniWebView");
        webView = webViewGameObject.AddComponent<UniWebView>();

        webView.Frame = new Rect(0, Screen.height / 13 + Screen.height / 39, Screen.width, Screen.height - Screen.height * 2 / 13 - Screen.height / 39);
        webView.Load(strWeb);
        webView.Alpha = 1;
        webView.Show();
    }
    public void NavViewMode()
    {
        var webViewGameObject = new GameObject("UniWebView");
        webView = webViewGameObject.AddComponent<UniWebView>();

        webView.Frame = new Rect(0, Screen.height / 13 + Screen.height / 39, Screen.width, Screen.height - Screen.height * 2 / 13 - Screen.height / 39);
        webView.Load(strWeb);
        webView.Alpha = 0.5f;
        webView.Show();
    }
    public void ChangeNavViewAlpha()
    {
        var webViewGameObject = new GameObject("UniWebView");
        webView = webViewGameObject.AddComponent<UniWebView>();

        webView.Frame = new Rect(0, Screen.height / 13 + Screen.height / 39, Screen.width, Screen.height - Screen.height * 2 / 13 - Screen.height / 39);
        webView.Load(strWeb);
        webView.Alpha = navSlider.value; 
        webView.Show();
    }
    public void CloseView()
    {
        //webView.Stop();
    }
}
