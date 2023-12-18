using UnityEngine;
using EzySlice;

public class Fruit : MonoBehaviour
{
    [SerializeField] private Material _insideMaterial;
    [SerializeField] private bool _isTrainingFruit;
    private bool test;
    private Rigidbody _fruitRb = null;
    public bool IsTrainingFruit { get => _isTrainingFruit; set => _isTrainingFruit = value; }
    public Material InsideMaterial { get => _insideMaterial; set => _insideMaterial = value; }

    private void Awake()
    {
        _fruitRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (ShouldKillFruit())
        {
            _fruitRb.velocity = Vector3.zero;
            Manager.Instance.FruitsPool.TurnOff(transform);
        }
    }

    public void Slice(GameObject target, Transform _endSlicePoint, Transform _startSlicePoint, VelocityEstimator _velocityEstimator)
    {
        Vector3 planeNormal = Vector3.Cross(_endSlicePoint.position - _startSlicePoint.position, _velocityEstimator.GetVelocityEstimate()).normalized;
        SlicedHull hull = target.Slice(_endSlicePoint.position, planeNormal);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, InsideMaterial);
            GameObject lowerHull = hull.CreateLowerHull(target, InsideMaterial);
            SetupSliceComponent(upperHull, _startSlicePoint.position, true);
            SetupSliceComponent(lowerHull, _startSlicePoint.position, false);

            if (!_isTrainingFruit)
            {
                Manager.Instance.FruitsPool.TurnOff(transform);
                _fruitRb.velocity = Vector3.zero;
                // enabled = false;
            }
            else
            {
                Manager.Instance.FruitsSpawner.StartSpawn();
                Manager.Instance.RandomTrainingFruit.DisableText();
                Manager.Instance.TimeController.StartTimer();
                Destroy(gameObject);
            }
        }
    }

    public void SetupSliceComponent(GameObject slicedObject, Vector3 up, bool isUpper)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        // rb.AddExplosionForce(_cutForce, slicedObject.transform.position, 1);
        if (isUpper)
        {
            rb.AddForce(75f * up);
            rb.AddForce(180f * transform.forward * -1);
        }
        else
        {
            rb.AddForce(75f * up * -1f);
            rb.AddForce(180f * transform.forward * -1);
        }
    }

    public bool ShouldKillFruit()
    {
        return transform.position.z < Manager.Instance.GameManager.Player.position.z - 2.0f;
    }
}