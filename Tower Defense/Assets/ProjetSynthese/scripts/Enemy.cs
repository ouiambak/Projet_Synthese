using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class Enemy : MonoBehaviour
{
    public float _vie;
    protected float _vitesse = 3f;
    protected int _degats = 1;
    [SerializeField] protected int _recompense = 10;

    protected NavMeshAgent _navMeshAgent;
    public Transform target;

    [SerializeField] protected Animator _animator;

    private Coroutine _ralentissementCoroutine;
    protected bool _estMort = false;

    [Header("Audio")]
    [SerializeField] private AudioClip deathSound;
    private AudioSource audioSource;

    //  Événement appelé à la mort
    public System.Action onDeath;

    public virtual void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        if (target == null)
        {
            GameObject go = GameObject.FindWithTag("Target");
            if (go != null) target = go.transform;
        }

        if (_animator != null)
        {
            _animator.SetBool("__isdying", false);
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (target != null)
        {
            StartCoroutine(DeplacementApresPlacement());
        }
    }

    private IEnumerator DeplacementApresPlacement()
    {
        yield return new WaitForSeconds(0.1f);

        if (_navMeshAgent != null && target != null)
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(transform.position, out hit, 1f, NavMesh.AllAreas))
            {
                _navMeshAgent.Warp(hit.position);
                _navMeshAgent.SetDestination(target.position);
            }
        }
    }

    void Update()
    {
        if (_animator != null && _navMeshAgent != null)
        {
            float speedRatio = _navMeshAgent.velocity.magnitude / _navMeshAgent.speed;
            _animator.SetFloat("_speed", speedRatio);
        }
    }

    public virtual void SeDeplacer(Vector3 destination)
    {
        if (_navMeshAgent != null && _navMeshAgent.isOnNavMesh)
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
        if (_navMeshAgent != null && _navMeshAgent.isOnNavMesh && target != null)
        {
            _navMeshAgent.SetDestination(targetPosition);
        }
    }

    public virtual void SubirDegats(float montant)
    {
        if (_estMort) return;

        _vie -= montant;

        if (_vie <= 0)
        {
            StartCoroutine(MourirAvecAnimation());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            GameManager.Instance.PerdreVie();
            Destroy(gameObject);
        }
    }

    protected virtual IEnumerator MourirAvecAnimation()
    {
        if (_estMort) yield break;
        _estMort = true;

        if (_animator != null)
        {
            _animator.SetBool("_isdying", true);
        }

        if (_navMeshAgent != null)
        {
            _navMeshAgent.enabled = false;
        }

        GameManager.Instance.GagnerRessources(_recompense);

        // Appel de l'événement de mort
        onDeath?.Invoke();

        if (deathSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }

    public void AppliquerRalentissement(float facteur, float duree)
    {
        if (_ralentissementCoroutine != null)
        {
            StopCoroutine(_ralentissementCoroutine);
        }
        _ralentissementCoroutine = StartCoroutine(RalentirTemporairement(facteur, duree));
    }

    private IEnumerator RalentirTemporairement(float facteur, float duree)
    {
        if (_navMeshAgent == null) yield break;

        float vitesseOriginale = _navMeshAgent.speed;
        _navMeshAgent.speed *= facteur;

        yield return new WaitForSeconds(duree);

        if (_navMeshAgent != null)
        {
            _navMeshAgent.speed = vitesseOriginale;
        }
    }
}
