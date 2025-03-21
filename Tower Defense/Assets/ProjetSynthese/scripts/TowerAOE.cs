using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAOE : Tower
{
    public override void DetecterEnnemis(List<Enemy> ennemis)
    {
        foreach (Enemy ennemi in ennemis)
        {
            if (Vector3.Distance(transform.position, ennemi.transform.position) <= portee)
            {
                TirerProjectile(ennemi);
            }
        }
    }
}
