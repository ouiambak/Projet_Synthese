using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float degats;
    public float vitesse;
    public string effetSpecial;
    private Enemy cible;

    public void Initialiser(Enemy cible, float degats)
    {
        this.cible = cible;
        this.degats = degats;
    }

    void Update()
    {
        if (cible != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, cible.transform.position, vitesse * Time.deltaTime);
            if (Vector3.Distance(transform.position, cible.transform.position) < 0.1f)
            {
                ToucheCible();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void ToucheCible()
    {
        cible.SubirDegats(degats);
        Destroy(gameObject);
    }
}
