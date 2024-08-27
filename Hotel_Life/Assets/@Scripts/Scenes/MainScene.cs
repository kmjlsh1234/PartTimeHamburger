using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : BaseScene
{
    private CustomerFactory _customerFactory;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.ESceneType.MainScene;

        //Map Generate
        Managers.Sound.Stop(Define.ESound.BGM);

        //CustomerFactory Generate
        if (_customerFactory == null)
        {
            var go = GameObject.Find("@CustomerFactory");

            if (_customerFactory == null)
            {
                go = new GameObject { name = "@CustomerFactory" };
                _customerFactory = go.AddComponent<CustomerFactory>();
                _customerFactory.transform.position = new Vector3(-33.0f, 0f, -33.0f);
            }
            else
            {
                _customerFactory = go.GetComponent<CustomerFactory>();
            }
        }

        return true;
    }

    public override void Clear()
    {
        
    }
}
