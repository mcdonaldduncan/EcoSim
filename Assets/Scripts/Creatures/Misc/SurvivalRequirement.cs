using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalRequirement
{
    string Type { get; set; }
    string Description { get; set; }
    float MaxValue { get; set; }
    float CurrentValue { get; set; }
    NeedState State => SetState();
    float StateThreshold => MaxValue / Enum.GetValues(typeof(NeedState)).Length;

    public void DecrementCurrentValue(float decrementBy)
    {
        CurrentValue -= decrementBy;
    }

    public void IncrementCurrentValue(float incrementBy)
    {
        CurrentValue += incrementBy;
    }

    public NeedState GetState()
    {
        return State;
    }

    private NeedState SetState()
    {
        return (NeedState)MathF.Floor(CurrentValue/StateThreshold);
    }


}
