using UnityEngine;
using DG.Tweening;
public class MIxColors : MonoBehaviour
{
    [SerializeField]private Transform liquid;

    public void liquidUP()
    {
        liquid.gameObject.SetActive(true);
        liquid.DOScaleY(1.5f, 3f);
    }


}
