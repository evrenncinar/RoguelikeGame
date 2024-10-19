using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed = 5f;
    private bool isGamePaused = false;
    private Rigidbody2D _rigidbody2D;
    private float _horizontal;
    private float _vertical;

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 20f;   // Dash sırasında hız
    [SerializeField] private float dashDuration = 0.2f;   // Dash süresi
    [SerializeField] private float dashCooldown = 2f; // Dash cooldown süresi
    [SerializeField] private GameObject _dashEffectPrefab;
    private bool isDashing = false;
    private float dashTime;    
    private float dashCooldownTimer;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isGamePaused) return;

        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }

        if (isDashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0f)
            {
                isDashing = false;
            }
            return;
        }

        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && IsMove() && dashCooldownTimer <= 0f)
        {
            Dash();
        }
    }

    void FixedUpdate()
    {
        if (isGamePaused) return;

        if (isDashing)
        {
            _rigidbody2D.velocity = new Vector2(_horizontal, _vertical).normalized * dashSpeed;
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(_horizontal, _vertical).normalized * moveSpeed;
        }
    }

    void Dash()
    {
        isDashing = true;
        dashTime = dashDuration;
        InstantiateDashEffect().Forget();
        dashCooldownTimer = dashCooldown;
        _rigidbody2D.velocity = new Vector2(_horizontal, _vertical).normalized * dashSpeed;
    }

    private async UniTaskVoid InstantiateDashEffect()
    {
        while (isDashing)
        {
            Instantiate(_dashEffectPrefab, transform.position, transform.rotation);
            await UniTask.Delay(TimeSpan.FromSeconds(0.08f));
        }
    }

    public bool IsMove()
    {
        return _horizontal != 0 || _vertical != 0;
    }

    public void StopPlayer()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }
    
    // -------------------------------------------------------------------------------------
    private void OnEnable() {
        GameController.OnGamePaused += Stop;
        GameController.OnGameResumed += Resume;
    }
    private void OnDisable() {
        GameController.OnGamePaused -= Stop;
        GameController.OnGameResumed -= Resume;
    }

    public void Stop()
    {
        _rigidbody2D.velocity = Vector2.zero;
        isGamePaused = true;
    }
    public void Resume()
    {
        isGamePaused = false;
    }
}
