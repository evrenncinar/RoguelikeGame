using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SpawnAnimation : MonoBehaviour
{
    [SerializeField] float _moveTime = 0.2f;
    [SerializeField] float _opacityTime = 0.5f;
    [SerializeField] float xOffset = 0.2f;
    [SerializeField] Ease _ease = Ease.Unset;
    [SerializeField] GameObject _target;
    
    void Start()
    {
        _target.SetActive(false);
        this.gameObject.transform.position = new Vector3(_target.transform.position.x,50f,0f);
        this.gameObject.transform.DOMove(new Vector3(_target.transform.position.x,_target.transform.position.y - xOffset,0f),_moveTime).SetEase(_ease).onComplete = () => {
            _target.SetActive(true);
            this.gameObject.GetComponent<SpriteRenderer>().DOFade(0f,_opacityTime).SetEase(_ease).onComplete = () => {
                Destroy(this.gameObject);
            };
        };   
    }
}
