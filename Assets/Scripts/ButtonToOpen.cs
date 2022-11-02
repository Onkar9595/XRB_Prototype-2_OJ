using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonToOpen : EleDoorOpenGF
{
    [SerializeField] private GameObject _buttonpress;
    [SerializeField] private GameObject _buttonBase;

    private GameObject _presser;
    public bool isPressed= false;
    private Vector3 buttonOrignalPos;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        buttonOrignalPos = _buttonpress.transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!isPressed)
        {
            _buttonpress.transform.localPosition = _buttonBase.transform.position;
            _presser = other.gameObject;
            isPressed = true;
            Debug.Log("Button is pressed and bool is true");
            MoveToTarget();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
