using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Random = UnityEngine.Random;

public static class Utill
{
    public static T WeightRandom<T>(WeightRandomData<T>[] weightArray) where T : Enum
    {
        int sumWeight = 0;
        weightArray.ToList().ForEach((weightData) => { sumWeight += weightData.Weight; });
        int randomValue = Random.Range(0, sumWeight);


        weightArray = weightArray.OrderBy((weightData) => { return weightData.Weight; }).ToArray();
        int beforeSumWeight = 0;

        foreach (var item in weightArray)
        {
            if (randomValue < item.Weight + beforeSumWeight)
            {
                return item.GetT;
            }
            else
            {
                beforeSumWeight += item.Weight;
            }
        }
#if UNITY_EDITOR
        Debug.Log("ºüÁ®³ª¿È");
#endif
        return weightArray[^1].GetT;
    }

    public static int WeightRandomToInt<T>(WeightRandomData<T>[] weightArray) where T : Enum
    {
        int sumWeight = 0;
        weightArray.ToList().ForEach((weightData) => { sumWeight += weightData.Weight; });
        int randomValue = Random.Range(0, sumWeight);


        weightArray = weightArray.OrderBy((weightData) => { return weightData.Weight; }).ToArray();
        int beforeSumWeight = 0;

        foreach (var item in weightArray)
        {
            if (randomValue < item.Weight + beforeSumWeight)
            {
                Debug.Log((int)Convert.GetTypeCode(item.GetT));
                return (int)Convert.GetTypeCode(item.GetT);
            }
            else
            {
                beforeSumWeight += item.Weight;
            }
        }
#if UNITY_EDITOR
        Debug.Log("ºüÁ®³ª¿È");
#endif
        return (int)Convert.GetTypeCode(weightArray[^1].GetT);
    }
}
