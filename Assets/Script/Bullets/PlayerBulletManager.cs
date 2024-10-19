using UnityEngine;

public class PlayerBulletManager : MonoBehaviour
{
    public static event System.Action<BulletSO,int> OnShoot;
    public static event System.Action<BulletSO> CollectBulletEvent;
    //
    [SerializeField] private BulletSO _currentBullet;
    [SerializeField] private int _currentBulletCount;
    //
    [SerializeField] private bool canCollectBullet;
    [SerializeField] private BulletSO _bulletToCollect;
    [SerializeField] private BulletPickUp _collectBulletPickUp;

    void Update() 
    {
        if(canCollectBullet && Input.GetMouseButtonDown(1))
        {
            CollectBullet();
        }    
    }

    private void CollectBullet()
    {
        if(_bulletToCollect != null)
        {
            _currentBullet = _bulletToCollect;
            _currentBulletCount = _bulletToCollect._bulletCount;
            _collectBulletPickUp.CollectBullet();
            CollectBulletEvent?.Invoke(_currentBullet);
            print("Mermi toplandı : " + _currentBullet._bulletName);
            _bulletToCollect = null;
            canCollectBullet = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetComponent<BulletPickUp>(out BulletPickUp _bulletPickUp))
        {
            _bulletToCollect = _bulletPickUp._bulletType;
            _collectBulletPickUp = _bulletPickUp;
            canCollectBullet = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.TryGetComponent<BulletPickUp>(out BulletPickUp _bulletPickUp))
        {
            canCollectBullet = false;
            _collectBulletPickUp = null;
            _bulletToCollect = null;
        }
    }

    public void ShootBullet()
    {
        if(_currentBulletCount > 0)
        {
            _currentBulletCount--;

            OnShoot?.Invoke(_currentBullet,_currentBulletCount);

            if(_currentBulletCount == 0)
            {
                _currentBullet = null;
            }
            print("Mermi Kaldı : " + _currentBulletCount);
        }
    }

    public BulletSO GetCurrentBullet()
    {
        return _currentBullet;
    }
}
