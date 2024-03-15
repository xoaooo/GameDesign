using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static VectorExtension;

public class BulletTrail : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private float _progress = 10f;
    [SerializeField] private float _speed = 40f;

    void Start()
    {
        _startPosition = transform.position.WithAxis(Axis.Z, -1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(_startPosition, _targetPosition, _progress);
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        _targetPosition = targetPosition.WithAxis(Axis.Z, -1);
    }
}
