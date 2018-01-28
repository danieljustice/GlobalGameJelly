using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableBool: ScriptableObject
{
    public bool b;

    public bool GetValue()
    {
        return b;
    }

    public void SetValue(bool n)
    {
        b = n;
    }
}
