using System.Collections.Generic;
using UnityEngine;

public class RandUtil
{
    public static T Choice<T>(List<T> collection) where T : class
    {
        if (collection.Count == 0)
        {
            return default(T);
        }
        int index = Random.Range(0, collection.Count - 1);
        return collection[index];
    }
}
