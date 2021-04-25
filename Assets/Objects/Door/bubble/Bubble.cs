using System;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}