using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDPanel : MonoBehaviour {

    [SerializeField]
    Slider[] Sliders;
    Text[] Texts;

    [SerializeField]
    ChooseCharacterPanel CCP;
	// Use this for initialization
	void Start () {
        Texts = GetComponentsInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        Sliders[0].value = CCP.CHA.HP;
        Sliders[0].maxValue = CCP.CHA.MaxHP;
        Sliders[1].value = CCP.CHA.Stamina;
        Sliders[1].maxValue = CCP.CHA.MaxStamina;
        Sliders[2].value = CCP.CHA.HabilityCharge;
        Sliders[2].maxValue = 100;
        Sliders[3].value = CCP.CHA.SecondaryCharge;
        Sliders[3].maxValue = 100;
        Texts[0].text = "HP";
        Texts[1].text = "Stamina";
        Texts[2].text = CCP.CHA.HabilityName;
        Texts[3].text = CCP.CHA.Hability2Name;
    }
}
