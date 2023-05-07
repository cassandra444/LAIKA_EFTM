using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRangeChecker : MonoBehaviour
{
    public bool LaikaIsInFreezeRange;

   public void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Laika")
        {
            LaikaIsInFreezeRange = true;
        }
    }

    public void OnTriggerExit(Collider target)
    {
        if (target.tag == "Laika")
        {
            LaikaIsInFreezeRange = false;
        }
    }
}
