using ImportedTools;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : Singleton<FadeToBlack>
{
    
    [SerializeField] private Image _fadeToBlackImage;

    public void SetAlpha(float a)
    {   
        var c = _fadeToBlackImage.color;
        c.a = a;
        _fadeToBlackImage.color = c;
    }
}
