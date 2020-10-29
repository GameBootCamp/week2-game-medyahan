using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartState : MonoBehaviour, IState
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private Text startText;
    [SerializeField] private Text bestText;

    public bool isStartScreen;
    private Coroutine coroutine;
    private InputController inputController;


    public void Enter()
    {
        inputController = new InputController(HandleInputResult);

        isStartScreen = true;
        coroutine = StartCoroutine(WaitForStart());
        startScreen.SetActive(true);
        
        bestText.text = GameManager.Instance.GetBestScore().ToString();
    }


    private void HandleInputResult()
    {
        GameManager.Instance.SetState(StateType.GameplayState);
    }

    public void Exit()
    {
        isStartScreen = false;
        inputController = null;
        StopCoroutine(coroutine);
        startScreen.SetActive(false);
    }

    private void Update()
    {
        
        if (GameManager.Instance.GetCurrentState() != this) return;

        inputController?.GetInput();
    }
    

    private IEnumerator WaitForStart()
    {
        float a = 0;

        while (isStartScreen)
        {
            var val = Mathf.PingPong(a, 0.5f) + 0.5f;
            startText.color = new Color(1, 1, 1, val);
            yield return null;
            a += Time.deltaTime;
        }
    }

}
