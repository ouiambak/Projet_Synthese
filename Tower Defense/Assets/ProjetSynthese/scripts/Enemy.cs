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

    [SerializeField] private Animator _animator;

    public void Start()
    {
        Debug.Log("Start() lancé");

        _navMeshAgent = GetComponent<NavMeshAgent>();

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

    void Update()
    {
        if (_animator != null && _navMeshAgent != null)
        {
            // Met à jour la vitesse dans l'Animator pour gérer l'animation
            _animator.SetFloat("_speed", _navMeshAgent.velocity.magnitude / _navMeshAgent.speed);
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
}
