using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _balloonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateBalloon",0.2f,2);
       
    }

    void InstantiateBalloon()
    {
        float random = Random.Range(-0.08f, 0.08f);
        Instantiate(_balloonPrefab, new Vector3(0, -1.5f, 0), gameObject.transform.rotation);
       
    }

}
