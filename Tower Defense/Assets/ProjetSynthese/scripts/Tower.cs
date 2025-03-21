using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float portee;
    public float cadenceTir;
    public int cout;

    public virtual void DetecterEnnemis(List<Enemy> ennemis)
    {
        // D�tection d'ennemis � impl�menter selon le type de tour
    }

    public virtual void TirerProjectile(Enemy cible)
    {
        // Instancier un projectile qui cible l�ennemi
    }
}
