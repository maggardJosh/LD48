using ImportedTools.Extensions;
using UnityEngine;

[SelectionBase]
public class Rock : DisplaceObject
{
    [SerializeField] LayerMask collisionLayer;

    private float _animCount = 0;
    [SerializeField] private float animTime = .2f;
    [SerializeField] private AnimationCurve animCurve;
    
    private Vector3 _prevPos = Vector3.zero;
    private Vector3 _newPos = Vector3.zero;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (_animCount <= 0)
            return;
        
        _animCount -= Time.deltaTime;
        var t = 1 -(_animCount / animTime);
        transform.position = Vector3.Lerp(_prevPos, _newPos, animCurve.Evaluate(t));

    }

    public override bool CanHit()
    {
        return _animCount <= 0;
    }

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
        {
            AudioManager.PlayOneShot(AudioClips.Instance.RockMove);
            _prevPos = transform.position.GetCopy();
            _newPos = transform.position + dir;
            _animCount = animTime;
        }
    }
}