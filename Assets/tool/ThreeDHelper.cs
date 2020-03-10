using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.CodeEditor;

public enum OperateType
{
    Auto = 0,
    Manual = 1
}

public class ThreeDHelper : MonoBehaviour
{
    /*************通用*************/
    [Header("通用参数")]
    [Tooltip("是否启用")]
    public bool isActive;

    [Tooltip("球心")]
    public Transform ballCenter; //旋转球心

    [Tooltip("球半径")]
    [Range(5, 30)]
    public float ballRadius;

    [Tooltip("观察类型")]
    public OperateType oprType; //观察类型

    private Vector3 cameraPos;//摄像机位置

    /*************手动*************/
    [Header("手动观察参数")]

    [Range(-10f, -2f)]
    [Tooltip("最近观察距离")]
    public float zoomInMax;

    [Range(-100f, -40f)]
    [Tooltip("最远观察距离")]
    public float zoomOutMin;


    /*************自动*************/
    [Header("自动旋转参数")]
    //二维曲线
    //[Tooltip("椭圆长轴长")]
    //public float Ellipse_a;
    //[Tooltip("椭圆短轴长")]
    //public float Ellipse_b;
    //[Tooltip("双曲线实轴")]
    //public float Hyperbola_a;
    //[Tooltip("双曲线虚轴")]
    //public float Hyperbola_b;
    //[Tooltip("角度")]
    //float angle;
    //[Tooltip("圆半径")]
    //public float ballRadius;

    //三维曲面
    [Tooltip("极角θ 经度")]
    public float polar_sita = 0;

    [Tooltip("方位角φ 维度")]
    public float azimu_kesi = 0;

    /**************************************************************生命周期**************************************************************************/
    private void Start()
    {
        if (!isActive) return;
        cameraPos = new Vector3(0, 0, -ballRadius);
        transform.position = cameraPos;
    }

    private void Update()
    {
        if (!isActive) return;
        if (oprType == OperateType.Manual)
        {
            manualZoom();
            manualRotate();
        }
        else
        {
            autoMove();
        }
    }

    /**************************************************************自动操作观测轨迹**************************************************************************/
    //二维图形方程
    /// <summary>
    ///圆的参数方程 x=a+r cosθ y=b+r sinθ（θ∈ [0，2π) ） (a,b) 为圆心坐标，r 为圆半径，θ 为参数，(x,y) 为经过点的坐标
    ///椭圆的参数方程 x=a cosθ　 y=b sinθ（θ∈[0，2π）） a为长半轴长 b为短半轴长 θ为参数
    ///双曲线的参数方程 x=a secθ （正割） y=b tanθ a为实半轴长 b为虚半轴长 θ为参数    secθ （正割）即1/cosθ                   
    /// </summary>

    //三维图形方程
    /// <summary>
    ///1.球的参数方程
    ///(x-x0)^2+ (y-y0)^2+ (z-z0)^2=r^2
    ///=>1.x=x0+r*sinφ*cosθ
    ///=>2.y=y0+r*sinφ*sinθ
    ///=>3.z=z0+r*cosφ                           θ∈ [0，2π)  ,   φ∈ [0，π] 
    /// (x0,y0,z0) 为圆心坐标，r 为圆半径，θ 为极角（经度）φ为方位角(维度)
    /// </summary>
    private void autoMove()
    {
        //角度
        //angle += Time.deltaTime / 50f;
        //椭圆运动
        //float ellipseX = SimpleMath.Ellipse_X(Ellipse_a, angle);
        //float ellipsY = SimpleMath.Ellipse_Y(Ellipse_b, angle);
        //autoMoveUpdate(ellipseX,ellipsY,0);
        //双曲线运动
        //float hyperbolaX = SimpleMath.Hyperbola_X(Hyperbola_a, angle);
        //float hyperbolaY = SimpleMath.Hyperbola_Y(Hyperbola_b, angle);
        //autoMoveUpdate(hyperbolaX, hyperbolaY,0);
        //圆运动
        //float circleX = SimpleMath.Circular_X(0, ballRadius, angle);
        //float circleY = SimpleMath.Circular_Y(0, ballRadius, angle);
        //autoMoveUpdate(circleX, circleY, 0);

        //球面运动
        polar_sita += Time.deltaTime / 50f;
        azimu_kesi += Time.deltaTime / 30;
        Vector3 point = SimpleMath.Ball_XYZ(ballCenter.position, ballRadius, polar_sita, azimu_kesi);
        autoMoveUpdate(point.x, point.y, point.z);
        transform.LookAt(ballCenter);
    }

    private void autoMoveUpdate(float x, float y, float z)
    {
        cameraPos.x = x;
        cameraPos.y = y;
        cameraPos.z = z;
        transform.position = cameraPos;
    }

    /**************************************************************手动操作观测轨迹**************************************************************************/
    private void manualZoom()//镜头的远离和接近
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (transform.position.z >= zoomInMax) return;
            transform.Translate(Vector3.forward * 1f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (transform.position.z <= zoomOutMin) return;
            transform.Translate(Vector3.forward * -1f);
        }
    }

    private void manualRotate()//摄像机的旋转
    {
        var mouse_x = Input.GetAxis("Mouse X");//获取鼠标X轴移动
        var mouse_y = -Input.GetAxis("Mouse Y");//获取鼠标Y轴移动
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.RotateAround(ballCenter.position, Vector3.up, mouse_x * 5);
            transform.RotateAround(ballCenter.position, transform.right, mouse_y * 5);
        }
    }

}
