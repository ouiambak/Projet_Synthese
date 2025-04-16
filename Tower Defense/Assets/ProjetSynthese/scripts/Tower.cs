using UnityEngine;

public class Tower : MonoBehaviour
{
    public float _portee = 5f; 
    public float _cadenceDeTir = 1f; 
    public GameObject _projectilePrefab; 
    public float _degats = 10f; 
    private float _tempsAvantProchainTir = 0f;

    protected Enemy cible;

    void Update()
    {
        TrouverCible();
        if (cible != null && _tempsAvantProchainTir <= 0f)
        {
            Tirer();
            _tempsAvantProchainTir = 1f / _cadenceDeTir;
        }
        _tempsAvantProchainTir -= Time.deltaTime;

     
        if (cible != null)
        {
            Vector3 direction = cible.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 5f);
        }
    }

    protected virtual void TrouverCible()
    {
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

    protected virtual void Tirer()
    {
        if (cible == null) return;

        GameObject projectileGO = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        //projectile.Initialiser(cible, _degats); 
    }
}
