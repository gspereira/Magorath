using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class UICharacter : NetworkBehaviour {

    Link LN;

    public Slider HPSlider;
    public Slider StaminaSlider;
    public Slider SpecialSlider;
    public Slider Special2Slider;
    public Text SpecialSliderName;
    public Text Special2SliderName;
    public bool Setup = false;
    Character CHA;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);

        }
        LN = GameObject.Find("Linking Point").GetComponent<Link>();
        HPSlider = LN.HPSlider;
        StaminaSlider = LN.SPSlider;
        SpecialSlider = LN.SpecialSlider;
        SpecialSliderName = LN.SpecialSlider.GetComponentInChildren<Text>();
        Special2SliderName = LN.Special2Slider.GetComponentInChildren<Text>();
        Special2Slider = LN.Special2Slider;
        CHA = GetComponent<Character>();
        HPSlider.maxValue = CHA.MaxHP;
        StaminaSlider.maxValue = CHA.MaxStamina;
        SpecialSlider.maxValue = 100;
        

    }

    
	
	void Update () {

        if (StaminaSlider.maxValue != CHA.MaxStamina || HPSlider.maxValue != CHA.MaxHP) {
                StaminaSlider.maxValue = CHA.MaxStamina;
                HPSlider.maxValue = CHA.MaxHP;
            }

        SpecialSliderName.text = CHA.HabilityName;
        Special2SliderName.text = CHA.Hability2Name;
            HPSlider.value = CHA.HP;
            StaminaSlider.value = CHA.Stamina;
            SpecialSlider.value = CHA.HabilityCharge;
            Special2Slider.value = CHA.SecondaryCharge;
    }
}
