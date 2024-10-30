using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCooking : MonoBehaviour
{
    public static int _cupcakeNbPref;

    [SerializeField] private GameObject _endCookingWindow;
    // Update is called once per frame
   
    public void openEndCookingWindow()
    {
        _cupcakeNbPref = GameManager.Instance.CakeMade;
        _endCookingWindow.SetActive(true);
        PlayerPrefs.SetInt("cupcakeNb", _cupcakeNbPref);
    }
    public void closeEndCookingWindow()
    {
        _endCookingWindow.SetActive(false);
    }
}
