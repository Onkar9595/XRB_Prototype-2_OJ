using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject _buttonpress;
    [SerializeField] private GameObject _buttonBase;
    [SerializeField] private UnityEvent onPress;
    [SerializeField] private UnityEvent onRelease;
    private GameObject _presser;
    private bool isPressed;
    
    [SerializeField] private Renderer minimapscreen;
    [SerializeField] private Material _minimapenemy;
    [SerializeField] private Material _minimapwater;
    private bool watervisible;

    private Vector3 buttonOrignalPos;
    void Start()
    {
        isPressed = false;
        watervisible = false;
        buttonOrignalPos = _buttonpress.transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            _buttonpress.transform.localPosition = _buttonBase.transform.position;
            _presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _presser)
        {
            _buttonpress.transform.localPosition = buttonOrignalPos;
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void SwitchRadar()
    {
        if (watervisible)
        {
            minimapscreen.material = _minimapenemy;
            watervisible = false;
        }
        else 
        {
            minimapscreen.material = _minimapwater;
            watervisible = true;
        }
    }
}
