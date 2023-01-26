using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KalmanFilter
{
    //public float[] Filter(float[] z)
    //{
    //    float[] xhat = new float[z.Length];
    //    xhat[0] = z[0];
    //    float P = 1;

    //    for (int k = 1; k < xhat.Length; k++)
    //    {
    //        float xhatminus = xhat[k - 1];
    //        float Pminus = P + Q;
    //        float K = Pminus / (Pminus + R);
    //        xhat[k] = xhatminus + K * (z[k] - xhatminus);
    //        P = (1 - K) * Pminus;
    //    }
    //    return xhat;
    //}
    bool isFirst = true;
    bool haveSetFirst = false;
    float xhat; // x的估计量
    float P;    // 误差协方差
    float z0;   // 噪声测量初始值
    float Q = 1e-5f; // 过程噪声协方差取0.00001
    float R = 0.0001f; // 测量噪声协方差

    // 设置初始值
    public void SetFirst(float z0)
    {
        this.z0 = z0;
        haveSetFirst = true;
    }

    // 理想误差，数值越小，滤波效果越好
    public void SetQ(float Q)
    {
        this.Q = Q;
    }
    //// 實際誤差
    //public void SetR(float R)
    //{
    //    this.R = R;
    //}
    public float Filter(float z1)
    {
        if (isFirst)
        {
            isFirst = false;
            if (haveSetFirst == false) z0 = z1;
            xhat = z0;
            P = 1;
        }
        float xhatminus = xhat;
        // 预测误差协方差
        float Pminus = P + Q; 
        float K = Pminus / (Pminus + R);
        // 计算估计值xhat
        xhat = xhatminus + K * (z1 - xhatminus);
        // 计算误差协方差
        P = (1 - K) * Pminus;
        return xhat;
    }
    // 重置
    public void Reset()
    {
        isFirst = true;
        haveSetFirst = false;
        xhat = 0;
        P = 0;
        z0 = 0;
        Q = 1e-5f; // 0.00001
        R = 0.0001f;
    }
}

