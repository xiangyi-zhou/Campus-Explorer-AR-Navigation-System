using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button btn_showPOI;
    public Button btn_navigator;
    public Button btn_ARscan;
    public Button btn_navReset;
    public Button btn_navMode;
    public Slider slider_nav;

    public Button btnARVirtualBtn;
    public Button btnARmodel;
    public Button btnARcard;
    public Button btnARvideo;

    public RectTransform BtnGroupDown;
    public RectTransform SearchBarUp;

    public RectTransform PanelNavigator;
    public RectTransform PanelARsacn;

    public Camera ARcamera;

    public int BtnState;    // 1:Navigator 2:ShowPOI 3:ARscan
    public static int ARmodeState;    // 1:virtual 2:video 3:model 4:card
    public int BtnNavState; // 1:Main 2:Culture 3:ALL

    void Start()
    {
        btn_navigator.onClick.AddListener(ModeNavigator);
        btn_showPOI.onClick.AddListener(ModeShowPOI);
        btn_ARscan.onClick.AddListener(ModeARscan);
        btn_navReset.onClick.AddListener(OnButtonNavReset);
        btn_navMode.onClick.AddListener(OnButtonNavMode);

        btnARVirtualBtn.onClick.AddListener(OnButtonVirtualBtn);
        btnARmodel.onClick.AddListener(OnButtonARmodel);
        btnARcard.onClick.AddListener(OnButtonARcard);
        btnARvideo.onClick.AddListener(OnButtonARvideo);

        slider_nav.value = 1; 
    }
    public void ModeNavigator()
    {
        BtnState = 1;
        Debug.Log(BtnState);
        PanelNavigator.gameObject.SetActive(true);
        PanelARsacn.gameObject.SetActive(false);
        EventCenter.Broadcast(EventDefine.ShowNavWeb);
        Debug.Log("NavigatorAll");
    }
    public void ModeShowPOI()
    {
        BtnState = 2;
        EventCenter.Broadcast(EventDefine.ModePOI);
        PanelNavigator.gameObject.SetActive(false);
        PanelARsacn.gameObject.SetActive(false);
        Debug.Log(BtnState);
        SceneManager.LoadScene("POI");
    }
    public void ModeARscan()
    {
        BtnState = 3;
        EventCenter.Broadcast(EventDefine.ModeScan);
        PanelNavigator.gameObject.SetActive(false);
        PanelARsacn.gameObject.SetActive(true);
        Debug.Log(BtnState);
    }

    private void OnButtonNavReset()
    {
        slider_nav.value = 1;
        EventCenter.Broadcast(EventDefine.NavViewReset);
        Debug.Log("NavViewReset");
    }
    private void OnButtonNavMode()
    {
        slider_nav.value = 0.5f;
        EventCenter.Broadcast(EventDefine.NavViewMode);
        Debug.Log("NavViewMode");
    }
    private void OnButtonVirtualBtn()
    {
        ARmodeState = 1;
        EventCenter.Broadcast(EventDefine.ShowARVirtualBtn);
        Debug.Log("OnButtonVirtualBtn");
    }
    private void OnButtonARvideo()
    {
        ARmodeState = 2;
        EventCenter.Broadcast(EventDefine.ShowARvideo);
        Debug.Log("OnButtonARvideo");
    }
    private void OnButtonARmodel()
    {
        ARmodeState = 3;
        EventCenter.Broadcast(EventDefine.ShowARmodel);
        Debug.Log("OnButtonARmodel");
    }
    private void OnButtonARcard()
    {
        ARmodeState = 4;
        EventCenter.Broadcast(EventDefine.ShowARcard);
        Debug.Log("OnButtonARcard");
    }
}
