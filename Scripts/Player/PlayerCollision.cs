using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public event UnityAction BoosterTaken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Booster booster))
        {
            BoosterTaken?.Invoke();
            Destroy(booster.gameObject);
        }
    }
}
