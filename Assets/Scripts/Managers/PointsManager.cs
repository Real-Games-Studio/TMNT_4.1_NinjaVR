using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Unity.VisualScripting;

public class PointsManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _pointsText, _finalPointsText;
    [SerializeField] private int _pointsPerHit;
    private int _point = 0;

    public void AddPoints()
    {
        int newPoints = _point + _pointsPerHit;
        DOTween.To(() => _point, x => _point = x, newPoints, .9f).OnUpdate(() => UpdateScore()).SetEase(Ease.Linear).Play();
    }
    public void UpdateScore()
    {
        _pointsText.text = $"{_point}";
        _finalPointsText.text = $"{_point}";
    }
}
