using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevetorLowLevelEdits : MonoBehaviour
{
    [SerializeField] private GameObject _elevatorDoor;
    [SerializeField] private Renderer _elevatorDoorMaterial;
    [SerializeField] private Material _ElevatorDoorOrignalMaterial;
    
    [SerializeField] private GameObject _arrows;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("LowLevel")) return;
        _arrows.SetActive(false);
       // _elevatorDoorMaterial.material = _ElevatorDoorOrignalMaterial;
        //Invoke("ElevatorDoorOpen", 2f);
        ElevatorDoorOpen();
    }

    private void ElevatorDoorOpen()
    {
        _elevatorDoor.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
