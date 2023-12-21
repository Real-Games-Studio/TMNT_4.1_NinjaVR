using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
// using VRBeats;

public class RandomTrainingFruit : MonoBehaviour
{
    [SerializeField] private GameObject _trainingTextHolder;

    private void Start()
    {
        var fruitList = Manager.Instance.FruitsPool.Fruits;
        GameObject fruit = Instantiate(fruitList[Random.Range(0, fruitList.Length)].gameObject, transform.position, transform.rotation);
        fruit.GetComponent<Fruit>().IsTrainingFruit = true;        
    }

    public void DisableText()
    {
        _trainingTextHolder.SetActive(false);
    }
}
