using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : Enemy
{
    private void Start()
    {
        _vie = 150;
        _vitesse = 2f;
        _degats = 20;
        base.Start();
    }
}
