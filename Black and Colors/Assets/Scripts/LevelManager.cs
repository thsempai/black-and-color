using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public SpawnZone[] furnituresSpawns;
    public SpawnZone[] monstersSpawns;

    [Range(0, 100)]
    public int furnituresNumber=0;

    private int monstersNumber = 0;

    public Transform heroSpawn;
    public GameObject hero;

    public GameManager manager;

    private List<GameObject> Collect(SpawnZone [] spawns, int numberToSpawn) {
        List<GameObject> items = new List<GameObject>();

        for (int index = 0; index < spawns.Length; index++) {
            int number = numberToSpawn / spawns.Length;
            if (index < numberToSpawn % spawns.Length) {
                number++;
            }
            items.AddRange(spawns[index].SpawnSeveral(number));
        }
        return items;
    }

    private void Awake() {
        manager = FindObjectOfType<GameManager>();

        monstersNumber = manager.roomCount * 2;

        List<GameObject> furnitures = Collect(furnituresSpawns, furnituresNumber);
        List<GameObject> monsters = monsters = Collect(monstersSpawns, monstersNumber);

        int rnd = Random.Range(0, furnitures.Count);

        for(int index = 0; index < furnitures.Count; index++) {
            Material material =  manager.standardMaterial;

            FurnitureManager furnitureManager = furnitures[index].GetComponent<FurnitureManager>();

            if (rnd == index) {
                material = manager.nextLevelMaterial;
            }

            furnitureManager.ChangeMaterial(material);
            furnitureManager.gameManager = manager;
            furnitureManager.isDoor = rnd == index;
        }

        for (int index = 0; index < monsters.Count; index++) {
            monsters[index].GetComponent<Renderer>().material = manager.currentLevelMaterial;
            monsters[index].GetComponent<MonsterManager>().manager = this;
        }

            hero = Instantiate(manager.heroPrefab, heroSpawn.position, heroSpawn.rotation);

    }
}
