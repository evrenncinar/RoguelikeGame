using UnityEngine;

public class BulletPickUp : MonoBehaviour
{
    public BulletSO _bulletType;
    private Animator _animator;
    void Start() 
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger(AllConst.BulletAnimation.Spawn);
    }

    public void CollectBullet()
    {
        _animator.SetTrigger(AllConst.BulletAnimation.Pickup);
        Destroy(this.gameObject,1f);
    }
    
}
