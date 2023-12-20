using UnityEngine;
using EzySlice;

public class Fruit : MonoBehaviour
{
    [SerializeField] private Material _insideMaterial;
    [SerializeField] private bool _isTrainingFruit;

    public bool IsTrainingFruit { get => _isTrainingFruit; set => _isTrainingFruit = value; }
    public Material InsideMaterial { get => _insideMaterial; set => _insideMaterial = value; }

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
                // enabled = false;
            }
            else
            {
                // Manager.Instance.FruitsSpawner.StartSpawn();
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

}