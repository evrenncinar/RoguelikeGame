using DG.Tweening;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _flipSpeed = 0.2f;
    private bool facingRight = true;

    void Update()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _target.transform.position;
        if (direction.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (direction.x < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        if(facingRight == true)
            _target.transform.DOScaleX(1f,_flipSpeed);
        else
            _target.transform.DOScaleX(-1f,_flipSpeed);
    }
}
