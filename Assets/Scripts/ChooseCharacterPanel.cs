using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ChooseCharacterPanel : MonoBehaviour {
    public GameObject StartingPanel;
    public GameObject HudPanel;
    [SerializeField]
    GameObject[] Spawners;

    public Character CHA;

    public GameObject MainCamera;
    public GameObject PlayerPrefab;
    [SerializeField]
    Slider HPSlider;
    [SerializeField]
    Slider SPSlider;
    [SerializeField]
    Slider SpecialSlider;

    int SlotChoosen;
    [SerializeField]
    NetworkInfo NI;

    Transform RandomSpawnPosition()
    {
        int R = Random.Range(0, 3);
        return Spawners[R].transform;
    }

   public  void LinkPanel(Character CHARA)
    {
        CHA = CHARA;

    }
    
    public void ChooseSlot(int I)
    {
        SlotChoosen = I;
    }

    public void SelectSlot(int Slot)
    {
        if (Slot == 0)
        {
            CHA.SelectSlotButton(0);
        }
        if (Slot == 1)
        {
            CHA.SelectSlotButton(1);
        }
        if (Slot == 2)
        {
            CHA.SelectSlotButton(2);
        }
        if (Slot == 3)
        {
            CHA.SelectSlotButton(3);
        }
    }

    public void BecomeReady()
    {
        CHA.BecomeReady();
    }

    private void Update()
    {
        if (NI.AllPlayersReady)
        {
            ChooseCharacter(SlotChoosen);
        }
    }

    void CmdChooseCharacter(Character CHARA,int I)
    {
        Transform RSP = RandomSpawnPosition();


        if (I == 0)
        {
            // Mage

            CHARA.MaxHP = 120;
            CHARA.HP = 120;
            CHARA.WalkingSpeed = 4;
            CHARA.SprintSpeed = 7;
            CHARA.BulletSpeed = 900;
            CHARA.AutomaticFire = true;
            CHARA.MaxStamina = 700;
            CHARA.Stamina = 400;
            CHARA.Damage = 15;
            CHARA.FireRate = 0.40f;
            CHARA.SpecialID = 0;
            CHARA.CmdSpecialSetup();
        }
        if (I == 1)
        {
            // Paladin

            CHARA.MaxHP = 300;
            CHARA.HP = 300;
            CHARA.WalkingSpeed = 3;
            CHARA.SprintSpeed = 8;
            CHARA.BulletSpeed = 0;
            CHARA.AutomaticFire = false;
            CHARA.MaxStamina = 250;
            CHARA.Stamina = 250;
            CHARA.Damage = 30;
            CHARA.FireRate = 0.60f;
            CHARA.SpecialID = 2;
            CHARA.FiringMode = 2;
            CHARA.CmdSpecialSetup();

        }
        if (I == 2)
        {
            // Druid

            CHARA.MaxHP = 200;
            CHARA.HP = 200;
            CHARA.WalkingSpeed = 4;
            CHARA.SprintSpeed = 6;
            CHARA.BulletSpeed = 1100;
            CHARA.AutomaticFire = true;
            CHARA.MaxStamina = 250;
            CHARA.Stamina = 250;
            CHARA.Damage = 15;
            CHARA.FireRate = 0.60f;
            CHARA.SpecialID = 1;
            CHARA.CmdSpecialSetup();
        }
        if (I == 3)
        {
            // Chronomage

            CHARA.MaxHP = 170;
            CHARA.HP = 170;
            CHARA.WalkingSpeed = 4;
            CHARA.SprintSpeed = 7;
            CHARA.BulletSpeed = 1100;
            CHARA.AutomaticFire = true;
            CHARA.MaxStamina = 700;
            CHARA.Stamina = 400;
            CHARA.Damage = 20;
            CHARA.FireRate = 0.50f;
            CHARA.SpecialID = 3;
            CHARA.CmdSpecialSetup();
        }

    }

    public void ChooseCharacter(int I)
    {
        StartingPanel.SetActive(false);
        HudPanel.SetActive(true);
        Transform RSP = RandomSpawnPosition();
        //GameObject CHA;
        //CHA = Instantiate(PlayerPrefab, RSP.position, RSP.rotation);
        //NetworkServer.Spawn(CHA);
        CHA.transform.position = RSP.position;
        CHA.transform.rotation = RSP.rotation;
        CmdChooseCharacter(CHA, I);
       
       
       



        //MainCamera.GetComponent<CameraFollow>().Target = CHA.transform;

        //if (isLocalPlayer)
        //{
        //    MainCamera.GetComponent<CameraFollow>().Target = CHA.transform;
        //    CHA.GetComponent<TestMouse>().PlayerCamera = MainCamera.GetComponent<Camera>();
        //    CHA.GetComponent<UICharacter>().HPSlider = HPSlider;
        //    CHA.GetComponent<UICharacter>().StaminaSlider = SPSlider;
        //    CHA.GetComponent<UICharacter>().SpecialSlider = SpecialSlider;

        //}
    }



}

