using UnityEngine;

public class Fish : DisplaceObject
{
    public override void Displace(Vector3 dir)
    {
        GetComponent<Animator>().SetBool("Dying", true);
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject, 2f);
    }

    public override bool CanHit()
    {
        return true;
    }
}