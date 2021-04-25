using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Rock : DisplaceObject
{
    [SerializeField] LayerMask collisionLayer;
    
    public override void Displace(Vector3 dir)
    {
        var collider = GetComponent<Collider2D>();
        collider.enabled = false;
        RaycastHit2D[] results = new RaycastHit2D[1];
        var result = Physics2D.Raycast(transform.position, dir, new ContactFilter2D
        {
            layerMask = this.collisionLayer,
            useLayerMask = true
        }, results, 1);
        collider.enabled = true;
        if (result == 0)
            transform.position += dir;
    }
}