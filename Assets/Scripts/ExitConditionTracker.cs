using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ExitConditionTracker : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] float interactionRange = 3f;

    bool inRange = false;
    ItemPickups keysObtained;
    void Start()
    {
        keysObtained = FindObjectOfType<ItemPickups>();
    }

    void Update()
    {
        float distance = Vector3.Distance(playerObject.transform.position, transform.position);

        if (distance <= interactionRange)
        {
            inRange = true;
            InteractWithDoor();
        }
        else
        {
            inRange = false;
        }
        
    }

    void InteractWithDoor()
    {
        if (keysObtained.keyCount == 3 && inRange)
        {
            // Show prompt to press "E" here.
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("You have pressed E on the door.");
                gameObject.SetActive(false);
            }            
        }
        else if (keysObtained.keyCount != 3 && inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Not enough keys to unlock.");
            }            
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
