using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;


public class Cooking : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<Image> _tools;
    [SerializeField] private TMPro.TMP_Text TimeNeedText;
 


    private KeyCode _correctTool = KeyCode.None;
    private KeyCode _pressedKey = KeyCode.None;
    private float _timeNeeded;

    //Action du personnage
  
   

    private float _elapsedTime = 0f;
    private float _startTime = 0f;


    void Start()
    {

        Debug.Log("Cupcake" + GameManager.Instance.CakeMade);

        _tools[0].gameObject.SetActive(true);
        _correctTool = KeyCode.DownArrow;
        _timeNeeded = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) //Vérifier si n'importe quelle touche a été pressé
        {

            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                // Check if the current KeyCode is pressed
                if (Input.GetKeyDown(keyCode))
                {
                    // Print the KeyCode of the pressed key
                    // Debug.Log("Key pressed: " + keyCode);
                    _pressedKey = keyCode;
                    break; // Exit the loop since we found the pressed key
                }
            }
       
            if (_pressedKey != _correctTool)
            {
                GameObject heroCookScript = GameObject.Find("HeroCook");
                HeroCooking scriptHeroCook = heroCookScript.GetComponent<HeroCooking>();
                if (scriptHeroCook != null)
                {
                    scriptHeroCook.Mistake();
                }
            }
            _pressedKey = KeyCode.None;
        }
        if (Input.GetKeyDown(_correctTool))
        {
            _startTime = Time.time;
        }
        else if (Input.GetKeyUp(_correctTool))
        {
            _elapsedTime = Mathf.Round(Time.time - _startTime);
            if (CanIFinishStep(_timeNeeded))
            {
                FinishStep();
            }
        }
    }

    public void StepCooking() //Choisir une étape random ainsi que le temps nécessaire à faire
    {
        _tools.ForEach(tool =>
        {
            tool.gameObject.SetActive(false);

        });
        int randomTime = Random.Range(1, 3);
       // int randomStepIndex = 1;
         int randomStepIndex = Random.Range(1, 200);
        if(randomStepIndex%2 == 0) {
            _tools[1].gameObject.SetActive(true);
            _correctTool = KeyCode.UpArrow;
        }
        else
        {
            _tools[2].gameObject.SetActive(true);
            _correctTool = KeyCode.Space;
        }
        _timeNeeded = randomTime;
        TimeNeedText.text = _timeNeeded.ToString();
    }

    private bool CanIFinishStep(float timeNeeded)
    {
        return _elapsedTime >= timeNeeded;
    }

    private void FinishStep()
    {
        _elapsedTime = 0;
        _startTime = 0;
        GameManager.Instance.StepBarScript.SucceedStep();
        StepCooking();
    }

 

  
}
