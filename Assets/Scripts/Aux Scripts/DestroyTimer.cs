using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1f);
    }
}