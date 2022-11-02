using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class EleDoorOpenGF : MonoBehaviour
{
    [SerializeField] private GameObject Door;
    [SerializeField] private Transform _target;
    
    private Vector3 _initialPositionDoor; 
    
    [SerializeField] private Ease _ease = Ease.Linear;
    [SerializeField] private float _duration = 2;

    private bool _dooropen;

    [SerializeField] private Canvas _canvas;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.SetTweensCapacity(20000,5000);
        _initialPositionDoor = Door.transform.position;
        _canvas.enabled = false;
    }
    
    public void MoveToTargetDoor() 
    {
       Move(_target.position);
       _dooropen = true;
       Debug.Log("door is open");
    }

    public void MoveBackDoor()
    {
        Move(_initialPositionDoor);
        Debug.Log("door is closed");
    }

    private void Move(Vector3 position)
    {
        transform.DOMove(position, _duration)
            .SetEase(_ease)
            .OnComplete(() => Debug.Log("Position Reached"));
    }

    private void CanvasOpen()
    {
        _canvas.enabled = true;
    }

    private void CanvasClose()
    {
        _canvas.enabled = false;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;
       Invoke("MoveToTargetDoor", 2f);
       Invoke("MoveBackDoor", 8f);
       Invoke("CanvasOpen", 10f);
       Invoke("CanvasClose", 15f);
    }

  

    // Update is called once per frame
    void Update()
    {
        //if (!isPressed) return;
        
         //   MoveToTarget();
           // if (_dooropen)
           // {
            //    Invoke("MoveBack", 4);
           // }
        
    }
}
