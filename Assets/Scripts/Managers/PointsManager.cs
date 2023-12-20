using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private int _pointsPerHit;
    private int _points = 0;

    public void AddPoints()
    {
        _points += _pointsPerHit;
    }
    public void ResetPoints()
    {
        _points = 0;
    }
}
