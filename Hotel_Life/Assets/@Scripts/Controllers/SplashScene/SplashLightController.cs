using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SplashLightController : InitBase
{
    private Light _light;
    private Coroutine _lightRoutine;
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _light = GetComponent<Light>();
        if (_lightRoutine != null)
            StopCoroutine(_lightRoutine);

        _lightRoutine = StartCoroutine(LightActive());
        return true;
    }

    IEnumerator LightActive()
    {
        _light.DOIntensity(1f, 0.5f).SetLoops(2,LoopType.Yoyo);
        yield return new WaitForSeconds(1f);
        _light.DOIntensity(1f, 0.5f).SetLoops(2, LoopType.Yoyo);
        yield return new WaitForSeconds(1f);
        _light.DOIntensity(3f, 0.5f);
        yield return new WaitForSeconds(3f);
    }
}
