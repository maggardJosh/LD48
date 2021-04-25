using System;
using System.Collections;
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
        RestartListener.Instance.isTransitioning = true;
        StartCoroutine(SetTransitioningAfterDelay(2));
    }

    private IEnumerator SetTransitioningAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        RestartListener.Instance.isTransitioning = false;
    }

}
