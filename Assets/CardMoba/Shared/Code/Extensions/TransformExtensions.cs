
using System.Collections.Generic;
using UnityEngine;
using Transform = UnityEngine.Transform;

public static class TransformExtensions
{
    public static List<GameObject> GetChildren(this Transform me) {
        var r = new List<GameObject>(me.childCount);
        for (int i = 0; i < me.childCount; ++i) {
            r.Add(me.GetChild(i).gameObject);
        }
        return r;
    }
}