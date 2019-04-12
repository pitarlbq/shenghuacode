using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public class BaiDuHelper
    {
        static double DEF_PI = 3.14159265359; // PI
        static double DEF_2PI = 6.28318530712; // 2*PI
        static double DEF_PI180 = 0.01745329252; // PI/180.0
        static double DEF_R = 6370693.5; // radius of earth
        public static decimal GetDistance(double lon1, double lat1, double lon2, double lat2)
        {
            double result = GetShortDistance(lon1, lat1, lon2, lat2);
            if (result > 10000)
            {
                result = GetLongDistance(lon1, lat1, lon2, lat2);
            }
            if (result > 0)
            {
                return Convert.ToDecimal(result);
            }
            return 0;
        } 
        //适用于近距离
        public static double GetShortDistance(double lon1, double lat1, double lon2, double lat2)
        {
            double ew1, ns1, ew2, ns2;
            double dx, dy, dew;
            double distance;
            // 角度转换为弧度
            ew1 = lon1 * DEF_PI180;
            ns1 = lat1 * DEF_PI180;
            ew2 = lon2 * DEF_PI180;
            ns2 = lat2 * DEF_PI180;
            // 经度差
            dew = ew1 - ew2;
            // 若跨东经和西经180 度，进行调整
            if (dew > DEF_PI)
                dew = DEF_2PI - dew;
            else if (dew < -DEF_PI)
                dew = DEF_2PI + dew;
            dx = DEF_R * Math.Cos(ns1) * dew; // 东西方向长度(在纬度圈上的投影长度)
            dy = DEF_R * (ns1 - ns2); // 南北方向长度(在经度圈上的投影长度)
            // 勾股定理求斜边长
            distance = Math.Sqrt(dx * dx + dy * dy);
            return distance;
        }
        //适用于远距离
        public static double GetLongDistance(double lon1, double lat1, double lon2, double lat2)
        {
            double ew1, ns1, ew2, ns2;
            double distance;
            // 角度转换为弧度
            ew1 = lon1 * DEF_PI180;
            ns1 = lat1 * DEF_PI180;
            ew2 = lon2 * DEF_PI180;
            ns2 = lat2 * DEF_PI180;
            // 求大圆劣弧与球心所夹的角(弧度)
            distance = Math.Sin(ns1) * Math.Sin(ns2) + Math.Cos(ns1) * Math.Cos(ns2) * Math.Cos(ew1 - ew2);
            // 调整到[-1..1]范围内，避免溢出
            if (distance > 1.0)
                distance = 1.0;
            else if (distance < -1.0)
                distance = -1.0;
            // 求大圆劣弧长度
            distance = DEF_R * Math.Acos(distance);
            return distance;
        }
    }
}
