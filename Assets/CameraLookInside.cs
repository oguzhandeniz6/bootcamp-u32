using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraLookInside : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera cameraController;
     Transform initialFollow;
    [SerializeField] Transform targetFollow;
    [SerializeField] TileAdjuster tileAdjuster;

    private void Awake()
    {
        initialFollow = cameraController.Follow;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cameraController.Follow = targetFollow;
            tileAdjuster.TransparentizeTiles(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        cameraController.Follow = initialFollow;
        tileAdjuster.TransparentizeTiles(false);
    }
}
