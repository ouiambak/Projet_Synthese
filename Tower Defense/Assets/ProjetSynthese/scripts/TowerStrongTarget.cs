using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerStrongTarget : Tower
{
    public void Start()
    {
        _cadenceDeTir = 5f;
    }
    private void Update()
    {
        if (_cible != null)
        {
            Vector3 direction = _cible.transform.position - transform.position;
            direction.y = 0f; 

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
    protected override void TrouverCible()
    {
        Enemy[] ennemis = FindObjectsOfType<Enemy>();
        Enemy ennemiLePlusFort = null;
        float vieMax = 0f;

        foreach (Enemy ennemi in ennemis)
        {
            float distance = Vector3.Distance(transform.position, ennemi.transform.position);
            if (distance <= _range && ennemi._vie > vieMax)
            {
                vieMax = ennemi._vie;
                ennemiLePlusFort = ennemi;
            }
        }
        _cible = ennemiLePlusFort;
    }
}
