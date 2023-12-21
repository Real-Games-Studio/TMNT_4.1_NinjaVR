using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
// using VRBeats;

public class FruitsSpawner : MonoBehaviour
{
    public float initialVelocity = 10f;
    public float launchAngle = 45f;
    public float gravity = 9.8f;
    public float _rotationSpeed;

    [Header("Spawn points")]
    [SerializeField] private Transform[] _transformSpawns;

    [Tooltip("Intervalo de tempo entre o spawn das frutas")]
    [SerializeField]
    private float _timeBetweenSpawn;

    [Tooltip("Intervalo de tempo das vezes em que spawna todas as frutas ao mesmo tempo")]
    [SerializeField]
    [Range(0, 10)]
    private int _intervalFullSpawn;

    private bool _canSpawn = true;
    private int _countIntervalBetweenFullSpawn = 0;
    [SerializeField] private ParticleSystem[] _smokeParticles;

    public bool CanSpawn { get => _canSpawn; set => _canSpawn = value; }

    public void StartSpawn()
    {
        StartCoroutine(SpawnFruits());
    }

    private IEnumerator SpawnFruits()
    {
        yield return new WaitForSeconds(1f);

        while (CanSpawn)
        {
            if (_countIntervalBetweenFullSpawn == _intervalFullSpawn)
            {
                for (int i = 0; i < Random.Range(_transformSpawns.Length - 1, _transformSpawns.Length + 1); i++)
                {
                    BuildFruit(_transformSpawns[i]);
                    PlaySmoke(i);
                }

                _countIntervalBetweenFullSpawn = 0;
            }
            else
            {
                int randNum = Random.Range(0, _transformSpawns.Length);
                BuildFruit(_transformSpawns[randNum].transform);
                PlaySmoke(randNum);
            }

            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }

    private void BuildFruit(Transform pos)
    {
        Transform fruit = Manager.Instance.FruitsPool.UsePool(pos);
        StartCoroutine(MoveParabolically(fruit));

        _countIntervalBetweenFullSpawn++;
    }

    private IEnumerator MoveParabolically(Transform fruit)
    {
        float totalTime = 0f;
        float randomX = Random.Range(0f, 360f), randomY = Random.Range(0f, 360f), randomZ = Random.Range(0f, 360f);

        while (totalTime < 7f)
        {
            float timeStep = Time.deltaTime;
            totalTime += timeStep;

            float horizontalSpeed = initialVelocity * Mathf.Cos(launchAngle * Mathf.Deg2Rad);
            float verticalSpeed = initialVelocity * Mathf.Sin(launchAngle * Mathf.Deg2Rad) - gravity * totalTime;

            Vector3 moveDirection = new Vector3(0f, verticalSpeed, -horizontalSpeed).normalized;
            Vector3 newPosition = fruit.position + moveDirection * initialVelocity * timeStep;

            fruit.position = Vector3.MoveTowards(fruit.position, newPosition, initialVelocity * timeStep);
            fruit.Rotate(new Vector3(randomX, randomY, randomZ) * _rotationSpeed * timeStep);

            yield return null;
        }

        yield return new WaitWhile(() => totalTime < 7f);
        Manager.Instance.FruitsPool.TurnOff(fruit);
    }

    private void PlaySmoke(int arrayNum)
    {
        _smokeParticles[arrayNum].Play();
    }
}