using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWayContainer<T> : MonoBehaviour where T : Object
{
    [SerializeField] private T up;
    [SerializeField] private T left;
    [SerializeField] private T down;
    [SerializeField] private T right;

    public T GetObject(Vector2 direction)
    {
        if (direction.x > 0)
            return right;

        if (direction.x < 0)
            return left;

        if (direction.y < 0)
            return down;
        else
            return up;
    }
}