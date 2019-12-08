using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 _point_A, _point_B;
    [Range(-50.0f, 0)]
    public float toLeft;
    [Range(0, 50.0f)]
    public float toRight;
    [Range(0, 30.0f)]
    public float speed = 10.0f;
    private bool _switching = false;
    void Start()
    {
        _point_A = transform.position + new Vector3(toLeft, 0, 0);
        _point_B = transform.position + new Vector3(toRight, 0, 0);
    }

    void FixedUpdate()
    {
        if (!_switching)
        {
            transform.position = Vector3.MoveTowards(transform.position, _point_B, speed * Time.deltaTime);
        }
        else if (_switching)
        {
            transform.position = Vector3.MoveTowards(transform.position, _point_A, speed * Time.deltaTime);
        }

        if (transform.position == _point_B)
        {
            Debug.Log("B");
            _switching = true;
        }
        else if (transform.position == _point_A)
        {
            Debug.Log("A");
            _switching = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Collider ends");
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
