using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backToTable : MonoBehaviour
{
    private fruitColor _fruitColor;
    private void OnTriggerEnter(Collider other)
    {
        _fruitColor = other.GetComponent<fruitColor>();
        other.transform.position = _fruitColor.startPosition;
    }
}
