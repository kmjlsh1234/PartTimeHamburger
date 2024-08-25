using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    #region CustomerData
    [System.Serializable]
    public class CustomerData
    {
        public int ID;
        public string CustomerName;
        public Define.ECustomerType CustomerType;
        public float Speed;
    }

    [System.Serializable]
    public class CustomerDataLoader : ILoader<int, CustomerData>
    {
        public List<CustomerData> CustomDataList = new List<CustomerData>();

        public Dictionary<int, CustomerData> MakeDict()
        {
            Dictionary<int, CustomerData> dict = new Dictionary<int, CustomerData>();
            foreach (CustomerData data in CustomDataList)
                dict.Add(data.ID, data);
            return dict;
        }
    }

    #endregion
}