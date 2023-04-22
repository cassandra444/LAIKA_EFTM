using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRangeChecker : MonoBehaviour
{
    public LaikaManager _laikaManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laika"))
        {
            _laikaManager._laikaIsInFreezeRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Laika"))
        {
            _laikaManager._laikaIsInFreezeRange = false;
        }
    }
}
