using System.Collections.Generic;

public class UtilityAI
{
    private List<IAction> _actions;

    public UtilityAI(List<IAction> actions)
    {
        _actions = actions;
    }

    public void DecideAndAct()
    {
        IAction bestAction = null;
        float highestScore = float.MinValue;

        foreach (var action in _actions)
        {
            if (action.Score > highestScore)
            {
                highestScore = action.Score;
                bestAction = action;
            }
        }

        bestAction?.Execute();
    }
}
