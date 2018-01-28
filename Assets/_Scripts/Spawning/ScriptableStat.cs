using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableStat : ScriptableObject
{
    public float number;

    public float GetValue()
    {
        return number;
    }

    public void SetValue(float n)
    {
        number = n;
    }

    public void ApplyChange(float amount)
    {
        number += amount;
    }
}