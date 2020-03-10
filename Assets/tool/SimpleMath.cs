using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SimpleMath
{

    /**************************************************************三维方法**************************************************************************/
    /// <summary>
    /// 返回球面上一点
    /// </summary>
    /// <param name="center">球心</param>
    /// <param name="radius">半径</param>
    /// <param name="sita">极角/经度(弧度制)</param>
    /// <param name="kesi">方位角/维度(弧度制)</param>
    /// <returns></returns>
    public static Vector3 Ball_XYZ(Vector3 center, float radius, float sita, float kesi)
    {
        float r2d = Mathf.Rad2Deg;
        float x = center.x + radius * Mathf.Sin(kesi * r2d) * Mathf.Cos(sita * r2d);
        float y = center.y + radius * Mathf.Sin(kesi * r2d) * Mathf.Sin(sita * r2d);
        float z = center.z + radius * Mathf.Cos(kesi * r2d);
        return new Vector3(x, y, z);
    }

    /**************************************************************平面方法**************************************************************************/
    /// <summary>
    /// 椭圆x坐标
    /// </summary>
    /// <param name="a">长半轴</param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static float Ellipse_X(float a, float angle)
    {
        return a * Mathf.Cos(angle * Mathf.Rad2Deg);
    }

    /// <summary>
    /// 椭圆y坐标
    /// </summary>
    /// <param name="b">短半轴</param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static float Ellipse_Y(float b, float angle)
    {
        return b * Mathf.Sin(angle * Mathf.Rad2Deg);
    }


    /// <summary>
    /// 圆x坐标
    /// </summary>
    /// <param name="a">圆心x坐标</param>
    /// <param name="r">半径</param>
    /// <param name="angle">角度</param>
    /// <returns></returns>
    public static float Circular_X(float a, float r, float angle)
    {
        return (a + r * Mathf.Cos(angle * Mathf.Rad2Deg));
    }

    /// <summary>
    /// 圆y坐标
    /// </summary>
    /// <param name="b">圆心y坐标</param>
    /// <param name="r">半径</param>
    /// <param name="angle">角度</param>
    /// <returns></returns>
    public static float Circular_Y(float b, float r, float angle)
    {
        return (b + r * Mathf.Sin(angle * Mathf.Rad2Deg));
    }

    /// <summary>
    /// 双曲线x坐标
    /// </summary>
    /// <param name="a">实轴</param>
    /// <param name="angle">角度</param>
    /// <returns></returns>
    public static float Hyperbola_X(float a, float angle)
    {
        return a * 1 / Mathf.Cos(angle * Mathf.Rad2Deg);
    }

    /// <summary>
    /// 双曲线y坐标
    /// </summary>
    /// <param name="a">虚轴</param>
    /// <param name="angle">角度</param>
    /// <returns></returns>
    public static float Hyperbola_Y(float b, float angle)
    {
        return b * Mathf.Tan(angle * Mathf.Rad2Deg);
    }
}
