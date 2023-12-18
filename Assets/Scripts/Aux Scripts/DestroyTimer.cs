using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 2f);
    }
}