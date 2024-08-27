using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : InitBase
{
    private Animator _anim;
    private List<CustomerData> customerData = new List<CustomerData>();
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _anim = GetComponentInChildren<Animator>();
        return true;
    }

    public void SetData(Define.ECustomerType type)
    {
        customerData.Clear();
        foreach(KeyValuePair<int, CustomerData> kvp in Managers.Data.CustomerDic)
        {
            if (kvp.Value.CustomerType == type.ToString())
                customerData.Add(kvp.Value);
        }
    }

    
}
