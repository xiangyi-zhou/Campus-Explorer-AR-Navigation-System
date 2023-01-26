using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    // 通过地图上的两个坐标计算距离
    public class MapHelper
    {
        // 地球半径
        private const double EarthRadius = 6378.137;
        // 经纬度转化成弧度
        private static double Rad(double d)
        {
            return d * Math.PI / 180d;
        }
        // 计算两个坐标点之间的距离
        public static double GetDistance(double firstLatitude, double firstLongitude, double secondLatitude, double secondLongitude)
        {
            var firstRadLat = Rad(firstLatitude);
            var firstRadLng = Rad(firstLongitude);
            var secondRadLat = Rad(secondLatitude);
            var secondRadLng = Rad(secondLongitude);
            var a = firstRadLat - secondRadLat;
            var b = firstRadLng - secondRadLng;
            var cal = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(firstRadLat)
                * Math.Cos(secondRadLat) * Math.Pow(Math.Sin(b / 2), 2))) * EarthRadius;
            // 返回两点之间的距离，单位：米
            var result = Math.Round(cal * 10000) / 10000 * 1000;
            return result;
        }
        /// <summary>
        /// 计算两个坐标点之间的距离
        /// </summary>
        /// <param name="firstPoint">第一个坐标点的（纬度,经度）</param>
        /// <param name="secondPoint">第二个坐标点的（纬度,经度）</param>
        /// <returns>返回两点之间的距离，单位：米</returns>
        public static double GetPointDistance(string firstPoint, string secondPoint)
        {
            var firstArray = firstPoint.Split(',');
            var secondArray = secondPoint.Split(',');
            var firstLatitude = Convert.ToDouble(firstArray[0].Trim());
            var firstLongitude = Convert.ToDouble(firstArray[1].Trim());
            var secondLatitude = Convert.ToDouble(secondArray[0].Trim());
            var secondLongitude = Convert.ToDouble(secondArray[1].Trim());
            return GetDistance(firstLatitude, firstLongitude, secondLatitude, secondLongitude);
        }
    }
}
