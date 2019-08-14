using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour {

    private int _x;
    private int _y0;
    private int _y1;
    private double _t;
    private double _period;

    void Awake() {
        _x = 0;
        _y0 = 0;
        _y1 = 100;
        _t = 0.0;
        _period = 1.0;
    }

    void Update() {
        _t += Time.deltaTime;

        Vector2 pos = transform.localPosition;
        pos.y = Lerp(_y0, _y1, (Math.Sin(2*Math.PI*_t/_period) + 1.0)*0.5);
        transform.localPosition = pos;

        while (_t > _period) _t -= _period;
    }

    private int Lerp(int y0, int y1, double ratio) {
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

        Vector2 pos = transform.localPosition;
        pos.x = _x;
        pos.y = Lerp(_y0, _y1, (Math.Sin(2*Math.PI*_t/_period) + 1.0)*0.5);
        transform.localPosition = pos;
    }
}
