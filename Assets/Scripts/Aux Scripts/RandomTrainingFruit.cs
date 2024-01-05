using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class RandomTrainingFruit : MonoBehaviour
{
    [SerializeField] private GameObject _trainingTextHolder;
    [SerializeField] private Transform _spawnPos;

    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(.5f);
        var fruitList = Manager.Instance.FruitsPool.Fruits;
        GameObject fruit = Instantiate(fruitList[Random.Range(0, fruitList.Length)].gameObject, new Vector3(_spawnPos.position.x, _spawnPos.position.y - .5f, _spawnPos.position.z + .1f), _spawnPos.rotation);
        _trainingTextHolder.transform.position = new Vector3(fruit.transform.position.x + .1f, fruit.transform.position.y + .8f, fruit.transform.position.z);
        fruit.GetComponent<Collider>().enabled = false;
        Vector3 originalScale = fruit.transform.localScale;
        fruit.transform.localScale = new Vector3(.1f, .1f, .1f);
        fruit.transform.DOScale(originalScale, 1.5f);
        fruit.GetComponent<Fruit>().IsTrainingFruit = true;
        yield return new WaitForSeconds(1.5f);
        fruit.GetComponent<Collider>().enabled = true;
    }

    public void DisableText()
    {
        _trainingTextHolder.SetActive(false);
    }
}
