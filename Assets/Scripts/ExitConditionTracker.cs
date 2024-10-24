using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ExitConditionTracker : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] TextMeshProUGUI findExitPrompt;
    [SerializeField] TextMeshProUGUI exitConditionPrompt;
    [SerializeField] float interactionRange = 3f;

    bool inRange = false;
    float textPromptTimer = 2f;
    ItemPickups keysObtained;
    void Start()
    {
        keysObtained = FindObjectOfType<ItemPickups>();
        findExitPrompt.enabled = false;
        exitConditionPrompt.enabled = false;
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
        if (keysObtained.keyCount == 4 && inRange && gameObject.tag != "Bar Door")
        {
            // Show prompt to press "E" here.
            if (Input.GetKeyDown(KeyCode.E))
            {                
                gameObject.SetActive(false);
            }            
        }
        else if (keysObtained.keyCount != 4 && inRange && gameObject.tag != "Bar Door")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                exitConditionPrompt.enabled = true;
                exitConditionPrompt.text = "Not enough keys to unlock.";
                StartCoroutine(DisablePrompt());
            }            
        }
        else if (inRange && gameObject.tag == "Bar Door")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                findExitPrompt.enabled = true;
                findExitPrompt.text = "Find another way out.";
                StartCoroutine(DisablePrompt());
            }            
        }
    }

    IEnumerator DisablePrompt()
    {
        yield return new WaitForSeconds(textPromptTimer);
        exitConditionPrompt.enabled = false;
        findExitPrompt.enabled = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
