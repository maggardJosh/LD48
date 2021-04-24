using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    public GameObject NextLevelPrefab;

    public void TransitionToNextLevel()
    {
        if (!NextLevelPrefab)
        {
            Debug.LogError("No next level set for " + transform.parent.gameObject);
            return;
        }
        Instantiate(NextLevelPrefab, transform.position + Vector3.left*.5f + Vector3.down*.5f, Quaternion.identity);
        Destroy(transform.parent.gameObject, 3);
    }
}
