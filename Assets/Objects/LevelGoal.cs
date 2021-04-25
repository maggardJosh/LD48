using UnityEngine;

[SelectionBase]
public class LevelGoal : MonoBehaviour
{
    public void TransitionToNextLevel()
    {
        AudioManager.PlayOneShot(AudioClips.Instance.Goal);
        var nextLevelPrefab = RestartListener.Instance.currentLevelContainer.NextLevelPrefab;
        if (!nextLevelPrefab)
        {
            Debug.LogError("No next level set for " + transform.parent.gameObject);
            return;
        }
        RestartListener.Instance.SetLevelPrefab(nextLevelPrefab);
        Instantiate(nextLevelPrefab, transform.position + Vector3.left*.5f + Vector3.down*.5f, Quaternion.identity);
        Destroy(transform.parent.gameObject, 2);
    }
}
