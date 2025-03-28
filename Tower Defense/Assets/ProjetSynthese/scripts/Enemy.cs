using UnityEngine;
using UnityEngine.AI;  

public class Enemy : MonoBehaviour
{
    public float _vie;
    protected float _vitesse;
    protected int _degats;
    private float _vitesseOriginale;

    private NavMeshAgent _navMeshAgent;  

    public Transform target;  

    void Start()
    {
        
        _navMeshAgent = GetComponent<NavMeshAgent>();

        
        if (_navMeshAgent != null)
        {
            _vitesseOriginale = _navMeshAgent.speed;
        }

        if (target != null)
        {
            SeDeplacerVersTarget(target.position);  
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

    public void Ralentir(float facteurRalentissement, float duree)
    {
        if (_navMeshAgent != null)
        {
            
            _navMeshAgent.speed = _vitesseOriginale * facteurRalentissement;
            Invoke(nameof(AnnulerRalentissement), duree);
        }
        else
        {
           
            _vitesse = _vitesseOriginale * facteurRalentissement;
            Invoke(nameof(AnnulerRalentissement), duree);
        }
    }

    void AnnulerRalentissement()
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

    public void SubirDegatsSurTemps(float degatsParSeconde, float duree)
    {
        // Implémentez la logique pour appliquer des dégâts sur une période donnée
    }
}
