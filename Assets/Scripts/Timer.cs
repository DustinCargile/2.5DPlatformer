using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    private float _duration;
    public float Duration { get { return _duration; } set { _duration = value; } }

    private float _clock = 0;
    public float Clock { get { return _clock; } }
    
    private bool _running = false;
    public bool Running { get { return _running; } }

    private bool _done = false;
    public bool Done { get { return _done; } }

    public Timer(float duration) 
    {
        _duration = duration;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_running) 
        {
            _clock += Time.deltaTime;
        }
        if (_clock >= _duration) 
        {
            _done = true;
            _running = false;
        }
    }

}
