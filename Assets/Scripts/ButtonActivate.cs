using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivate : MonoBehaviour {

    Button BTN;
    [SerializeField]
    int Slot;

    [SerializeField]
    NetworkInfo NIP;

    [SerializeField]
    ChooseCharacterPanel CCP;

    private void Start()
    {
        BTN = GetComponent<Button>();
        BTN.onClick.AddListener(SelectSlot);
    }

    private void Update()
    {
        BTN.interactable = NetworkInfo.NI.ClassesInUse[Slot];
    }

    private void SelectSlot()
    {
        CCP.SelectSlot(Slot);
    }

}
