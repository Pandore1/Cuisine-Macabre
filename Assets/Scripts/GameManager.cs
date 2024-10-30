using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
   
    [Header("Différent scripts d'élément")]
    public Timer TimerScripts;
    public SceneSwitcher SceneSwitcher;
    public LifeBar LifeScript;
    public StepBarPanel StepBarScript;
    public EndCooking EndCookingScript;
    [Header("Phase de cuisine")]
    public float CurrentStep = 1f;
    public float CompleteStep = 5f;
    public int CakeMade=0;
    public TMPro.TMP_Text CakeValue;
    [Header("Phase d'attaque de zombie")]
    public int ZombieLeft = 6; //nombre de zombie restant
    public int Life = 3;
    public enum GameState
    {
        INPLAY, LOST, WON
    }
    [Header ("Game")]
    public GameState State = GameState.INPLAY;
    // Start is called before the first frame update
    private void Awake()
    {   
        //on crée l'instance du singleton si elle n'existe pas déja
        if (Instance != null && Instance != this)
        {
            //sinon on la detryut
            Destroy(this);
           
        }

        Instance = this;//affectation de l'instance
    }
    private void Start()
    {
        if (LifeScript != null)
        {
            Life = 3;
        }
    }
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (CakeValue != null)
        {
            CakeValue.text = CakeMade.ToString();
        }

        if (scene.name == "Attacking")
        {
            //Voir si gagner en jeu ou perdu
            if ((CakeMade <= 0 && ZombieLeft != 0) || Life==0)
            {
                State = GameState.LOST;
                GameOver(State);
            }
            else if (ZombieLeft == 0)
            {
                State = GameState.WON;
                GameOver(State);
            }
            else
            {
                State = GameState.INPLAY;
            }
        }
    }

    public void GameOver(GameState newGameState)
    {
        State= newGameState;
        if (State == GameState.WON)
        {
            SceneSwitcher.SwitchScene("Win");
        }
        else if(State == GameState.LOST) {
            SceneSwitcher.SwitchScene("Lost");

        }
    }

   
}
