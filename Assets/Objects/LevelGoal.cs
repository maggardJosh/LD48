using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

[SelectionBase]
public class LevelGoal : MonoBehaviour
{
    [SerializeField] private GameObject NextLevelPrefab;

    public void TransitionToNextLevel()
    {
        if (!NextLevelPrefab)
        {
            Debug.LogError("No next level set for " + transform.parent.gameObject);
            return;
        }
        RestartListener.Instance.SetLevelPrefab(NextLevelPrefab);
        Instantiate(NextLevelPrefab, transform.position + Vector3.left*.5f + Vector3.down*.5f, Quaternion.identity);
        Destroy(transform.parent.gameObject, 2);
    }
}
