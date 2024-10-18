using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickups : MonoBehaviour
{
    [SerializeField] GameObject keyItem;
    [SerializeField] GameObject puzzleItem;

    int keyCount = 0;
    void Update()
    {
        int currentKeyCount = keyCount;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            keyCount++;
        }
    }
}
