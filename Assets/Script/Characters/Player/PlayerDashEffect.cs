using UnityEngine;
using DG.Tweening;

public class PlayerDashEffect : MonoBehaviour
{
    [SerializeField] float fadeTime = 0.5f;

    void Start()
    {
        this.GetComponent<SpriteRenderer>().DOFade(0f, fadeTime).SetEase(Ease.Linear).onComplete = () => Destroy(this.gameObject);
    }
}
