public class EnemyTank : Enemy
{
    private void Start()
    {
        _vie = 150;
        _vitesse = 2f;
        _degats = 20;
        _recompense = 20;
        base.Start();
    }

    public override void SubirDegats(float montant)
    {
        if (_estMort) return;
        StartCoroutine(MourirAvecAnimation());
    }
}