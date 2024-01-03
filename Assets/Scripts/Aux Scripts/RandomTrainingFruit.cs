using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class RandomTrainingFruit : MonoBehaviour
{
    [SerializeField] private GameObject _trainingTextHolder;

    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        var fruitList = Manager.Instance.FruitsPool.Fruits;
        GameObject fruit = Instantiate(fruitList[Random.Range(0, fruitList.Length)].gameObject, transform.position, transform.rotation);
        fruit.GetComponent<Collider>().enabled = false;
        Vector3 originalScale = fruit.transform.localScale;
        fruit.transform.localScale = new Vector3(.1f, .1f, .1f);
        fruit.transform.DOScale(originalScale, 2f);
        fruit.GetComponent<Fruit>().IsTrainingFruit = true;
        yield return new WaitForSeconds(2f);
        fruit.GetComponent<Collider>().enabled = true;
    }

    public void DisableText()
    {
        _trainingTextHolder.SetActive(false);
    }
}
