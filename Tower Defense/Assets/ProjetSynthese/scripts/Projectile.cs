using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Enemy _cible;
    private float _degats;
    public bool isAOE = false;
    public float radius = 2f;
    public bool slowEffect = false;

   /* public void Initialiser(Enemy cible, float degats)
    {
        _cible = cible;
        _degats = degats;
    }

    void Update()
    {
        if (_cible == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _cible.transform.position, 10f * Time.deltaTime);

        if (Vector3.Distance(transform.position, _cible.transform.position) < 0.1f)
        {
            if (isAOE)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
                foreach (var hit in colliders)
                {
                    Enemy e = hit.GetComponent<Enemy>();
                    if (e != null)
                    {
                        e.SubirDegats(_degats);
                        if (slowEffect)
                        {
                            e.AppliquerRalentissement(0.5f, 2f); 
                        }
                    }
                }
            }
            else
            {
                _cible.SubirDegats(_degats);
            }

            Destroy(gameObject);
        }
    }*/
}
