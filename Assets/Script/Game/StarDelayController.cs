using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDelayController : MonoBehaviour
{
    [SerializeField] private float delay = 0.5f;
    [SerializeField] private MonoBehaviour[] _targetScripts;
    
    private void Awake() 
    {
        foreach (MonoBehaviour script in _targetScripts)
        {
            script.enabled = false;
        }
    }
    void Start()
    {
        Invoke("EnableScript",delay);
    }

    void EnableScript()
    {
        foreach (MonoBehaviour script in _targetScripts)
        {
            script.enabled = true;
        }
    }
}
