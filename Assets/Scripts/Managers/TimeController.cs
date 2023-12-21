using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using VRBeats.ScriptableEvents;

public class TimeController : MonoBehaviour
{
    [SerializeField] private int timeleft = 60;
    [SerializeField] private Text timeTxt;
    [SerializeField] FruitsSpawner spawner;

    // [SerializeField] private GameEvent onLevelComplete = null;

    private void Start()
    {
        timeTxt.text = "00:00";
    }
    public void StartTimer()
    {
        InvokeRepeating("Countdown", 0, 1);
        Manager.Instance.GameManager.ChangeState(GameStates.Playing);
    }

    void Countdown()
    {
        int min = Mathf.FloorToInt(timeleft / 60);
        int sec = Mathf.FloorToInt(timeleft % 60);

        if (timeleft > 0)
        {
            timeleft--;
            timeTxt.text = min.ToString() + ":" + sec.ToString("00");
        }
        else if (spawner.CanSpawn)
        {
            timeTxt.text = "0:00";
            CancelInvoke();
            TriggerEndgameEvent();
            spawner.CanSpawn = false;
        }
    }

    public void TriggerEndgameEvent()
    {
        Manager.Instance.GameManager.EndGame();
    }
}
