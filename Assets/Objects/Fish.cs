using UnityEngine;

public class Fish : DisplaceObject
{
    public override void Displace(Vector3 dir)
    {
        Destroy(gameObject);
    }
}