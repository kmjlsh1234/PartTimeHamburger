using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerFactory
{
    public static Customer CreateCustomer(Define.ECustomerType type)
    {
        Customer customer = null;

        switch(type)
        {
            case Define.ECustomerType.Normal:
                customer = new NormalCustomer();
                //나중에 어드레서블로 Instantiate
                break;
            case Define.ECustomerType.Enemy:
                customer = new NormalCustomer();
                //나중에 어드레서블로 Instantiate
                break;
        }
        return customer;
    }
}
