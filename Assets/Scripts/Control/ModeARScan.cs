using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeARScan : MonoBehaviour
{
    public GameObject ScanCulturalCard;
    public GameObject ScanARvideo;
    public GameObject ScanARmodel;
    public GameObject ScanARvirtualBtn;

    void Start()
    {
        EventCenter.AddListener(EventDefine.ShowARVirtualBtn, ShowARVirtualBtn);
        EventCenter.AddListener(EventDefine.ShowARvideo, ShowARvideo);
        EventCenter.AddListener(EventDefine.ShowARmodel, ShowARmodel);
        EventCenter.AddListener(EventDefine.ShowARcard, ShowARcard);
    }

    private void ShowARVirtualBtn()
    {
        ScanCulturalCard.SetActive(false);
        ScanARvideo.SetActive(false);
        ScanARmodel.SetActive(false);
        ScanARvirtualBtn.SetActive(true);
    }
    private void ShowARvideo()
    {
        ScanCulturalCard.SetActive(false);
        ScanARvideo.SetActive(true);
        ScanARmodel.SetActive(false);
        ScanARvirtualBtn.SetActive(false);
    }
    private void ShowARmodel()
    {
        ScanCulturalCard.SetActive(false);
        ScanARvideo.SetActive(false);
        ScanARmodel.SetActive(true);
        ScanARvirtualBtn.SetActive(false);
    }
    private void ShowARcard()
    {
        ScanCulturalCard.SetActive(true);
        ScanARvideo.SetActive(false);
        ScanARmodel.SetActive(false);
        ScanARvirtualBtn.SetActive(false);
    }
    private void CloseARscan()
    {
        ScanCulturalCard.SetActive(false);
        ScanARvideo.SetActive(false);
        ScanARmodel.SetActive(false);
        ScanARvirtualBtn.SetActive(false);
    }
}
