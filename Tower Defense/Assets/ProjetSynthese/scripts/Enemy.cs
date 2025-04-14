using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float _vie;
    protected float _vitesse = 3f;
    protected int _degats = 1;

    private float _vitesseOriginale;
    private NavMeshAgent _navMeshAgent;
    public Transform target;

    public void Start()
    {
        Debug.Log("Start() lancé");

        if (target == null)
        {
            GameObject go = GameObject.FindWithTag("Target");
            if (go == null)
            {
                Debug.LogWarning("Aucun GameObject avec le tag 'Target' trouvé !");
            }
            else
            {
                Debug.Log("Target trouvé : " + go.name);
                target = go.transform;
            }
        }

        if (target != null)
        {
            SeDeplacerVersTarget(target.position);
            Debug.Log("envers le target");
        }
    }


    public virtual void SeDeplacer(Vector3 destination)
    {
        if (_navMeshAgent != null)
        {
            _navMeshAgent.SetDestination(destination);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, _vitesse * Time.deltaTime);
        }
    }

    public void SeDeplacerVersTarget(Vector3 targetPosition)
    {
        if (_navMeshAgent != null && target != null)
        {
            _navMeshAgent.SetDestination(targetPosition);
        }
    }

    public void SubirDegats(float degatsRecus)
    {
        _vie -= degatsRecus;
        if (_vie <= 0)
        {
            Mourir();
        }
    }

    public void Mourir()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Ralentit l'ennemi temporairement.
    /// </summary>
    public void AppliquerRalentissement(float facteur, float duree)
    {
        if (_navMeshAgent != null)
        {
            _navMeshAgent.speed = _vitesseOriginale * facteur;
        }
        else
        {
            _vitesse = _vitesseOriginale * facteur;
        }

        CancelInvoke(nameof(AnnulerRalentissement)); // évite les empilements
        Invoke(nameof(AnnulerRalentissement), duree);
    }

    private void AnnulerRalentissement()
    {
        if (_navMeshAgent != null)
        {
            _navMeshAgent.speed = _vitesseOriginale;
        }
        else
        {
            _vitesse = _vitesseOriginale;
        }
    }

    /// <summary>
    /// Applique des dégâts progressifs sur plusieurs secondes.
    /// </summary>
    public void SubirDegatsSurTemps(float degatsParSeconde, float duree)
    {
        StartCoroutine(DegatsProgressifs(degatsParSeconde, duree));
    }

    private System.Collections.IEnumerator DegatsProgressifs(float dps, float duree)
    {
        float tempsEcoule = 0f;

        while (tempsEcoule < duree)
        {
            SubirDegats(dps * Time.deltaTime);
            tempsEcoule += Time.deltaTime;
            yield return null;
        }
    }
}
