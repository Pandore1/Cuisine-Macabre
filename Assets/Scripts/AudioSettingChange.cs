using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioSettingChange : MonoBehaviour
{
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = PlayerPrefs.GetFloat(SettingSlider.Setting.VOLUME.ToString(), 1f);
        SettingSlider.OnSettingChange += OnSettingChange;

    }
    private void OnSettingChange(SettingSlider.Setting activeSetting, float newValue)
    {
        //valider si le setting recu correspond a ce que le script doit modifier

        if (activeSetting == SettingSlider.Setting.VOLUME)
        {
            //je modifie le volume
            _audioSource.volume = newValue;
            Debug.Log("audio : "+ _audioSource.volume + " newValue : " + newValue);

        }
    }
    private void OnDestroy()
    {
        //on veut se desinscrire des delegates  voulues (IMPORTANT)!
        SettingSlider.OnSettingChange -= OnSettingChange;

    }

}
