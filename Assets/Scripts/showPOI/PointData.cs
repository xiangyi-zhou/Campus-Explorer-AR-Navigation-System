using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : ScriptableObject
{
    //在Json最开始多写的那个data
    public Data[] pointsArray;
}
[System.Serializable]
public class Data
{
    public string title;
    public double lat;
    public double lng;
    public int id;
}
