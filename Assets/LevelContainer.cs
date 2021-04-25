using UnityEngine;

public class LevelContainer : MonoBehaviour
{
    public GameObject NextLevelPrefab;
    void Start()
    {
        RestartListener.Instance.SetInstantiatedLevel(this);
    }

}
