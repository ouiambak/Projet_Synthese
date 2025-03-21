using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCloseTarget : Tower
{
    public override void DetecterEnnemis(List<Enemy> ennemis)
    {
        Enemy cible = null;
        float distanceMin = Mathf.Infinity;

        foreach (Enemy ennemi in ennemis)
        {
            float distance = Vector3.Distance(transform.position, ennemi.transform.position);
            if (distance < distanceMin)
            {
                distanceMin = distance;
                cible = ennemi;
            }
        }
        if (cible != null)
        {
            TirerProjectile(cible);
        }
    }
}
