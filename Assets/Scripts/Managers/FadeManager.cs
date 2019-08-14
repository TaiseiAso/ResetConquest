using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
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
        float waitTime = 0;

        switch (fadeMode) {
            case FadeMode.LOAD_SCENE:
                GameObject fadeCanvas = (GameObject)Instantiate(Resources.Load("Prefabs/Others/FadeCanvas"));
                Image fadeImage = fadeCanvas.GetComponent<Image>();
                Color fadeColor = fadeImage.color;
                fadeColor.a = 0.0f;
                fadeImage.color = fadeColor;
                fadeCanvas.transform.SetParent(transform);

                float interval = 0.5f;
                while(waitTime < interval) {
                    fadeColor.a = waitTime / interval;
                    fadeImage.color = fadeColor;
                    waitTime += Time.deltaTime;
                    yield return null;
                }
                callback();
                waitTime = 0;
                while(waitTime < interval) {
                    fadeColor.a = 1.0f - waitTime / interval;
                    fadeImage.color = fadeColor;
                    waitTime += Time.deltaTime;
                    yield return null;
                }
                break;
        }

        foreach(Transform n in transform) Destroy(n.gameObject);
        _isFading = false;
    }

    public void Fade(int fadeMode, UnityAction callback) {
        if (!_isFading) StartCoroutine(Coroutine(fadeMode, callback));
    }
}
