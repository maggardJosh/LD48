using System.Collections;
using System.Collections.Generic;
using ImportedTools;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : Singleton<LevelText>
{
    private Text _text;

    void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void SetLevelName(string name)
    {
        _text.text = name;
    }
}
