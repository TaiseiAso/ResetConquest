using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class Title : MonoBehaviour {

    public GameObject _titleTextObject;
    public GameObject _gameSelectTextObject;
    public GameObject _rightArrowObject;

    public Animation _newGameTextAnimation;
    public Animation _loadGameTextAnimation;
    public Animation _achievementTextAnimation;
    public Animation _configTextAnimation;
    public Animation _exitTextAnimation;

    public int _scene;
    public int _arrowPos;

    private double _waitTime;

    void Awake() {
        _titleTextObject.SetActive (true);
        _gameSelectTextObject.SetActive(false);

        _scene = SceneMode.TITLE;
        _arrowPos = SelectMode.NEW_GAME;

        _waitTime = 0;
    }

    void Update() {
        if (_waitTime > 0) _waitTime -= Time.deltaTime;
        if (_waitTime <= 0) {
            switch (_scene) {
                case SceneMode.TITLE:
                    if (Input.anyKeyDown) {
                        _scene = SceneMode.GAME_SELECT;
                        _titleTextObject.SetActive (false);
                        _gameSelectTextObject.SetActive(true);
                    }
                    break;

                case SceneMode.GAME_SELECT:
                    if (Input.GetKeyDown(KeyCode.Space)) {
                        _rightArrowObject.SetActive(false);
                        switch (_arrowPos) {
                            case SelectMode.NEW_GAME:
                                _scene = SceneMode.NEW_GAME_WAIT;
                                _waitTime = 2.0;
                                break;
                            case SelectMode.LOAD_GAME:
                                FadeManager._instance.Fade(FadeMode.LOAD_SCENE,
                                () => {
                                    SceneManager.LoadScene("Load");
                                });
                                break;
                            case SelectMode.ACHIEVEMENT:
                                FadeManager._instance.Fade(FadeMode.LOAD_SCENE,
                                () => {
                                    SceneManager.LoadScene("Achievement");
                                });
                                break;
                            case SelectMode.CONFIG:
                                FadeManager._instance.Fade(FadeMode.LOAD_SCENE,
                                () => {
                                    SceneManager.LoadScene("Config");
                                });
                                break;
                            case SelectMode.EXIT:
                                _scene = SceneMode.EXIT_WAIT;
                                _waitTime = 0.6;
                                break;
                        }
                        PlaySelectAnimation();
                    } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
                        if (_arrowPos > SelectMode.NEW_GAME) {
                            _arrowPos --;
                            MoveRightArrow();
                        }
                    } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                        if (_arrowPos < SelectMode.EXIT) {
                            _arrowPos ++;
                            MoveRightArrow();
                        }
                    }
                    break;

                case SceneMode.NEW_GAME_WAIT:
                    FadeManager._instance.Fade(FadeMode.LOAD_SCENE,
                    () => {
                        SceneManager.LoadScene("Game");
                    });
                    break;

                case SceneMode.EXIT_WAIT:
                    #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                    #elif UNITY_STANDALONE
                    UnityEngine.Application.Quit();
                    #endif
                    break;
            }
        }
    }

    private void MoveRightArrow() {
        Transform myTransform = _rightArrowObject.transform;
        Vector2 pos = myTransform.localPosition;
        pos.y = 280 - 60 * (_arrowPos - SelectMode.NEW_GAME);
        myTransform.localPosition = pos;
    }

    private void PlaySelectAnimation() {
        if (_arrowPos == SelectMode.NEW_GAME) _newGameTextAnimation.Play("FadeOutZoomIn");
        else _newGameTextAnimation.Play("FadeOut");
        if (_arrowPos == SelectMode.LOAD_GAME) _loadGameTextAnimation.Play("FadeOutZoomIn");
        else _loadGameTextAnimation.Play("FadeOut");
        if (_arrowPos == SelectMode.ACHIEVEMENT) _achievementTextAnimation.Play("FadeOutZoomIn");
        else _achievementTextAnimation.Play("FadeOut");
        if (_arrowPos == SelectMode.CONFIG) _configTextAnimation.Play("FadeOutZoomIn");
        else _configTextAnimation.Play("FadeOut");
        if (_arrowPos == SelectMode.EXIT) _exitTextAnimation.Play("FadeOutZoomIn");
        else _exitTextAnimation.Play("FadeOut");
    }
}
