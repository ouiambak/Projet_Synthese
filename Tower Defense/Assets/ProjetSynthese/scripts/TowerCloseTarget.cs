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
        if (_cible != null && Vector3.Distance(transform.position, _cible.transform.position) <= _range)
        {
            return;
        }

        Enemy[] ennemis = FindObjectsOfType<Enemy>();
        float distanceMin = Mathf.Infinity;
        Enemy ennemiLePlusProche = null;

        foreach (Enemy ennemi in ennemis)
        {
            float distance = Vector3.Distance(transform.position, ennemi.transform.position);
            if (distance < distanceMin && distance <= _range)
            {
                distanceMin = distance;
                ennemiLePlusProche = ennemi;
            }
        }
        _cible = ennemiLePlusProche;
    }
}
