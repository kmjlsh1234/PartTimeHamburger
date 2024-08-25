using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : BaseScene
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.ESceneType.MainScene;

        //Map Generate
        Managers.Sound.Stop(Define.ESound.BGM);
        return true;
    }

    public override void Clear()
    {
        
    }
}
