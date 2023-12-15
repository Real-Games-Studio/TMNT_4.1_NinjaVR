using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NunchakuDisabler : MonoBehaviour
{
    private MeshRenderer[] renderArray = null;
    public ChainAnimator chainanim;

    private void Awake()
    {
        renderArray = transform.GetComponentsInChildren<MeshRenderer>();
    }

    public void MakeVisible()
    {
        SetRenderArrayEnableValue(true);
    }

    public void MakeInvisible()
    {
        SetRenderArrayEnableValue(false);
    }

    private void SetRenderArrayEnableValue(bool value)
    {
        Debug.Log("tentou apagar");
        chainanim.enabled = value;
        for (int n = 0; n < renderArray.Length; n++)
        {
            renderArray[n].enabled = value;
            Debug.Log("apagou");
        }
    }
}
