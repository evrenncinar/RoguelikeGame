using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static event System.Action OnGamePaused;
    public static event System.Action OnGameResumed;

    public void Pause()
    {
        OnGamePaused?.Invoke();
    }

    public void Resume()
    {
        OnGameResumed?.Invoke();
    }
    
    // private void Start() {
    //     Invoke("Pause", 3f);
    //     Invoke("Resume", 6f);
    // }
}
