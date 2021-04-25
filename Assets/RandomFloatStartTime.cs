using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFloatStartTime : MonoBehaviour
{
    void Start()
    {
        var animator = GetComponent<Animator>();
        animator.Play("Float", animator.GetLayerIndex("Float"), Random.Range(0, 1f) );
        animator.SetLayerWeight(animator.GetLayerIndex("Float"), Random.Range(.5f, 1f));
        animator.SetFloat("FloatSpeedMultiplier", Random.Range(.5f,1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
