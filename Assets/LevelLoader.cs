using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public GameObject levelPrefab;
    public void LoadLevel()
    {
        //Wow what a hack :)
        RestartListener.Instance.SetLevelPrefab(levelPrefab);
        RestartListener.Instance.RestartCurrentLevel();
    }

}
