using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _targetA, _targetB;
    [SerializeField] private Vector3 _pointA;
    [SerializeField] private Vector3 _pointB;
    [SerializeField] private float _speed = 5f;
    private Vector3 _target;
    private Vector3 _position;
    // Start is called before the first frame update
    void Start()
    {
        _pointA = _targetA.position;
        _pointB = _targetB.position;
        transform.position = _pointA;
        _position = transform.position;
        _target = _pointB;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _position = transform.position;
        
        transform.position = Vector3.MoveTowards(_position, _target, Time.deltaTime * _speed);
        if (_position == _pointA) 
        {
            _target = _pointB;
        }
        else if (_position == _pointB) 
        {
            _target = _pointA;
        }

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player") 
        {
            Debug.Log("Player detected!");
            other.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
