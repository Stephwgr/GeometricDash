using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _dirPlayer;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Move();
        Jump();
    }

    public void Move()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);

    }

    public void Jump() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode.Impulse);
        }    

    }
}
