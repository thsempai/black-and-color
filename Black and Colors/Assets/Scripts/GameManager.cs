using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public GameObject heroPrefab;
    public int roomCount=0;


    public Material[] randomMaterials;
    public Material standardMaterial;
    private int currentLevelMaterialIndex = 0;
    private int nextLevelMaterialIndex=0;

    public Material currentLevelMaterial {
        get { return randomMaterials[currentLevelMaterialIndex]; }
    }

    public Material nextLevelMaterial {
        get { return randomMaterials[nextLevelMaterialIndex]; }
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
        if (heroPrefab == null)
            Debug.LogError("No hero prefab set in GameManager", gameObject);

        nextLevelMaterialIndex = Random.Range(0, randomMaterials.Length);
    }

    private void LoadLevel() {
        currentLevelMaterialIndex = nextLevelMaterialIndex;

        while (nextLevelMaterialIndex == currentLevelMaterialIndex)
            nextLevelMaterialIndex = Random.Range(0, randomMaterials.Length);
        SceneManager.LoadScene(0);
    }

    public void ChangeLevel() {
        roomCount++;
        LoadLevel();

    }

    public void Reset() {
        roomCount = 0;
        LoadLevel();
    }
}
