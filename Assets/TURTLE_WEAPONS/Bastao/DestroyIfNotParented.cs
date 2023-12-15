using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfNotParented : MonoBehaviour
{
    MeshRenderer rend;
    void Start()
    {
        rend = GetComponent<MeshRenderer>();

        if (transform.parent == null)
        {
            rend.enabled = false;
        }
    }
}
