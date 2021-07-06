using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCounter : MonoBehaviour
{
    private List<Enemy> _enemies;

    public event UnityAction AllEnemiesDied;

    private void OnEnable()
    {
        _enemies = new List<Enemy>(FindObjectsOfType<Enemy>());

        ChangeSubscriptionStatus(true);
    }

    private void OnDisable()
    {
        ChangeSubscriptionStatus(false);
    }

    private void OnSomeEnemyDied(Enemy enemy)
    {
        _enemies.Remove(enemy);

        enemy.Died -= OnSomeEnemyDied;
        if (_enemies.Count == 0)
            AllEnemiesDied?.Invoke();
    }

    private void ChangeSubscriptionStatus(bool turnOn)
    {
        foreach (var enemy in _enemies)
        {
            if (turnOn)
                enemy.Died += OnSomeEnemyDied;
            else
                enemy.Died -= OnSomeEnemyDied;
        }
    }
}
