using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    private int _x; // X座標
    private int _y0; // Y座標の最小範囲
    private int _y1; // Y座標の最大範囲
    private double _t; // 経過時間(s)
    private double _period; // 周期(s)

    void Awake() {
        _x = 0;
        _y0 = 0;
        _y1 = 100;
        _t = 0.0;
        _period = 1.0;
    }

    private int lerp(int y0, int y1, double ratio) {
        if (ratio < 0.0) ratio = 0.0;
        else if (ratio > 1.0) ratio = 1.0;

        return (int)((1.0 - ratio)*y0 + ratio*y1);
    }

    public void Set(int x, int y0, int y1, double t, double period) {
        _x = x;
        _y0 = y0;
        _y1 = y1;
        _t = t;
        _period = period;

        while (_t > _period) _t -= _period;
        while (_t < 0) _t += _period;

        Vector2 pos = transform.position;
        pos.x = _x;
        pos.y = lerp(_y0, _y1, (Math.Sin(2*Math.PI*_t/_period) + 1.0)*0.5);
        transform.position = pos;
    }

    void Update() {
        _t += Time.deltaTime;

        Vector2 pos = transform.position;
        pos.y = lerp(_y0, _y1, (Math.Sin(2*Math.PI*_t/_period) + 1.0)*0.5);
        transform.position = pos;

        while (_t > _period) _t -= _period;
    }
}
