using UnityEngine;

public class fruitColor : MonoBehaviour
{
    public Color fruitColors;
    public Vector3 startPosition { get; private set; }

    private void Start()
    {
        startPosition = this.gameObject.transform.position;
    }

}
