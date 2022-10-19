using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Protected means that thge variable is PRIVATE but can also allow inheretance for CHILD. Otherwise you'd have to make it public.
    [SerializeField] protected Vector3 _startPosition;
    [SerializeField] protected Vector3 _endPosition;
    [SerializeField] protected float _speed;
    [Range( 0f, 1f)]

    [SerializeField] protected float _t;
    protected bool _forward = true;
    [SerializeField] protected float _pauseTime = 0.5f;
    protected float _startPauseTime = float.MinValue;

    private void Update()
    {

        if(Time.time < _startPauseTime + _pauseTime) // If the current time (Time.time) is less than (current time + pause time (0.5f) return (nothing?)
        {
            return;
        }

        if (_forward)
        {
            _t += _speed * Time.deltaTime;
            _t = Mathf.Min(1, _t); // This sets a minimum value, if _t becomes greater than 1, it resets to 1 which essentially caps the speed
            if (_t >= 1)
            {
                _startPauseTime = Time.time; // This is our Pause at the moment it hits its last spot
                _forward = false;
            }
        }
        else
        {
            _t -= _speed * Time.deltaTime;
            _t = Mathf.Max(0, _t);  // opposite to MIN, this sets a max value.
            if (_t <= 0)
            {
                _startPauseTime = Time.time;
                _forward = true;
            }
        }



        transform.position = NextMove(_t);
    }

    protected virtual Vector3 NextMove(float t)
    {
        return Vector3.Lerp(_startPosition, _endPosition, t);
    }




}
