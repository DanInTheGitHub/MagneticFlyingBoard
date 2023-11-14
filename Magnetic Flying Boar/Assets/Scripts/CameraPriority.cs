using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPriority : MonoBehaviour
{
    private CinemachineClearShot clearShot;
    private CinemachineVirtualCameraBase[] virtualChilds;

    void Start()
    {
        clearShot = GetComponent<CinemachineClearShot>();
        virtualChilds = clearShot.ChildCameras;
    }

    void Update()
    {
        
    }

    public void ChangeCameraPriority(int camera)
    {
        foreach (var child in virtualChilds)
            child.Priority = 9;

        virtualChilds[camera].Priority = 10;        
    }
}
