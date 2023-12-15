using EzySlice;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExplodeCuttable : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private Transform _plane;
    [SerializeField] private Material _insideMaterial;

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Slice(_target);
        }
    }

    public void Slice(GameObject target)
    {
        // Vector3 planeNormal = Vector3.Cross(_endSlicePoint.position - _startSlicePoint.position, _velocityEstimator.GetVelocityEstimate()).normalized;
        SlicedHull hull = gameObject.Slice(_plane.position, _plane.up);


        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(_target, _insideMaterial);
            GameObject lowerHull = hull.CreateLowerHull(_target, _insideMaterial);

            Destroy(target);
            
            SetupSliceComponent(upperHull);
            SetupSliceComponent(lowerHull);
        }
    }

    public void SetupSliceComponent(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;

        rb.AddExplosionForce(1000, transform.position, 1);
    }

}