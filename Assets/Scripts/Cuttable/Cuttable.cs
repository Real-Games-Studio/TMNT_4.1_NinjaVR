using UnityEngine;
using EzySlice;
using UnityEngine.InputSystem;

public class Cuttable : MonoBehaviour
{
    [SerializeField] private Transform _startSlicePoint;
    [SerializeField] private Transform _endSlicePoint;
    [SerializeField] private VelocityEstimator _velocityEstimator;
    [SerializeField] private LayerMask _sliceableLayer;
    


    private void FixedUpdate()
    {
        if (Physics.Linecast(_startSlicePoint.position, _endSlicePoint.position, out RaycastHit hit, _sliceableLayer))
        {
            Fruit fruit = hit.transform.gameObject.GetComponent<Fruit>();
            fruit.Slice(hit.transform.gameObject, _endSlicePoint, _startSlicePoint, _velocityEstimator);
        }
    }



}