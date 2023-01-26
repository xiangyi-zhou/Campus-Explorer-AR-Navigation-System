using System.Data;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ExcelReadEditor : Editor
{
    //读取的excel文件路径
    public static readonly string filePath = Application.streamingAssetsPath + "/Excel/" + "Test.xlsx";

    [MenuItem("Excel/读取测试数据")]
    public static void CreateSignInData()
    {
        PointManager manager = ScriptableObject.CreateInstance<PointManager>();

        //PointManager manager = CreateInstance<PointManager>(); //数据载体
        manager.pointsArray = ExcelRead.ReadDataExcel(filePath);

        string path = "Assets/Resources/" + "Test.asset"; //保存到Resources文件下
        AssetDatabase.CreateAsset(manager, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("读取数据成功");
    }
}
