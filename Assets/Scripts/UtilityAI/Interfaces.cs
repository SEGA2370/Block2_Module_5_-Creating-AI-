using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction
{
    void Execute();
    float Score { get; }
}

public interface IConsideration
{
    float GetScore();
}
