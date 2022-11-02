using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private Transform _target = default;

    private Vector3 _initialPosition;
    private Renderer _basecolor;
    [SerializeField] private float _duration = 2;

    [SerializeField] private Ease _ease = Ease.Linear;
    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
    }
    public void MoveToTarget()
    {
        Move(_target.position);
    }

    public void MoveBack()
    {
        Move(_initialPosition);
    }

    private void Move(Vector3 position)
    {
        transform.DOMove(position, _duration)
            .SetEase(_ease)
            .OnComplete(() => Debug.Log("Position Reached"));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
            MoveToTarget();
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("MoveToTarget", 2f);
    }
}
