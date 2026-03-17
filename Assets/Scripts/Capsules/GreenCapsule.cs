using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCapsule : MonoBehaviour
{
    public GoodTouch gt;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gt.SetGotCapsule(true);
            gameObject.SetActive(false);
        }
    }
}
