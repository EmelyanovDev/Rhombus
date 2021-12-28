using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public Vector2 _transformVector;

    private Vector3 _rotateSpeed = new Vector3(0,0,5);

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)_transformVector * Time.deltaTime;
        transform.Rotate(_rotateSpeed);
    }
}
