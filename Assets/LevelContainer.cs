using System;
using UnityEngine;

public class LevelContainer : MonoBehaviour
{
    public GameObject NextLevelPrefab;
    public string LevelName;
    void Start()
    {
        RestartListener.Instance.SetInstantiatedLevel(this);
        if (String.IsNullOrWhiteSpace(LevelName))
            LevelName = gameObject.name;
        LevelText.Instance.SetLevelName(LevelName);
    }

}
