using UnityEngine;

public class Fish : DisplaceObject
{
    public override void Displace(Vector3 dir)
    {
        GetComponent<Animator>().SetTrigger("Die");
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, 2f);
    }
}