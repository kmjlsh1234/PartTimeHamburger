using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public BaseScene CurrentScene { get { return GameObject.FindAnyObjectByType<BaseScene>(); } }

    public void LoadScene(Define.ESceneType type)
    {
        SceneManager.LoadScene(GetSceneName(type));
    }

    private string GetSceneName(Define.ESceneType type)
    {
        string name = System.Enum.GetName(typeof(Define.ESceneType),type);
        return name;
    }

    public void Clear()
    {
        CurrentScene.Clear();
    }
}
