using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFruitsInBlender : MonoBehaviour
{
    private List<GameObject> _fruitsInBlender;
    private void Start()
    {
        _fruitsInBlender = new List<GameObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _fruitsInBlender.Add(other.gameObject);
    }

    public void deleteFruits()
    {
        for(int i = 0; i < _fruitsInBlender.Count; i ++)
        {
            Destroy(_fruitsInBlender[i].gameObject);
        }
    }
}
