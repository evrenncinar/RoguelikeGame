using System;
using MilkShake;
using UnityEngine;

public class PlayerShake : MonoBehaviour
{
    [SerializeField] Shaker _shakeCamera;
    [SerializeField] ShakePreset _shakerPreset;

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
        _shakeCamera.Shake(_shakerPreset);
    }



}
