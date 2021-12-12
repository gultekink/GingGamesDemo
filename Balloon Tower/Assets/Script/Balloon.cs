using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private Rigidbody _balloonRigidbody;
    [SerializeField] private Transform _balloonTransform;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private SpringJoint _sprintJoint;
    [SerializeField] private Material[] _material;

    public Rigidbody BalloonRigidbody
    {
        get
        {
            return _balloonRigidbody;
        }
    }
    public Transform BalloonTransform
    {
        get
        {
            return _balloonTransform;
        }
    }
    public LineRenderer LineRenderer
    {
        get
        {
            return _lineRenderer;
        }
    }

    public Material[] Material
    {
        get
        {
            return _material;
        }
    }
}
