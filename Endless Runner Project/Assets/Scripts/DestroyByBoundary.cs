using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    bool characterInQuicksand;

    void OnTriggerExit2D(Collider2D other)
    {
        characterInQuicksand = false;
        other.gameObject.SetActive(false);
    }
}
