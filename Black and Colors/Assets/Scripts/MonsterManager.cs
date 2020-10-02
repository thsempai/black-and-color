using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterManager : MonoBehaviour
{
    public LevelManager manager;
    NavMeshAgent agent;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        agent.destination = manager.hero.transform.position;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            manager.manager.Reset();
        }
    }
}
