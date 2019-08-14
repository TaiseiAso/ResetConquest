using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Common;

public class FadeManager : MonoBehaviour {

    public static FadeManager _instance;

    public bool _isFading;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBoot() {
        new GameObject("FadeManager", typeof(FadeManager));
    }

    void Awake() {
        if (_instance != null) Destroy(gameObject);
        else _instance = this;
        DontDestroyOnLoad(gameObject);

        _isFading = false;
    }

    private IEnumerator Coroutine(int fadeMode, UnityAction callback) {
        _isFading = true;

        switch (fadeMode) {
            case FadeMode.LOAD_SCENE:
                yield return null;
                callback();

                break;
        }

        _isFading = false;
    }

    public void Fade(int fadeMode, UnityAction callback) {
        if (!_isFading) StartCoroutine(Coroutine(fadeMode, callback));
    }
}
