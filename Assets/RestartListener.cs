using System;
using System.Collections;
using ImportedTools;
using UnityEngine;

public class RestartListener : Singleton<RestartListener>
{
    [SerializeField] private GameObject levelPrefab;
    private GameObject _instantiatedLevel;
    [SerializeField] private float fadeTime = .5f;
    [SerializeField] private AnimationCurve fadeCurve;
    private float _fadeCount;
    public LevelContainer currentLevelContainer;
    public bool isTransitioning = false;

    private void Start()
    {
        isTransitioning = true;
        FadeToBlack.Instance.SetAlpha(1);
        StartCoroutine(Restart(fadeTime));
    }

    public void SetInstantiatedLevel(LevelContainer levelContainer)
    {
        currentLevelContainer = levelContainer;
        _instantiatedLevel = levelContainer.gameObject;
    }

    public void SetLevelPrefab(GameObject levelPrefab)
    {
        this.levelPrefab = levelPrefab;
    }

    public void RestartCurrentLevel()
    {
        if (isTransitioning)
            return;

        isTransitioning = true;

        StartCoroutine(Restart(0));
    }

    private IEnumerator Restart(float startingFade)
    {
        _fadeCount = startingFade;
        if(_fadeCount==0)
            AudioManager.PlayOneShot(AudioClips.Instance.Restart);
        while (_fadeCount < fadeTime)
        {
            _fadeCount += Time.deltaTime;
            var t = _fadeCount / fadeTime;
            t = fadeCurve.Evaluate(t);

            FadeToBlack.Instance.SetAlpha(t);
            yield return null;
        }

        FadeToBlack.Instance.SetAlpha(1);

        Menu.Instance.gameObject.SetActive(false);
        LevelSelect.Instance.gameObject.SetActive(false);
        if (_instantiatedLevel)
            Destroy(_instantiatedLevel.gameObject);
        Instantiate(levelPrefab);
        while (_fadeCount > 0)
        {
            _fadeCount -= Time.deltaTime;
            var t = _fadeCount / fadeTime;
            t = fadeCurve.Evaluate(t);

            FadeToBlack.Instance.SetAlpha(t);
            yield return null;
        }

        isTransitioning = false;
    }
}