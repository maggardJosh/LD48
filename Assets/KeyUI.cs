using System.Collections;
using System.Collections.Generic;
using ImportedTools;
using UnityEngine;

public class KeyUI : Singleton<KeyUI>
{
    public GameObject KeyUIPrefab;

    public void UpdateKeyCount(int count)
    {
        foreach(Transform child in transform)
            Destroy(child.gameObject);

        for (int i = 0; i < count; i++)
            Instantiate(KeyUIPrefab, transform);
    }
}
