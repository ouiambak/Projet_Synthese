using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    protected float _cadenceDeTir = 1f;
    protected Enemy _cible;
    [SerializeField] protected GameObject _projectilePrefab;
    [SerializeField] protected float _range = 5f;

    private float _compteurDeTir = 0f;

    [Header("Audio")]
    [SerializeField] private AudioClip shootSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        TrouverCible();

        if (_cible != null)
        {
            if (_compteurDeTir <= 0f)
            {
                Tirer();
                _compteurDeTir = 1f / _cadenceDeTir;
            }
        }

        _compteurDeTir -= Time.deltaTime;
    }

    protected virtual void TrouverCible()
    {
        Enemy[] ennemis = FindObjectsOfType<Enemy>();
        float plusProche = Mathf.Infinity;
        Enemy meilleurCandidat = null;

        foreach (Enemy ennemi in ennemis)
        {
            float distance = Vector3.Distance(transform.position, ennemi.transform.position);
            if (distance < plusProche && distance <= _range)
            {
                plusProche = distance;
                meilleurCandidat = ennemi;
            }
        }

        _cible = meilleurCandidat;
    }

    protected virtual void Tirer()
    {
        if (_cible == null) return;

        GameObject projectileObj = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectile = projectileObj.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.Initialiser(_cible, 10f);
        }

        // Joue le son de tir
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
