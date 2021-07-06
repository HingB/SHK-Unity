using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _movementSquareMultyplayer;

    private Vector3 _target;

    public event UnityAction<Enemy> Died;

    void Start()
    {
        DetermineNewTarget();
    }

    void Update()
    {
        Move();
        if (transform.position == _target)
            DetermineNewTarget();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    private void DetermineNewTarget()
    {
        _target = Random.insideUnitCircle * _movementSquareMultyplayer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
        Died?.Invoke(this);
    }
}
