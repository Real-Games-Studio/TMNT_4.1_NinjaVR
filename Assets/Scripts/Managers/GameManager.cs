using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;


public enum GameStates
{
    OnMenu,
    Playing,
    End
}
public class GameManager : MonoBehaviour
{
    public GameStates currentState;
    [SerializeField] private GameObject _playerLeftHand, _playerRightHand;
    [SerializeField] private GameObject _winScreen, _pauseScreen;
    [SerializeField] private GameObject[] _uisToDisable;

    private void Awake()
    {
        ChangeState(GameStates.OnMenu);
    }

    public void ChangeState(GameStates state)
    {
        currentState = state;
    }

    public void EndGame()
    {
        ChangeState(GameStates.End);
        Manager.Instance.FruitsPool.DisableAllFruits();
        DisableUIElements();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _pauseScreen.SetActive(true);
        ChangeRaycastInteractor(true);
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        _pauseScreen.SetActive(false);
        ChangeRaycastInteractor(false);
    }

    private void DisableUIElements()
    {
        _winScreen.SetActive(true);

        for (int i = 0; i < _uisToDisable.Length; i++)
            _uisToDisable[i].SetActive(false);
    }
    private void ChangeRaycastInteractor(bool state)
    {
        _playerLeftHand.GetComponent<XRRayInteractor>().enabled = state;
        _playerLeftHand.GetComponent<LineRenderer>().enabled = state;
        _playerLeftHand.GetComponent<XRInteractorLineVisual>().enabled = state;
        _playerLeftHand.GetComponent<SortingGroup>().enabled = state;

        _playerRightHand.GetComponent<XRRayInteractor>().enabled = state;
        _playerRightHand.GetComponent<LineRenderer>().enabled = state;
        _playerRightHand.GetComponent<XRInteractorLineVisual>().enabled = state;
        _playerRightHand.GetComponent<SortingGroup>().enabled = state;
    }


}