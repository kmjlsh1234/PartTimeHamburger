using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SplashScene : BaseScene
{
    private Coroutine _lightRoutine;
    private Light _light;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.ESceneType.SplashScene;

        _light = GetComponentInChildren<Light>();
        if (_lightRoutine != null)
            StopCoroutine(_lightRoutine);

        _lightRoutine = StartCoroutine(LightActive());

        return true;
    }

    IEnumerator LightActive()
    {
        _light.DOIntensity(1f, 0.5f).SetLoops(2, LoopType.Yoyo);
        yield return new WaitForSeconds(1f);
        _light.DOIntensity(1f, 0.5f).SetLoops(2, LoopType.Yoyo);
        yield return new WaitForSeconds(1f);
        _light.DOIntensity(3f, 0.5f);
        yield return new WaitForSeconds(3f);
    }

    public override void Clear()
    {
        if (_lightRoutine != null)
            StopCoroutine(_lightRoutine);

        _light = null;
        _lightRoutine = null;

    }
}
