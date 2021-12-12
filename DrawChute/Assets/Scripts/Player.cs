using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _rightSpawn;

    public Transform RightSpawn
    {
        get
        {
            return _rightSpawn;
        }
    }
 
}
