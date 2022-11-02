using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Trial : MonoBehaviour
{
    
        [SerializeField] private Transform _target = default;

        private Vector3 _initialPosition; 

        [SerializeField] private float _duration = 2;

        [SerializeField] private Ease _ease = Ease.Linear;

        private void Start()
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

        private void OnTriggerEnter(Collider other)
        {
            MoveToTarget();
        }

        private void Move(Vector3 position)
        {
            transform.DOMove(position, _duration)
                .SetEase(_ease)
                .OnComplete(() => Debug.Log("Position Reached"));
        }
    }

 



   