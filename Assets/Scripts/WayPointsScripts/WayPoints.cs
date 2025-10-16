using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class WayPoints : MonoBehaviour, IPoolingObject
{
    [SerializeField] private SplineAnimate spline;
    public GameObject target;
    [SerializeField] private float speedRate = 2;
    
    

    public void OnBirth()
    {
    }

    public void SetSpline(float speed)
    {
        spline.Duration = speedRate / speed;
    }

    public void OnDeathInit()
    {
    }
    
}