using UnityEngine;
using UnityEngine.AI;

public class EnemyFast : Enemy
{
    private int _nombreDeFrappe = 0;
    [SerializeField] private GameObject _bouclierVisuel;

    private void Start()
    {
        _vie = 50;
        _vitesse = 5f;
        _degats = 10;
        _recompense = 15;

        if (_bouclierVisuel != null)
            _bouclierVisuel.SetActive(false); 
        base.Start();
    }

    public override void SubirDegats(float montant)
    {
        if (_estMort) return;

        _nombreDeFrappe++;

        if (_nombreDeFrappe == 1)
        {
            if (_bouclierVisuel != null)
                _bouclierVisuel.SetActive(true); 

            _animator.SetTrigger("Run");
            if (_navMeshAgent != null) _navMeshAgent.speed = 7f;
        }
        else if (_nombreDeFrappe >= 2)
        {
            if (_bouclierVisuel != null)
                _bouclierVisuel.SetActive(false); 

            StartCoroutine(MourirAvecAnimation());
        }
    }
}
