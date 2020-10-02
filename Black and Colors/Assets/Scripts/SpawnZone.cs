using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [Range(0f, 10f)]
    public float radius = 0f;

    public GameObject[] prefabs;

    private void Awake() {
        if(prefabs.Length == 0) {
            Debug.LogError("No prefabs in the SpawnZone '" + name + "'.", gameObject);
        }
    }

    public GameObject Spawn() {
        Vector3 position = Random.insideUnitSphere * radius;
        position.y = 0;
        position += transform.position;

        int index = Random.Range(0, prefabs.Length);
        GameObject newItem = Instantiate(prefabs[index], position, Quaternion.identity);
        return newItem;
    }

    public List<GameObject> SpawnSeveral(int number) {
        List<GameObject> items = new List<GameObject>();
        for (int n=0; n < number; n++) {
            items.Add(Spawn());
        }
        return items;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1f, 0f, 0f, 0.25f);
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
