using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsPool : MonoBehaviour
{
    [SerializeField] private Transform[] _fruits;
    [SerializeField] private Dictionary<string, PoolBase<Transform>> _fruitsDictionary = new Dictionary<string, PoolBase<Transform>>();
    private int _randNum;
    public Dictionary<string, PoolBase<Transform>> FruitsDictionary { get => _fruitsDictionary; set => _fruitsDictionary = value; }
    public Transform[] Fruits { get => _fruits; set => _fruits = value; }

    private void Awake()
    {
        for (int i = 0; i < Fruits.Length; i++)
            _fruitsDictionary.Add($"{i}", new PoolBase<Transform>(Fruits[i], 0, transform));
    }
    public Transform UsePool(Transform posTransform)
    {
        _randNum = Random.Range(0, Fruits.Length);
        Transform spawnedFruit = FruitsDictionary[$"{_randNum}"].GetObjectFromPool();
        spawnedFruit.transform.position = posTransform.position;

        return spawnedFruit;
    }
    public void TurnOff(Transform transform)
    {
        FruitsDictionary[$"{_randNum}"].ObjectOff(transform);
        Manager.Instance.ParticlesPool.UsePool(transform, _randNum);
    }
}
