using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterAnimations : MonoBehaviour
{
    [SerializeField] PlatesCounterManager plateCounter;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject plateVisualPrefab;

    List<GameObject> plateVisualGameObjectList;

    void Awake()
    {
        plateVisualGameObjectList = new List<GameObject>();    
    }

    void Start()
    {
        plateCounter.OnPlateSpawned += PlateCounter_OnPlateSpawned;
        plateCounter.OnPlateRemoved += PlateCounter_OnPlateRemoved;
    }

    private void PlateCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject plateGameObject = plateVisualGameObjectList[plateVisualGameObjectList.Count - 1];
        plateVisualGameObjectList.Remove(plateGameObject);
        Destroy(plateGameObject);
    }

    private void PlateCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateVisualPrefab.transform, spawnPoint.transform);

        float plateOffsetY = 0.1f;
        plateVisualTransform.localPosition = new Vector3(0, plateOffsetY * plateVisualGameObjectList.Count, 0);

        plateVisualGameObjectList.Add(plateVisualTransform.gameObject);
    }
}
