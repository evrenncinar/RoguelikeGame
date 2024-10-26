using System;
using Cinemachine;
using UnityEngine;

public class PlayerShake : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _shakeCamera;
    private float _shakeTimer;
    private float _shakeTimerTotal;
    private float _startingIntensity;

    [Header("Shake Settings")]
    [Range(0,20f)]
    [SerializeField] float _onShootintensity = 2f;
    [Range(0,2f)]
    [SerializeField] float _onShoottime = .1f;
    [Range(0,50f)]
    [SerializeField] float _onShootfrequency = .1f;

    private void OnEnable() 
    {
        PlayerBulletManager.OnShoot += OnShootShakeCamera;    
        PlayerHealth.DamageAndHeal += DamageShakeCamera;
    }

    private void OnDisable() 
    {
        PlayerBulletManager.OnShoot -= OnShootShakeCamera;    
        PlayerHealth.DamageAndHeal -= DamageShakeCamera;
    }

    private void DamageShakeCamera(float arg1, float arg2, float arg3, Vector2 vector)
    {
        ShakeCamera();
    }

    private void OnShootShakeCamera(BulletSO sO, int arg2)
    {
        ShakeCamera();
    }
    
    void ShakeCamera(){
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = _shakeCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = _onShootintensity;
        _shakeTimer = _onShoottime;
        _shakeTimerTotal = _onShoottime;
        _startingIntensity = cinemachineBasicMultiChannelPerlin.m_AmplitudeGain;
    }
    

    void Update() {
        if(_shakeTimer > 0)
        {
            _shakeTimer -= Time.deltaTime;

            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = _shakeCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(_startingIntensity, 0f, 1 - (_shakeTimer / _shakeTimerTotal));   
        }
    }



}
