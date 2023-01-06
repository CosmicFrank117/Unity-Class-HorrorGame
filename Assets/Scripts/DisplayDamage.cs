using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas playerDamagedCanvas;
    [SerializeField] float timeOnScreen = 1f;

    private void Start()
    {
        playerDamagedCanvas.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(DisplayDamageCanvas());
    }

    private IEnumerator DisplayDamageCanvas()
    {
        playerDamagedCanvas.enabled = true;

        yield return new WaitForSeconds(timeOnScreen);

        playerDamagedCanvas.enabled = false;
    }
}
