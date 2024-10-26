using DG.Tweening;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private Vector3 _startPosition;
    private float _range;
    private float _damage;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private bool destroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyed) return;
        float distanceTravelled = Vector3.Distance(_startPosition, transform.position);
        if (distanceTravelled >= _range && !destroyed)
        {
            destroyThisObject();
        }
    }

    private void destroyThisObject()
    {
        destroyed = true;
        this.gameObject.transform.DOScale(0,0.2f).SetEase(Ease.Linear);
        _rigidbody2D.velocity = Vector2.zero;
        Destroy(gameObject,1f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(AllConst.Tags.Wall))
        {
            destroyThisObject();
        }
        if(other.TryGetComponent(out PlayerHealth _playerHealt))
        {
            _playerHealt.TakeDamage(_damage, transform.position);
            destroyThisObject();
        }
    }

    public void SetRange(float range)
    {
        _range = range;
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }
    
}
