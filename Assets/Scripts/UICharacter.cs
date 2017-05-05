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
    public Text SpecialSliderName;
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
        

            HPSlider.value = CHA.HP;
            StaminaSlider.value = CHA.Stamina;
            SpecialSlider.value = CHA.HabilityCharge;
	}
}
