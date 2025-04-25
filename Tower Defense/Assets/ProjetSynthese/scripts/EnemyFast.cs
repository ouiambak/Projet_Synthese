using UnityEngine.AI;
using UnityEngine;

public class EnemyFast : Enemy
{
    private int _nombreDeFrappe = 0;

    private void Start()
    {
        _vie = 50;
        _vitesse = 5f;
        _degats = 10;
        _recompense = 15;
        base.Start();
    }

    public override void SubirDegats(float montant)
    {
        if (_estMort) return;

        _nombreDeFrappe++;
        if (_nombreDeFrappe >= 2)
        {
            StartCoroutine(MourirAvecAnimation());
        }
        else
        {
            _animator.SetTrigger("Run");
            if (_navMeshAgent != null) _navMeshAgent.speed = 7f;
        }
    }
}