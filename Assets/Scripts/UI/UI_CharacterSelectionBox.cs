using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterSelectionBox : MonoBehaviour
{

    public Animator animatorComponent;
    public Image imageBase;
    public Image imageAvatar;
    public Color color;
    public Sprite avatar;
    private Material materialBaseInstance;
    private Material materialAvatarInstance;

    //private void OnValidate()
    //{
    //    if(materialBaseInstance == null) Awake();
    //    imageBase.material.SetColor("_BaseColor", color);
    //    OnPointerExit();
    //}

    private void Awake()
    {
        materialBaseInstance = new Material(imageBase.material);
        materialAvatarInstance = new Material(imageAvatar.material);
        imageBase.material = materialBaseInstance;
        imageAvatar.material = materialAvatarInstance;
        imageBase.material.SetColor("_BaseColor", color);
        imageAvatar.sprite = avatar;
        OnPointerExit();
    }

    public void OnPointerEnter()
    {
        animatorComponent.transform.SetAsLastSibling();
        animatorComponent.SetTrigger("Enter");
        imageBase.material.SetInteger("_Active", 1);
        imageAvatar.material.SetInteger("_Active", 1);
    }

    public void OnPointerExit()
    {
        animatorComponent.SetTrigger("Exit");
        imageBase.material.SetInteger("_Active", 0);
        imageAvatar.material.SetInteger("_Active", 0);
    }
}
