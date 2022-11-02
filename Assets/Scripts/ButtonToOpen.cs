using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonToOpen : MonoBehaviour
{
    [SerializeField] private GameObject _buttonpress;
    [SerializeField] private GameObject _buttonBase;
    [SerializeField] private UnityEvent onPress;
    
    private GameObject _presser;
    public bool isPressed;
    private Vector3 buttonOrignalPos;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
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
            Debug.Log("Button is pressed and bool is true");
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
