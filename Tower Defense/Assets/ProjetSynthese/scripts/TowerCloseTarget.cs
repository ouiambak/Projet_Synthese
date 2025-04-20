using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCloseTarget : Tower
{
    public void Start()
    {
        _cadenceDeTir = 3f;
    }
    protected override void TrouverCible()
    {
        if (cible != null && Vector3.Distance(transform.position, cible.transform.position) <= _portee)
        {
            return;
        }

        Enemy[] ennemis = FindObjectsOfType<Enemy>();
        float distanceMin = Mathf.Infinity;
        Enemy ennemiLePlusProche = null;

        foreach (Enemy ennemi in ennemis)
        {
            float distance = Vector3.Distance(transform.position, ennemi.transform.position);
            if (distance < distanceMin && distance <= _portee)
            {
                distanceMin = distance;
                ennemiLePlusProche = ennemi;
            }
        }
        cible = ennemiLePlusProche;
    }
}
