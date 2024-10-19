using UnityEngine;
using DG.Tweening;

public class PlayerBulletShooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] PlayerBulletManager _playerBulletManager;
    [SerializeField] private bool canShoot = true;
    public static event System.Action NoBulletEvent;

    void Start() 
    {
        _playerBulletManager = GetComponent<PlayerBulletManager>();    
    }

    void Update() {
        if(Input.GetMouseButtonDown(0))
        {
            if(_playerBulletManager.GetCurrentBullet() != null && canShoot)
            {
                Shoot();
                _playerBulletManager.ShootBullet();
            }
            else if(_playerBulletManager.GetCurrentBullet() == null)
            {
                NoBulletEvent?.Invoke();
            }
        }
    }

    private void Shoot()
    {
        canShoot = false;
        //Mouse pozisyon al
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; 
        Vector3 direction = (mousePosition - _firePoint.position).normalized;
        
        // Mermi Özelliklerini al
        BulletSO _currentBullet = _playerBulletManager.GetCurrentBullet();

        //Mermiyi Spawnla ve kuvvet ver
        GameObject bullet = Instantiate(_currentBullet._bulletPrefab, _firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * _currentBullet._speed;

        // Mermiye menzil ayarlaması ekle
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetRange(_currentBullet._range);
        bulletScript.SetDamage(_currentBullet._damage);

        //karaktere geri sekmesi ekle
        Vector3 recoilPosition = transform.position - direction * _currentBullet._recoilForce;
        transform.DOMove(recoilPosition,0.2f); 

        // Attack Cooldownı ekle
        Invoke(nameof(FinishCoolDown), _currentBullet._fireRate);
    }

    private void FinishCoolDown()
    {
        canShoot = true;
    }
}
