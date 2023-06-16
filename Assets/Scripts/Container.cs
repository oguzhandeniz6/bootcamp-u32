using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Container : MonoBehaviour, IDamagable
{
    public int Health { get; set; }
    public int health;

    private void Start()
    {
        Health = health;
    }

    public void Damage()
    {
        Health -= 1;
        Debug.Log(Health);
        gameObject.transform.DOShakePosition(0.3f, 0.1f, 25);
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
