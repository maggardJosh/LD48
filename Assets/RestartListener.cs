using System.Collections;
using ImportedTools;
using UnityEngine;
using UnityEngine.UI;

public class RestartListener : Singleton<RestartListener>
{
    [SerializeField] private GameObject levelPrefab;
    private GameObject _instantiatedLevel;
    [SerializeField] private Image _fadeToBlackImage;
    [SerializeField] private float fadeTime = .5f;
    [SerializeField] private AnimationCurve fadeCurve;
    private float _fadeCount;
    
    
    public void SetInstantiatedLevel(LevelContainer levelContainer)
    {
        _instantiatedLevel = levelContainer.gameObject;
    }
    
    public void SetLevelPrefab(GameObject levelPrefab)
    {
        this.levelPrefab = levelPrefab;
    }

    private bool _isRestarting = false;
    public void RestartCurrentLevel()
    {
        if (_isRestarting)
            return;

        _isRestarting = true;

        StartCoroutine(Restart());
    }

    private IEnumerator Restart()
    {
        _fadeCount = 0;
        while (_fadeCount < fadeTime)
        {
            _fadeCount += Time.deltaTime;
            var t = _fadeCount / fadeTime;
            t = fadeCurve.Evaluate(t);

            var c = _fadeToBlackImage.color;
            c.a = t;
            _fadeToBlackImage.color = c;
            yield return null;
        }
        Destroy(_instantiatedLevel.gameObject);
        Instantiate(levelPrefab);
        while (_fadeCount > 0)
        {
            _fadeCount -= Time.deltaTime;
            var t = _fadeCount / fadeTime;
            t = fadeCurve.Evaluate(t);
            
            var c = _fadeToBlackImage.color;
            c.a = t;
            _fadeToBlackImage.color = c;
            yield return null;
        }

        _isRestarting = false;
    }

    
}
