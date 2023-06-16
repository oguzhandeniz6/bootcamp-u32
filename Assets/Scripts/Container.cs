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
        //Vurulduðu zaman titreme ve kýzarma efekti
        gameObject.transform.DOShakePosition(0.3f, new Vector3(0.1f, 0, 0.1f), 25);
        gameObject.GetComponent<MeshRenderer>().material.DOColor(Color.red, 0.3f).From();
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
