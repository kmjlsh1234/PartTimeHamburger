using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SplashScene : BaseScene
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.ESceneType.SplashScene;
        
        return true;
    }

    private void Start()
    {
        
    }


    public override void Clear()
    {
        
    }
}
