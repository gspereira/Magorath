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

        int Buff = 1;

        if(I == NetworkInfo.NI.BossNumber)
        {
            I += 4;
        }

        if (I == 0)
        {
            // Mage
            // Time do personagem
            CHARA.Team = 0;
            // Hp maximo do personagem,o limite que ele pode ser healado
            CHARA.MaxHP = 120;
            // HP inicial do personagem
            CHARA.HP = 120;
            // Velocidade andando
            CHARA.WalkingSpeed = 4;
            // Velocidade correndo
            CHARA.SprintSpeed = 7;
            // Velocidade dos projeteis
            CHARA.BulletSpeed = 900;
            // Se ele pode segurar pra atirar
            CHARA.AutomaticFire = true;
            // Stamina limite
            CHARA.MaxStamina = 700;
            // Stamina inicial
            CHARA.Stamina = 400;
            // Dano do ataque principal
            CHARA.Damage = 15;
            // O tempo em segundos que ele espera entre tiros
            CHARA.FireRate = 0.40f;
            // ID do special(nao deveria mecher muito com excesao do boss
            CHARA.SpecialID = 0;
            // Setup das informaçoes de tela
            CHARA.CmdSpecialSetup();
        }
        if (I == 1)
        {
            // Paladin
            CHARA.Team = 0;
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
            CHARA.Team = 0;
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
            CHARA.Team = 0;
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
        if (I == 4)
        {
            // Boss Mage
            // Logan configura aqui
            CHARA.Team = 1;
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
            CHARA.SpecialID = 4;
            CHARA.CmdSpecialSetup();
        }
        if (I == 5)
        {
            // Boss Paladino
            // Logan configura aqui
            CHARA.Team = 1;
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
            CHARA.SpecialID = 5;
            CHARA.CmdSpecialSetup();
        }
        if (I == 6)
        {
            // Boss Druida
            // Logan configura aqui
            CHARA.Team = 1;
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
            CHARA.SpecialID = 6;
            CHARA.CmdSpecialSetup();
        }
        if (I == 7)
        {
            // Boss ChronoMage
            // Logan configura aqui
            CHARA.Team = 1;
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
            CHARA.SpecialID = 7;
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

