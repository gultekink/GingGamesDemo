using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private GameObject gameObject;
    [SerializeField] private float _speed;
    [SerializeField] private Material[] balloonMaterial;
 
    private Vector3 targetSize;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        var balloon = gameObject.GetComponent<Balloon>();

        _rigidbody = GetComponent<Rigidbody>();
        
        targetSize = new Vector3(0.5f, 0.5f, 0.5f);
        gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        GameObject child = transform.GetChild(0).gameObject;
        child.GetComponent<MeshRenderer>().material = balloon.Material[Random.Range(0, 5)];
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AddForce();
        RopeControl();

        if (gameObject.transform.localScale.magnitude <= targetSize.magnitude)
        {
            gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
       
    }

    void RopeControl()
    {
        var balloon = gameObject.GetComponent<Balloon>();

        destination.position = balloon.BalloonTransform.position;

        balloon.LineRenderer.SetPosition(0, new Vector3(0, -1.84f, 0));
        balloon.LineRenderer.SetPosition(1, destination.position);
        balloon.LineRenderer.SetWidth(.5f, .5f);

        balloon.LineRenderer.startWidth = 0.05f;
        balloon.LineRenderer.endWidth = 0.05f;
    }

    void AddForce()
    {
        _rigidbody.AddForce(Vector3.up * _speed, ForceMode.Impulse);
    }

}