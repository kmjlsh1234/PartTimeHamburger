using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerFactory : MonoBehaviour
{
    public static GameObject CreateCustomer(Define.ECustomerType type)
    {
        GameObject customer = null;

        switch(type)
        {
            case Define.ECustomerType.Normal:
                customer = Managers.Resource.Load<GameObject>("Customer_Normal_01");
                //나중에 어드레서블로 Instantiate
                break;
            case Define.ECustomerType.Enemy:
                
                //나중에 어드레서블로 Instantiate
                break;
        }
        return customer;
    }
}
