using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFloatStartTime : MonoBehaviour
{
    public float minSpeed = .5f;
    public float maxSpeed = 1f;

    public float minWeight = .5f;
    public float maxWeight = 1f;
    
    void Start()
    {
        var animator = GetComponent<Animator>();
        animator.Play("Float", animator.GetLayerIndex("Float"), Random.Range(0, 1f) );
        animator.SetLayerWeight(animator.GetLayerIndex("Float"), Random.Range(minWeight, maxWeight));
        animator.SetFloat("FloatSpeedMultiplier", Random.Range(minSpeed, maxSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
