using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private EdgeCollider2D _edgeCollider;
    [SerializeField] private Rigidbody2D _brushRigidbody;

    public LineRenderer LineRenderer
    {
        get
        {
            return _lineRenderer;
        }
    }

    public EdgeCollider2D EdgeCollider
    {
        get
        {
            return _edgeCollider;
        }
    }

    public Rigidbody2D BrushRigidbody
    {
        get
        {
            return _brushRigidbody;
        }
    }

}
