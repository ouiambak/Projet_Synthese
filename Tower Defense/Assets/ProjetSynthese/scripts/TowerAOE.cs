using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAOE : Tower
{

    public void Start()
    {
        _cadenceDeTir = 2f;

        if (_projectilePrefab == null)
        {
            Debug.LogError("TowerAOE : _projectilePrefab n'est pas assigné !");
        }
    }

    protected override void Tirer()
    {
        if (_projectilePrefab == null)
        {
            Debug.LogError("TowerAOE : _projectilePrefab est null dans Tirer()");
            return;
        }

        Enemy[] ennemis = FindObjectsOfType<Enemy>();

        foreach (Enemy ennemi in ennemis)
        {
            if (Vector3.Distance(transform.position, ennemi.transform.position) <= _range)
            {
                GameObject projectileGO = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);

                Projectile projectile = projectileGO.GetComponent<Projectile>();
                if (projectile == null)
                {
                    Debug.LogError("TowerAOE : Le prefab n’a pas de script 'Projectile' attaché !");
                    return;
                }

                float nouveauxDegats = 10f;
                projectile.Initialiser(ennemi, nouveauxDegats);
            }
        }
    }
}
