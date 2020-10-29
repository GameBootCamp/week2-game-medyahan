using UnityEngine;
using UnityEngine.UI;

public class GameplayState : MonoBehaviour, IState
{
    [SerializeField] private PlayerController player;
    [SerializeField] private DropController dropController;
    [SerializeField] private GameObject pauseButtonObject;
    
    private Button pauseButton;

    public void Enter()
    {
        pauseButtonObject.SetActive(true);

        pauseButton = pauseButtonObject.GetComponentInChildren<Button>();
        pauseButton.onClick.AddListener(PauseGame);
        player.enabled = true;
        player.SetCallBack(StopGameLoop);
        dropController.enabled = true;
    }

    public void Exit()
    {
        pauseButtonObject.SetActive(false);
        dropController.enabled = false;
    }

    private void StopGameLoop()
    {
        player.Reset();
        player.enabled = false;
        //dropController.enabled = false;
    }

    private void PauseGame()
    {
        GameManager.Instance.SetState(StateType.PauseState);
    }
}
