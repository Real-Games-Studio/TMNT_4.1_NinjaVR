using UnityEngine;
using EzySlice;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

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
            if (gameObject.CompareTag("Cuttable"))
            {
                Fruit fruit = hit.transform.gameObject.GetComponent<Fruit>();
                fruit.Slice(hit.transform.gameObject, _endSlicePoint, _startSlicePoint, _velocityEstimator);
                return;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Burst"))
        {
            if (!other.transform.GetComponent<Fruit>().IsTrainingFruit)
            {
                Manager.Instance.FruitsPool.TurnOff(other.transform);
                Manager.Instance.PointsManager.AddPoints();
            }
            else
            {
                Manager.Instance.FruitsSpawner.StartSpawn();
                Manager.Instance.RandomTrainingFruit.DisableText();
                Manager.Instance.TimeController.StartTimer();
                Destroy(other.gameObject);
            }
        }
    }

}