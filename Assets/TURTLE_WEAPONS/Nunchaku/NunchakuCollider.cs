using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class NunchakuCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Nunchaku")
        {
            Destroy(gameObject);
        }
    }
}
