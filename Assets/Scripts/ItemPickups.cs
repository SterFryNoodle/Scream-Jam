using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemPickups : MonoBehaviour
{
    public int keyCount = 0;    

    [SerializeField] TextMeshProUGUI keyAmt;
    void Start()
    {
        keyAmt.text = "Keys: " + keyCount.ToString() + "/4";
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            keyCount++;
            Destroy(other.gameObject);            
            keyAmt.text = "Keys: " + keyCount.ToString() + "/4";
        }
    }    
}
