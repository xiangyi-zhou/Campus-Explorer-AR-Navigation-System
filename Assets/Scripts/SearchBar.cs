using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEditor;

public class SearchBar : MonoBehaviour
{
    public static PlaceInfo inputInfo = new PlaceInfo();

    private Dropdown My_dorpdown
    {
        get
        {
            return transform.Find("Dropdown").gameObject.GetComponent<Dropdown>();
        }
    }
    private InputField My_inputField
    {
        get
        {
            return transform.Find("InputField").gameObject.GetComponent<InputField>();
        }
    }

    private void HideInputField()
    {
        My_inputField.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        My_inputField.placeholder.gameObject.SetActive(false);
        My_inputField.textComponent.gameObject.SetActive(false);
    }

    private void ShowInputField()
    {
        My_inputField.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        My_inputField.placeholder.gameObject.SetActive(true);
        My_inputField.textComponent.gameObject.SetActive(true);
    }

    public void SetPlaceholder(string _text)
    {
        My_inputField.placeholder.GetComponent<Text>().text = _text;
    }
    public List<string> LibraryList = new List<string>();
    public void SetLibraryList(List<string> _list)
    {
        LibraryList = _list;
    }
    private List<string> ResultList = new List<string>();

    private void Start()
    {
        PointManager vars = Resources.Load<PointManager>("Test");
        //List<Data> pointsArray = new List<Data>();
        if (vars == null)
        {
            Debug.Log("Error: file null or missing\n");
        }
        else
        {
            // 测试
            Debug.Log(vars.pointsArray.Length + " " + vars.pointsArray[0].title + " " + vars.pointsArray[0].lat);
        }
        //pointsArray[0].title = "西操场";
        //pointsArray[0].lat = 30.477813;
        //pointsArray[0].lng = 114.305897;
        //pointsArray[1].title = "图书馆";
        //pointsArray[1].lat = 30.480143;
        //pointsArray[1].lng = 114.306998;
        //pointsArray[2].title = "东门";
        //pointsArray[2].lat = 30.480781;
        //pointsArray[2].lng = 114.313231;
        //pointsArray[3].title = "实训楼";
        //pointsArray[3].lat = 30.478798;
        //pointsArray[3].lng = 114.309182;
        //pointsArray[4].title = "中区操场";
        //pointsArray[4].lat = 30.481674;
        //pointsArray[4].lng = 114.309792;

        //for (int i = 0; i < pointsArray.Count; i++)
        //{
        //    LibraryList.Add(pointsArray[i].title);
        //    Debug.Log(LibraryList[i]);
        //}

        //Init();
        //My_dorpdown.onValueChanged.AddListener(delegate
        //{
        //    My_inputField.text = My_dorpdown.transform.Find("Label").GetComponent<Text>().text;
        //    HideInputField();
        //    // 选中下拉列表框后，显示对应信息
        //    for (int i = 0; i < pointsArray.Count; i++)
        //    {
        //        if (pointsArray[i].title == My_dorpdown.transform.Find("Label").GetComponent<Text>().text)
        //        {
        //            inputInfo.Name = pointsArray[i].title;
        //            inputInfo.Latitude = pointsArray[i].lat;
        //            inputInfo.Longitude = pointsArray[i].lng;
        //            EventCenter.Broadcast(EventDefine.SendInfoToPOI);
        //        }
        //    }
        //});
        //My_inputField.onEndEdit.AddListener(delegate
        //{
        //    Filter();
        //    ShowResult();
        //    My_inputField.text = My_dorpdown.transform.Find("Label").GetComponent<Text>().text;
        //    for (int i = 0; i < pointsArray.Count; i++)
        //    {
        //        if (pointsArray[i].title == My_dorpdown.transform.Find("Label").GetComponent<Text>().text)
        //        {
        //            inputInfo.Name = pointsArray[i].title;
        //            inputInfo.Latitude = pointsArray[i].lat;
        //            inputInfo.Longitude = pointsArray[i].lng;
        //            EventCenter.Broadcast(EventDefine.SendInfoToPOI);
        //        }
        //    }
        //});

        for (int i = 0; i < vars.pointsArray.Length; i++)
        {
            LibraryList.Add(vars.pointsArray[i].title);
        }

        Init();
        My_dorpdown.onValueChanged.AddListener(delegate
        {
            My_inputField.text = My_dorpdown.transform.Find("Label").GetComponent<Text>().text;
            HideInputField();
            // 选中下拉列表框后，显示对应信息
            for (int i = 0; i < vars.pointsArray.Length; i++)
            {
                if (vars.pointsArray[i].title == My_dorpdown.transform.Find("Label").GetComponent<Text>().text)
                {
                    inputInfo.Name = vars.pointsArray[i].title;
                    inputInfo.Latitude = vars.pointsArray[i].lat;
                    inputInfo.Longitude = vars.pointsArray[i].lng;
                    EventCenter.Broadcast(EventDefine.SendInfoToPOI);
                }
            }
        });
        My_inputField.onEndEdit.AddListener(delegate
        {
            Filter();
            ShowResult();
            My_inputField.text = My_dorpdown.transform.Find("Label").GetComponent<Text>().text;
            for (int i = 0; i < vars.pointsArray.Length; i++)
            {
                if (vars.pointsArray[i].title == My_dorpdown.transform.Find("Label").GetComponent<Text>().text)
                {
                    inputInfo.Name = vars.pointsArray[i].title;
                    inputInfo.Latitude = vars.pointsArray[i].lat;
                    inputInfo.Longitude = vars.pointsArray[i].lng;
                    EventCenter.Broadcast(EventDefine.SendInfoToPOI);
                }
            }
        });
    }

    private void Init()
    {
        LibraryList.ForEach(i => ResultList.Add(i));
        SetPlaceholder("请输入...");
    }

    private void Update()
    {
        if (My_inputField.isFocused && My_inputField.placeholder.gameObject.activeSelf == false)
        {
            ShowInputField();
        }
    }

    //筛选字符
    private void Filter()
    {
        ResultList = TextLenovo(My_inputField.textComponent.text, LibraryList);
    }

    private void ShowResult()
    {
        My_dorpdown.ClearOptions();
        My_dorpdown.AddOptions(ResultList);
        if (ResultList.Count != 0)
        {
            My_dorpdown.Show();
            //My_dorpdown.itemText.fontSize = 20;
        }
    }
    /// <summary>
    /// 文本联想
    /// </summary>
    /// <param 传入的字符="text_item"></param>
    /// <param 库数组="TextLibraryList"></param>
    /// <param 返回结果数组="temp_list"></param>
    /// <returns></returns>
    public List<string> TextLenovo(string text_item, List<string> TextLibraryList)
    {
        List<string> temp_list = new List<string>();
        foreach (string item in TextLibraryList)
        {
            if (item.Contains(text_item))
            {
                temp_list.Add(item);
            }
        }
        return temp_list;
    }
}