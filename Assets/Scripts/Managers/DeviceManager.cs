using System;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.Scripting;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.XR;


public class DeviceManager : MonoBehaviour
{
    private void Update()
    {
        bool isHMD = XRDevice.IsHMDMounted();
        if (!isHMD && Manager.Instance.GameManager.currentState == GameStates.End)
        {
            Manager.Instance.SceneManagement.GoToScene(0);
        }
        if (!isHMD && Manager.Instance.GameManager.currentState == GameStates.Playing)
        {
            Manager.Instance.GameManager.PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Manager.Instance.SceneManagement.GoToScene(0);
        }
    }


}

public class XRDevice
{
    private static InputDevice headDevice;
    public XRDevice()
    {
        if (headDevice == null)
        {
            headDevice = InputDevices.GetDeviceAtXRNode(XRNode.Head);
        }
    }

    /// <summary>
    /// returns true if the HMD is mounted on the users head. Returns false if the current headset does not support this feature or if the HMD is not mounted.
    /// </summary>
    /// <returns></returns>
    public static bool IsHMDMounted()
    {
        if (headDevice == null || headDevice.isValid == false)
        {
            headDevice = InputDevices.GetDeviceAtXRNode(XRNode.Head);
        }
        if (headDevice != null)
        {
            bool presenceFeatureSupported = headDevice.TryGetFeatureValue(CommonUsages.userPresence, out bool userPresent);
            if (headDevice.isValid && presenceFeatureSupported)
            {
                return userPresent;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
