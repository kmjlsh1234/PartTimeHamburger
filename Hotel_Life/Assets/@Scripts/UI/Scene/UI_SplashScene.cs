using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SplashScene : UI_Scene
{
    enum GameObjects
    {
        StartButton,
    }
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObjects(typeof(GameObjects));
        GetObject((int)GameObjects.StartButton).BindEvent((evt) => { MoveNextScene(); });
        GetObject((int)GameObjects.StartButton).SetActive(false);
        StartLoadAssets();

        return true;
    }

    void StartLoadAssets()
    {
        Managers.Resource.LoadAllAscync<Object>("PreLoad", (key, count, totalCount) => {
            Debug.Log($"Key {key} : {count}/{totalCount}");

            if (count == totalCount)
            {
                Managers.Data.Init();
                Managers.Sound.Init();
                Managers.Sound.Play(Define.ESound.BGM, "BGM_Splash");
                GetObject((int)GameObjects.StartButton).SetActive(true);
            }
        });
    }


    private void MoveNextScene()
    {
        Debug.Log("MoveNextScene");
        Managers.Scene.LoadScene(Define.ESceneType.MainScene);
    }


}
