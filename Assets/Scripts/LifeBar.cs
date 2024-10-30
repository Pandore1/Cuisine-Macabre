using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] private List<Image>  _life;
    public void LoseLife()
    {
        switch (GameManager.Instance.Life)  {
            case 3:
                _life[0].enabled = false; 
                break;
            case 2:
                _life[1].enabled = false; 
                break;
            case 1:
                _life[2].enabled = false;
                break;
            default:
                GameManager.Instance.Life = 0;
                break;



        
        }
        GameManager.Instance.Life--;
      
       
    }
        
        
     
    

}
