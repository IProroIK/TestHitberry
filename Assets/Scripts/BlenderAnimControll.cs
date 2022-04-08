using System.Collections;
using UnityEngine;
using DG.Tweening;

public class BlenderAnimControll : MonoBehaviour
{
    private Transform _blender;
    private Transform _blenderLid;
    private int _layerMask;

    private void Start()
    {
        _blender = GetComponent<Transform>();
        _blenderLid = _blender.GetChild(0).GetChild(1).GetComponent<Transform>();
        _layerMask = 1 << 6;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 15f, _layerMask))
            {
                shakeBlender();
            }
        }
    }
    private void shakeBlender()
    {
        StartCoroutine(lidOpenClose());
    }

    IEnumerator lidOpenClose()
    {
        if (!DOTween.IsTweening(_blenderLid))
        {
            _blenderLid.DOMoveX(0.7f, 0.2f, false);
            yield return new WaitForSeconds(0.5f);
            _blenderLid.DOMoveX(0f, 0.2f, false);
            yield return new WaitForSeconds(0.2f);
            _blender.DOShakePosition(1.5f, new Vector3(-0.005f, 0, 0), 30, 0, false, false);
        }

    }

}
