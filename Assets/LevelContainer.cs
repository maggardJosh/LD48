using UnityEngine;

public class LevelContainer : MonoBehaviour
{
    void Start()
    {
        RestartListener.Instance.SetInstantiatedLevel(this);
    }

}
