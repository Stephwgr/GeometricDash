using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float _speed;

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);

    }
    
}
