using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFast : Enemy
{
    private void Start()
    {
        _vie = 50;
        _vitesse = 5f;
        _degats = 10;
    }
}
