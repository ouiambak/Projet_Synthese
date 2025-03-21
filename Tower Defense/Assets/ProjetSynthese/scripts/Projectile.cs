using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Caract�ristiques du projectile")]
    public float _degats = 10f;      // D�g�ts inflig�s
    public float _vitesse = 5f;      // Vitesse de d�placement
    public string _effetSpecial = ""; // Effet sp�cial (ex: ralentissement, explosion)

    private Enemy _cible; // Cible du projectile

    /// Initialise le projectile avec une _cible et ses d�g�ts.
  
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

        // D�placement vers la _cible
        transform.position = Vector3.MoveTowards(transform.position, _cible.transform.position, _vitesse * Time.deltaTime);

        // V�rifie si le projectile atteint la _cible
        if (Vector3.Distance(transform.position, _cible.transform.position) < 0.1f)
        {
            ToucheCible();
        }
    }

    /// Applique les d�g�ts � la _cible et d�truit le projectile.
  
    void ToucheCible()
    {
        if (_cible != null)
        {
            _cible.SubirDegats(_degats);

            // Applique un effet sp�cial s'il y en a un
            if (!string.IsNullOrEmpty(_effetSpecial))
            {
                AppliquerEffetSpecial();
            }
        }

        DetruireProjectile();
    }

    /// Applique un effet sp�cial � l'ennemi touch�.
 
    void AppliquerEffetSpecial()
    {
        switch (_effetSpecial.ToLower())
        {
            case "ralentissement":
                _cible.Ralentir(0.5f, 2f); // Exemple : r�duit la _vitesse de moiti� pendant 2 sec
                break;
            case "br�lure":
                _cible.SubirDegatsSurTemps(5f, 3f); // Exemple : 5 d�g�ts par seconde pendant 3 sec
                break;
            case "explosion":
                Exploser();
                break;
            default:
                break;
        }
    }

    /// Fait exploser le projectile et inflige des d�g�ts de zone.
  
    void Exploser()
    {
        Collider[] ennemisTouches = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider ennemi in ennemisTouches)
        {
            Enemy ennemiTouche = ennemi.GetComponent<Enemy>();
            if (ennemiTouche != null)
            {
                ennemiTouche.SubirDegats(_degats / 2); // D�g�ts r�duits pour les ennemis en p�riph�rie
            }
        }
    }

    /// D�truit le projectile proprement.
  
    void DetruireProjectile()
    {
        Destroy(gameObject);
    }
}
