using UnityEngine;
using UnityEngine.UI;

public class PauseState : MonoBehaviour, IState
{
    [SerializeField] private GameObject pauseScreen;
    private Button resumeButton;

    public void Enter()
    {
        pauseScreen.SetActive(true);
        resumeButton = pauseScreen.GetComponentInChildren<Button>();
        resumeButton.onClick.AddListener(ResumeGame);
        Time.timeScale = 0f;
    }

    public void Exit()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    private void ResumeGame()
    {
        GameManager.Instance.SetState(StateType.GameplayState);
    }
}
