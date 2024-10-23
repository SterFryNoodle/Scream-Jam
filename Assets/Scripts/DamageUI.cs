using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    [SerializeField] Canvas takeDmgCanvas;
    [SerializeField] float impactTimer = 0.3f;
    [SerializeField] float staticFlickerSpeed = 12f;

    void Start()
    {
        takeDmgCanvas.GetComponentInChildren<CanvasGroup>().alpha = 0f;
    }

    public void ShowDamageUI()
    {
        StartCoroutine(ShowStatic());
    }

    IEnumerator ShowStatic()
    {
        float time = Mathf.PingPong(Time.time * staticFlickerSpeed, 1.0f);
        takeDmgCanvas.GetComponentInChildren<CanvasGroup>().alpha = Mathf.Lerp(0, 1, time);
        yield return new WaitForSeconds(impactTimer);
        takeDmgCanvas.GetComponentInChildren<CanvasGroup>().alpha = 0f;
    }
}
