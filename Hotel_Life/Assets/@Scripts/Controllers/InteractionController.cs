using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public Define.EWeaponState WeaponState
    {
        get
        {
            return weaponState;
        }
        set
        {
            weaponState = value;
            SwitchState(weaponState);
        }
    }
    Define.EWeaponState weaponState = Define.EWeaponState.Scanner;
    Animator _anim;
    Ray ray;
    RaycastHit hit;

    [SerializeField] private GameObject _weapon;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();

        _weapon = Util.FindChild(gameObject, "Weapon", true);
        SwitchState(weaponState);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            CastRay(ray);
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Alpha1))
            WeaponState = Define.EWeaponState.Scanner;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            WeaponState = Define.EWeaponState.Bat;
#else
        
#endif

    }

    private void CastRay(Ray ray)
    {
        if(Physics.Raycast(ray, out hit, 20f))
        {
            Interaction(hit);
            Debug.Log($"CastRay - {hit.collider.gameObject.name}");
        }
    }

    private void SwitchState(Define.EWeaponState state)
    {
        switch(state)
        {
            case Define.EWeaponState.Scanner:
                _weapon.SetActive(false);
                break;
            case Define.EWeaponState.Bat:
                _weapon.SetActive(true);
                break;
        }
    }

    private void Interaction(RaycastHit hit)
    {
        switch(weaponState)
        {
            case Define.EWeaponState.Scanner:
                _anim.SetTrigger("Work");
                break;
            case Define.EWeaponState.Bat:
                Managers.Sound.Play(Define.ESound.Effect, "SFX_BatSwing");
                _anim.SetTrigger("Attack");
                break;
        }
    }
}
