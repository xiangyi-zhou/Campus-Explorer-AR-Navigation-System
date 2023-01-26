using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalmanFilter_Test : MonoBehaviour
{
    void Start()
    {
        float[] data = new float[] { 5, 6, 8, 3, 7, 6, 2 }; 
        KalmanFilter kf = new KalmanFilter();

        kf.SetQ(0.00001f); // 理想误差

        kf.SetFirst(data[0]); 

        string ss = "实际数值\t阵列滤波\t即时滤波\n\n";

        for (int i = 1; i < data.Length; i++)
        {
            float d = kf.Filter(data[i]); 
            ss += data[i] + "\t" + "/" + "\t" + d + "\n";
        }

        print(ss);
    }
}
