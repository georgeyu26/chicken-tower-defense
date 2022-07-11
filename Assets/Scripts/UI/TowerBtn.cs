using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;

    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private int cost;

    public int Cost{
        get{
            return cost;
        }
    }
    
    public GameObject TowerPrefab{
        get{
            return towerPrefab;
        }
    }

    public Sprite Sprite {
        get {
            return sprite;
        }
    }
}
