using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHandPos : MonoBehaviour
{
    public Transform HandToFollow;

    // Update is called once per frame
    void Update()
    {
        transform.position = HandToFollow.position;
    }
}
