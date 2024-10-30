using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Barre indicatrice d'étape
/// </summary>
public class StepBarPanel : MonoBehaviour
{
    [SerializeField] private RectTransform _stepBar;
    [SerializeField] private  TMPro.TMP_Text StepText; //Texte du timer montera le texte restant

    
   
   

    // Update is called once per frame
    void Update()
    {
        StepText.text = (GameManager.Instance.CurrentStep.ToString());


    }
    public void SucceedStep()
    {
        GameManager.Instance.CurrentStep += 1;


        if (GameManager.Instance.CurrentStep == GameManager.Instance.CompleteStep)
        {
            GameManager.Instance.CakeMade += 1;
            Debug.Log(GameManager.Instance.CakeMade);

            GameManager.Instance.CurrentStep =0;
        }
        _stepBar.sizeDelta = new Vector2((GameManager.Instance.CurrentStep / GameManager.Instance.CompleteStep) * GetComponent<RectTransform>().rect.width, _stepBar.sizeDelta.y);


    }
}
