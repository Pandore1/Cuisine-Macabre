using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class SettingSlider : MonoBehaviour
{
    public delegate void SettingChange(Setting activeSetting, float newValue);
    public static SettingChange OnSettingChange;


    // Start is called before the first frame update
    [SerializeField] private TMPro.TMP_Text _settingTextValue;
    [SerializeField] private Slider _settingSlider;

    public enum Setting //liste des settings possibles
    {
        VOLUME
    }
    public Setting ActiveSetting = Setting.VOLUME; //le setting presentement en action

    void Start()
    {
        _settingSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat(ActiveSetting.ToString(), 1f));
      
    }
    public void onSliderChange(float newValue)
    {
        _settingTextValue.text = Mathf.Floor(newValue*100).ToString();
        //enregistre la nouvelle valeur du setting pour l'usage ultérieur
        PlayerPrefs.SetFloat(ActiveSetting.ToString(), newValue);

        //lancer l'évènement pour que quiconque ecoute, recoive la notification
        OnSettingChange?.Invoke(ActiveSetting, newValue);
    }
}
