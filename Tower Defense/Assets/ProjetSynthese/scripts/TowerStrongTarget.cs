using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStrongestTarget : Tower
{
    public override void DetecterEnnemis(List<Enemy> ennemis)
    {
        Enemy cible = null;
        float maxVie = 0;

        foreach (Enemy ennemi in ennemis)
        {
            if (ennemi.vie > maxVie)
            {
                maxVie = ennemi.vie;
                cible = ennemi;
            }
        }
        if (cible != null)
        {
            TirerProjectile(cible);
        }
    }
}
