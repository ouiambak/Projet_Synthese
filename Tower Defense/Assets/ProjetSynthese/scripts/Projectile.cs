using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Caractéristiques du projectile")]
    public float _degats = 10f;      // Dégâts infligés
    public float _vitesse = 5f;      // Vitesse de déplacement
    public string _effetSpecial = ""; // Effet spécial (ex: ralentissement, explosion)

    private Enemy _cible; // Cible du projectile

    /// Initialise le projectile avec une _cible et ses dégâts.
  
    public void Initialiser(Enemy nouvelleCible, float nouveauxDegats)
    {
        _cible = nouvelleCible;
        _degats = nouveauxDegats;
    }

    void Update()
    {
        if (_cible == null)
        {
            DetruireProjectile();
            return;
        }

        // Déplacement vers la _cible
        transform.position = Vector3.MoveTowards(transform.position, _cible.transform.position, _vitesse * Time.deltaTime);

        // Vérifie si le projectile atteint la _cible
        if (Vector3.Distance(transform.position, _cible.transform.position) < 0.1f)
        {
            ToucheCible();
        }
    }

    /// Applique les dégâts à la _cible et détruit le projectile.
  
    void ToucheCible()
    {
        if (_cible != null)
        {
            _cible.SubirDegats(_degats);

            // Applique un effet spécial s'il y en a un
            if (!string.IsNullOrEmpty(_effetSpecial))
            {
                AppliquerEffetSpecial();
            }
        }

        DetruireProjectile();
    }

    /// Applique un effet spécial à l'ennemi touché.
 
    void AppliquerEffetSpecial()
    {
        switch (_effetSpecial.ToLower())
        {
            case "ralentissement":
                _cible.Ralentir(0.5f, 2f); // Exemple : réduit la _vitesse de moitié pendant 2 sec
                break;
            case "brûlure":
                _cible.SubirDegatsSurTemps(5f, 3f); // Exemple : 5 dégâts par seconde pendant 3 sec
                break;
            case "explosion":
                Exploser();
                break;
            default:
                break;
        }
    }

    /// Fait exploser le projectile et inflige des dégâts de zone.
  
    void Exploser()
    {
        Collider[] ennemisTouches = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider ennemi in ennemisTouches)
        {
            Enemy ennemiTouche = ennemi.GetComponent<Enemy>();
            if (ennemiTouche != null)
            {
                ennemiTouche.SubirDegats(_degats / 2); // Dégâts réduits pour les ennemis en périphérie
            }
        }
    }

    /// Détruit le projectile proprement.
  
    void DetruireProjectile()
    {
        Destroy(gameObject);
    }
}
