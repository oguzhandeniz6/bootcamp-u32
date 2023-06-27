using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable 
{
    public enum DamagableType {ENEMY, IRON, WOOD }
    DamagableType Type { get; set; }

    int Health { get; set; }
    void Damage();





}
