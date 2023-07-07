using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TileAdjuster : MonoBehaviour
{

    public Material initialMaterial;
    public Material transparentMaterial;

    public GameObject player;
    public List<MeshRenderer> wallsToDisappear = new List<MeshRenderer>();

    private void Awake()
    {
        if(wallsToDisappear.Count > 0)
        {
            initialMaterial = wallsToDisappear[0].material;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player.transform.position.z > this.transform.position.z)
            {
                TransparentizeTiles(true);
            }
            else
            {
                TransparentizeTiles(false);
            }
        }




    }

    private void TransparentizeTiles(bool toggle)
    {
        foreach(MeshRenderer wallRenderer in wallsToDisappear)
        {
            if (toggle == true)
            {
                wallRenderer.material = transparentMaterial;
            }
            else
            {
                wallRenderer.material = initialMaterial;
            }
        }
    }

}
