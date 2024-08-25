using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    #region Player
    public Transform Player
    {
        get
        {
            if (player == null)
                player = GameObject.FindGameObjectWithTag("Player").transform;

            return player;
        }
    }

    private Transform player;
    public Vector2 _moveDir;
    public Vector2 MoveDir
    {
        get { return _moveDir;}
        set { 
            _moveDir = value;
            OnMoveDirChanged?.Invoke(value);
        }
    }

    private Define.EJoystickState _joystickState;
    public Define.EJoystickState JoystickState
    {
        get { return _joystickState; }
        set
        {
            _joystickState = value;
            OnJoystickStateChanged?.Invoke(_joystickState);
        }
    }
    #endregion

    #region Action
    public event Action<Vector2> OnMoveDirChanged;
    public event Action<Define.EJoystickState> OnJoystickStateChanged;
    #endregion
}
