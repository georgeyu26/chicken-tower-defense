using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private bool showShop;

    [SerializeField]
    private GameObject shopPanel;

    // Start is called before the first frame update
    void Start()
    {
        showShop = false;
        shopPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Toggle(){
        showShop = !showShop;
        shopPanel.SetActive(showShop);
    }

    public void DeactivateShop(){
        showShop = false;
        shopPanel.SetActive(false);
    }
}
