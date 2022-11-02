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
    [SerializeField] private float _duration = 0;

    [SerializeField] private Ease _ease = Ease.Linear;
    [SerializeField] private Canvas _welcomeCanvas;
    [SerializeField] private Canvas _OptionSelectCanvas;
    [SerializeField] private Renderer _elevatorDoorMaterial;
    [SerializeField] private Material _glassElevatorDoor;
    private bool elevatorCanMove;
    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        _OptionSelectCanvas.enabled = false;
        elevatorCanMove = false;
    }
    public void MoveToTarget()
    {
        Move(_target.position);
    }

    public void MoveBack()
    {
        Move(_initialPosition);
    }
    
    public void UIOptionCanvasActive()
    {
        _OptionSelectCanvas.enabled = true;
        Debug.Log("optioncanvasActivate");
        
    }
    
    public void UIOptionCanvasDeactivate()
    {
        _OptionSelectCanvas.enabled = false;
        Debug.Log("optioncanvasDeactivate");
        _elevatorDoorMaterial.material = _glassElevatorDoor;
    }
    
    
    private void Move(Vector3 position)
    { 
        transform.DOMove(position, _duration) 
            .SetEase(_ease) 
            .OnComplete(() => Debug.Log("Position Reached"));
    }

    private void OnTriggerEnter(Collider other)
    { 
      if(!other.CompareTag("Player")) return;
        Debug.Log("triggered"); 
        elevatorCanMove = true;
       //Invoke("UIWelcomeCanvasDeActivate", 2f);
        UIOptionCanvasActive(); 
        Invoke("UIOptionCanvasDeactivate", 10f);
        Invoke("MoveToTarget", 11f);
        //MoveToTarget();
    }

    // Update is called once per frame
    /*void Update()
    {
        if (elevatorCanMove)
        {
            MoveToTarget();
        }
    }
    */
}
