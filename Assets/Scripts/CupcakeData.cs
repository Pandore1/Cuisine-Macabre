using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupcakeData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.CakeMade = PlayerPrefs.GetInt("cupcakeNb");
        Debug.Log("Player pref cupcakee" + GameManager.Instance.CakeMade);

    }
  
   
}
