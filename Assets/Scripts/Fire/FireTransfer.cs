using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FireTransfer : MonoBehaviour
{

    [SerializeField] private GameObject _fireprefab;
    [SerializeField] private Renderer minimapscreen;
    [SerializeField] private Material _minimapenemy;
    [SerializeField] private Material _minimapwater;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FireSource"))
        {
            _fireprefab.SetActive(true);
            minimapscreen.material = _minimapwater;

        }
        if (other.CompareTag("FireKill"))
        {
            _fireprefab.SetActive(false); 
            minimapscreen.material = _minimapenemy;
        }
    }
    void Start()
    {
        _fireprefab.SetActive(false);
        minimapscreen.material = _minimapenemy;
    }
}
