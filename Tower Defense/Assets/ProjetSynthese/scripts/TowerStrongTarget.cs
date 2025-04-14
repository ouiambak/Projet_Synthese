using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerStrongTarget : Tower
{
    protected override void TrouverCible()
    {
        Enemy[] ennemis = FindObjectsOfType<Enemy>();
        Enemy ennemiLePlusFort = null;
        float vieMax = 0f;

        foreach (Enemy ennemi in ennemis)
        {
            float distance = Vector3.Distance(transform.position, ennemi.transform.position);
            if (distance <= _portee && ennemi._vie > vieMax)
            {
                vieMax = ennemi._vie;
                ennemiLePlusFort = ennemi;
            }
        }
        cible = ennemiLePlusFort;
    }
}
