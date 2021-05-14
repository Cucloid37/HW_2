using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _Enemy;
    int count;

    private void Start()
    {
        InvokeRepeating("Spowner", 2.0f, 2.0f);
    }

    private void Update()
    {
        

    }

    private void Spowner()
    {
        Vector3 there = transform.position;
        Instantiate(_Enemy, there, Quaternion.identity);
        count++;
        Debug.Log($"Oh, no! It's {count} enemy! Only {Time.deltaTime} second passed");
    }
}
