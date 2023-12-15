using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesPool : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particles;
    [SerializeField] private Dictionary<string, PoolBase<ParticleSystem>> _particlesDictionary = new Dictionary<string, PoolBase<ParticleSystem>>();


    private void Awake()
    {
        for (int i = 0; i < _particles.Length; i++)
            _particlesDictionary.Add($"{i}", new PoolBase<ParticleSystem>(_particles[i], 0, transform));
        // _particlesDictionary.Add(Manager.Instance.FruitsPool.FruitsDictionary[$"{i}"], new PoolBase<ParticleSystem>(_particles[i], 0, transform));
    }

    public void UsePool(Transform particlePos, int randNum)
    {
        ParticleSystem particle = _particlesDictionary[$"{randNum}"].GetObjectFromPool();
        particle.transform.position = particlePos.position;
        particle.Play();
        float particleTime = particle.main.duration + particle.main.startLifetime.constant;

        StartCoroutine(TurnOff(particle, particleTime, randNum));
    }
    private IEnumerator TurnOff(ParticleSystem particle, float duration, int randNum)
    {
        yield return new WaitForSeconds(duration);
        _particlesDictionary[$"{randNum}"].ObjectOff(particle);
    }
}