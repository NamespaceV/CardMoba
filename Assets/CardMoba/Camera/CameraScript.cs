using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float intendedWidth = 1920;
    public float intendedHeight = 1080;

    public AnimationCurve screenShake;

    private Camera _camera;
    private float _initialSize;
    private float _intendedAspect = 1;
    private float _screenShakePhase = 1;

    void Start()
    {
        _camera = GetComponent<Camera>();
        _initialSize = _camera.orthographicSize;
        _intendedAspect = intendedWidth / intendedHeight;
        _screenShakePhase = screenShake.keys.Last().time;
    }

    void Update()
    {
        _screenShakePhase += Time.deltaTime;
        _camera.orthographicSize = GetShakePct() * _initialSize * GetAspectPct();
    }

    private float GetAspectPct()
    {
        var aspectPct = _intendedAspect * _camera.pixelHeight / _camera.pixelWidth;
        if (aspectPct < 1)
        {
            aspectPct = 1;
        }
        return aspectPct;
    }

    private float GetShakePct()
    {
        if (_screenShakePhase > screenShake.keys.Last().time)
        {
            return 1;
        }
        return screenShake.Evaluate(_screenShakePhase);
    }

    public void DoAScreenShake()
    {
        _screenShakePhase = 0;
    }
}
