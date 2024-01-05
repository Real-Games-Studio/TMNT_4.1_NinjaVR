using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class MenuSelectionTest : MonoBehaviour
{
    [SerializeField] private UnityEngine.InputSystem.InputActionProperty Lgrip, Rgrip;
    [SerializeField] private XRRayInteractor _leftHand, _rightHand;
    private void Update()
    {
        _leftHand.TryGetCurrentUIRaycastResult(out RaycastResult hitOne);
        _rightHand.TryGetCurrentUIRaycastResult(out RaycastResult hitTwo);

        InputDevice leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        InputDevice rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if ((hitOne.gameObject || hitTwo.gameObject) && (Lgrip.action.IsPressed() || Rgrip.action.IsPressed() || Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3")))
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(hitOne.gameObject, pointerEventData, ExecuteEvents.pointerClickHandler);
            ExecuteEvents.Execute(hitTwo.gameObject, pointerEventData, ExecuteEvents.pointerClickHandler);
        }

    }
}