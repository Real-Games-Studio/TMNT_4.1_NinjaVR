using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerOld : MonoBehaviour
{
    [SerializeField] float timeout;

    void Start()
    {
        timeout = JSONFile.Configclass.finalTimeout;
    }
}
