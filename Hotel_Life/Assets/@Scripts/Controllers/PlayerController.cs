using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : InitBase
{
    private CharacterController controller;

    private float speed = 5.0f;
    private float gravity = -1.0f;

    Vector3 velocity;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        controller = gameObject.GetOrAddComponent<CharacterController>();

        return true;
    }

    void Update()
    {
#if UNITY_EDITOR
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");       
#else
        float x = Managers.Game.MoveDir.x;
        float z = Managers.Game.MoveDir.z;
#endif
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
