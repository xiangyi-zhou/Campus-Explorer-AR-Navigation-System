using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Button btn_search;
    public Button btn_show;
    UniWebView webView;

    // Use this for initialization
    void Start()
    {
        btn_search.onClick.AddListener(OnButtonSearch);
        btn_show.onClick.AddListener(OnButtonShow);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnButtonSearch()
    {
        var webViewGameObject = new GameObject("UniWebView");
        webView = webViewGameObject.AddComponent<UniWebView>();

        webView.Frame = new Rect(0, 0, Screen.width, Screen.height); // 1
        webView.Load("https://apis.map.qq.com/place_cloud/search/nearby?location=30.480787,114.30919&radius=1000&auto_extend=1&table_id=0oBhd1VBje6oiBLvn1&key=BTPBZ-Y3SWX-ILX4Y-TVIT6-XVOUH-4DB74");       // 2
                                                                                                                                                                                           
        //https://t.map.qq.com/HSYgFRun
        webView.Show();

    }
    public void OnButtonShow()
    {
        var webViewGameObject = new GameObject("UniWebView");
        webView = webViewGameObject.AddComponent<UniWebView>();

        webView.Frame = new Rect(0, 0, Screen.width, Screen.height); // 1
        webView.Load("https://t.map.qq.com/HSYgFRun");       // 2
                                                                             
        //https://t.map.qq.com/HSYgFRun
        webView.Show();

    }
}