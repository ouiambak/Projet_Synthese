using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAOE : Tower
{
    public void Start()
    {
        _cadenceDeTir = 2f;
    }
    protected override void Tirer()
    {

        Enemy[] ennemis = FindObjectsOfType<Enemy>();

        foreach (Enemy ennemi in ennemis)
        {

            if (Vector3.Distance(transform.position, ennemi.transform.position) <= _portee)
            {

                GameObject projectileGO = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
                Projectile projectile = projectileGO.GetComponent<Projectile>();
                float nouveauxDegats = 10f;
                //projectile.Initialiser(ennemi, nouveauxDegats);
            }
        }
    }
}
