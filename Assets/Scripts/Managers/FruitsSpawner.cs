using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
// using VRBeats;

public class FruitsSpawner : MonoBehaviour
{
    [Header("Spawn points")]
    [SerializeField] private Transform[] _transformSpawns;

    [Header("Spawn Control")]
    [Tooltip("Força em que a fruta é lançada")]
    [SerializeField]
    private float _force;

    [Tooltip("Vetor da direção que a fruta vai ser projetada")]
    [SerializeField]
    private Vector3 _directionVector;

    [Tooltip("Intervalo de tempo entre o spawn das frutas")]
    [SerializeField]
    private float _timeBetweenSpawn;

    [Tooltip("Intervalo de tempo das vezes em que spawna todas as frutas ao mesmo tempo")]
    [SerializeField]
    [Range(0, 10)]
    private int _intervalFullSpawn;

    private bool _canSpawn = true;
    private int _countIntervalBetweenFullSpawn = 0;

    public bool CanSpawn { get => _canSpawn; set => _canSpawn = value; }
    public float Force { get => _force; set => _force = value; }

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
                    BuildFruit(_transformSpawns[i]);

                _countIntervalBetweenFullSpawn = 0;
            }
            else
            {
                BuildFruit(_transformSpawns[Random.Range(0, _transformSpawns.Length)].transform);
            }

            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }

    private void BuildFruit(Transform pos)
    {
        Transform fruit = Manager.Instance.FruitsPool.UsePool(pos);
        Rigidbody fruitRb = fruit.GetComponent<Rigidbody>();
        // fruit.GetComponent<Cuttable>().enabled = true;
        fruitRb.AddForce(_directionVector * Force);
        fruitRb.AddTorque(new Vector3(Random.rotationUniform.x, 0, Random.rotationUniform.z) * 10);
        _countIntervalBetweenFullSpawn++;
    }

    public void SpawnTrainingFruit(Transform spawnPos)
    {

    }
}