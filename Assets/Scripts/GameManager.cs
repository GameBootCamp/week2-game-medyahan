using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private List<State> states = new List<State>();

    private static IState currentState;

    private ScoreManager scoreManager;

    void Start()
    {
        SetState(StateType.StartState);
    }


    #region STATE MACHINE
    public void SetState(StateType stateType)
    {
   
        IState nextState = states.FirstOrDefault(x => x.stateType == stateType).state as IState;

        if (currentState == nextState) return;
        if (currentState != null) currentState.Exit();

        currentState = nextState;
        nextState.Enter();
    }

    public IState GetCurrentState()
    {
        return currentState;
    }
    #endregion

    #region Managers
    public void SetSaveManager(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }

    public void SetBestScore(int score)
    {
        this.scoreManager.SaveScore(score);
    }

    public int GetBestScore()
    {
        return this.scoreManager.GetBestScore();
    }

    #endregion
}

[System.Serializable]
public class State
{
    public StateType stateType;
    public MonoBehaviour state;
}

public enum StateType
{
    StartState,
    GameplayState,
    PauseState
}

public delegate void CallBack();