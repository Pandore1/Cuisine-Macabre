using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{

    public static ApplicationManager Instance;
    [SerializeField] private KeyCode _quitKey = KeyCode.Escape;//touche escape par défaut mais peut modifier

    [SerializeField] private GameObject _settingWindow;
    // Start is called before the first frame update
    private void Awake()
    {
        Screen.fullScreen = true;
        //on crée l'instance du singleton si elle n'existe pas déja
        if (Instance != null && Instance != this)
        {
            //sinon on la detryut
            Destroy(this);
            return;
        }
        Instance = this;//affectation de l'instance
        //on veut rester activé dans toutes les scènes
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyUp(_quitKey)) //si la touches escape est enfoncé, appeler la fonction pour 
        {
            Quit();
        }
    }
    public void openSettingWindow()
    {   
        _settingWindow.SetActive(true);
    }
    public void closeSettingWindow()
    {
        _settingWindow.SetActive(false);
    }
    public void Quit()
    {
        //utilisation des compilations dynamique
#if UNITY_EDITOR
        //on arrete le mode play de l'éditeur
        EditorApplication.isPlaying = false;
#else

        //on quitte le build

        Application.Quit();
#endif
    }
}
