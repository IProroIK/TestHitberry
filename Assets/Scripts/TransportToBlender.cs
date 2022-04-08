using UnityEngine;
using DG.Tweening;

public class TransportToBlender : MonoBehaviour
{
    [SerializeField] private Transform _topOfTheBlenderPos;
    [SerializeField] private MeshRenderer _smozieColor;
    private fruitColor _fruitColor;
    private Rigidbody _rigidbody;
    private float _totalRed;
    private float _totalGreen;
    private float _totalBlue;
    private int _totalFruitsInBlend;
    private int _layerMask;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _totalFruitsInBlend = 0;
        _layerMask = 1 << LayerMask.NameToLayer("Fruits");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            getFruitsToBlender();
        }
    }

    private void getFruitsToBlender()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 15f , _layerMask))
        {
            Instantiate(hit.transform.gameObject);
            _fruitColor = hit.transform.GetComponent<fruitColor>();
            _totalRed += _fruitColor.fruitColors.r;
            _totalGreen += _fruitColor.fruitColors.g;
            _totalBlue += _fruitColor.fruitColors.b;
            _totalFruitsInBlend += 1;
            if (!DOTween.IsTweening(_rigidbody))
            {
                hit.rigidbody.DOJump(_topOfTheBlenderPos.position, 1f, 1, 0.5f, false);
            }
        }
    }

    private Color AverageColour(int numColours, float red, float green, float blue)
    {
       return new Color(red / numColours, green / numColours, blue / numColours);
    }
    public void ColorChange()
    {
            _smozieColor.material.color = AverageColour(_totalFruitsInBlend, _totalRed, _totalGreen, _totalBlue);
    }

    public void DeleteScript()
    {
        Destroy(this);
    }
}
