using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    public GameManager gameManager;
    private bool _isDoor = false;
    public bool isDoor {
        get { return _isDoor; }
        set { _isDoor = value;
            if (light && material) {
                light.enabled = _isDoor;
                if (_isDoor)
                    light.color = material.color;
            }
        }
    }

    private Light light;
    private Material material;

    public void ChangeMaterial(Material material) {
        this.material = material;
        for(int index=0; index < transform.childCount; index++) {
            Renderer renderer = transform.GetChild(index).GetComponent<Renderer>();
            if(renderer)
                renderer.material = material;

            light = transform.GetChild(index).GetComponent<Light>();

        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" && isDoor)
            gameManager.ChangeLevel();
    }
    
    
}
