using UnityEngine;

public class Enemy : MonoBehaviour
{
     public float _vie;
     protected float _vitesse;
     protected int _degats;

    public virtual void SeDeplacer(Vector3 destination)
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, _vitesse * Time.deltaTime);
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
}