using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _pointA, _pointB;
    private Transform _target;
    [SerializeField] private float _speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _target = _pointB;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * _speed);

        if (transform.position == _pointA.position)
        {
            _target = _pointB;
        } else if(transform.position == _pointB.position)
        {
            _target = _pointA;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            other.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }

}
