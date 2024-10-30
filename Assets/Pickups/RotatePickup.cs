using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePickup : MonoBehaviour
{
    [SerializeField] Vector3 rotationSpeed = new Vector3(0, 0, 50);    
        
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
