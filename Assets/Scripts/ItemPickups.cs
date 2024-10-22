using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickups : MonoBehaviour
{
    public int keyCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            keyCount++;
            Destroy(other.gameObject);
            Debug.Log(keyCount + " num of keys collected.");
        }
    }
}
