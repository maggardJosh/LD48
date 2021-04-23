using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DestroyAfterAnimation : MonoBehaviour
{
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        var currentAnimatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if( currentAnimatorStateInfo.normalizedTime >= 1)
            Destroy(gameObject);
    }
}
