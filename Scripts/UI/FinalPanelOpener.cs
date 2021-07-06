using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPanelOpener : MonoBehaviour
{
    [SerializeField] private GameObject _finalPanel;
    [SerializeField] private EnemyCounter _enemyCounter;

    private void OnEnable()
    {
        _enemyCounter.AllEnemiesDied += OnAllEnemiesDied;
    }

    private void OnDisable()
    {
        _enemyCounter.AllEnemiesDied -= OnAllEnemiesDied;
    }

    private void OnAllEnemiesDied()
    {
        _finalPanel.SetActive(true);
    }
}
