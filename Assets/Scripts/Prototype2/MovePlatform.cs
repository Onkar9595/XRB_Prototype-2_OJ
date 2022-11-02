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
    [SerializeField] private Canvas _welcomeCanvas;
    [SerializeField] private Canvas _OptionSelectCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        _OptionSelectCanvas.enabled = false;
    }
    public void MoveToTarget()
    {
        Move(_target.position);
    }

    public void MoveBack()
    {
        Move(_initialPosition);
    }

    public void UIWelcomeCanvasDeActivate()
    {
        _welcomeCanvas.enabled = false;
    }
    
    public void UIOptionCanvasActive()
    {
        _OptionSelectCanvas.enabled = true;
    }
    
    public void UIOptionCanvasDeactivate()
    {
        _OptionSelectCanvas.enabled = false;
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
       // Invoke("UIWelcomeCanvasDeActivate", 2f);
        Invoke("UIOptionCanvasActive", 3f);
        Invoke("UIOptionCanvasDeactivate", 8f);
        Invoke("MoveToTarget", 9f);
    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("MoveToTarget", 2f);
    }
}
