using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    public enum ESceneType
    {
        Unknown,
        SplashScene,
        MainScene,
    }
    public enum ESound
    {
        BGM,
        Effect,
        Max,
    }

    public enum EUIEvent
    {
        Click,
        PointerDown,
        PointerUp,
        Drag,
    }

    public enum EWeaponState
    {
        Scanner,
        Bat,
    }

    public enum EJoystickState
    {
        PointerDown,
        PointerUp,
        Drag,
    }

    public enum ECustomerType
    {
        Normal,
        Enemy,
    }
}
