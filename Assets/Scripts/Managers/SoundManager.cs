using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource fruitSplash;

    public void PlayFruitSplash()
    {
        fruitSplash.Play();
    }
}