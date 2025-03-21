using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float vie;
    public float vitesse;
    public int degats;

    public virtual void SeDeplacer(Vector3 destination)
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, vitesse * Time.deltaTime);
    }

    public void SubirDegats(float degatsRecus)
    {
        vie -= degatsRecus;
        if (vie <= 0)
        {
            Mourir();
        }
    }

    public void Mourir()
    {
        Destroy(gameObject);
    }
}