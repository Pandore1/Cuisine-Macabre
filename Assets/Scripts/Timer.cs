using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float TimeAllowed = 180f;
     private float _timeLeft = 0f;
    
    public TMPro.TMP_Text TimerTime; //Texte du timer montera le texte restant

    // Start is called before the first frame update
    void Start()
    {
        _timeLeft = TimeAllowed;//temps restant = temps permis au depart
    }

    // Update is called once per frame
    void Update()
    {
        _timeLeft -= Time.deltaTime;
        if (_timeLeft > 0)
        {
            UpdateTimerText();

        }
        else if (_timeLeft <= 0) //Quand le temps arrive a 0 la variable du GameManager change pour  afficher la fenetre
        {
            GameManager.Instance.EndCookingScript.openEndCookingWindow();
        }
    }
     private void UpdateTimerText()
    {
        // Convertir le temps restant en minutes et secondes
        int minutes = Mathf.FloorToInt(_timeLeft/ 60);
        int seconds = Mathf.FloorToInt(_timeLeft % 60);

        // Mettre à jour le texte d'affichage
        TimerTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);//Afficher selon le format minute seconde
    }
}
