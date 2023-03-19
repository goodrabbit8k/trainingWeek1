using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStaticDataManager : MonoBehaviour
{
    void Awake()
    {
        CuttingCounterManager.ResetStaticData();    
        BaseCounter.ResetStaticData();
        TrashCounterManager.ResetStaticData();
    }
}
