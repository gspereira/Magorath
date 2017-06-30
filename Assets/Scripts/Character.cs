using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Character : NetworkBehaviour {

    TopDownController TDC;
    ChooseCharacterPanel CCP;
    Link LN;


    public GameObject[] ProjectilePrefabs;


    public Transform GunPosition;

    [SyncVar]
    public int CharacterStatus = 0;

    public bool CharacterReady = false;
    [SyncVar]
    public bool PlayerReady = false;


    // Movement Information
    [SyncVar]
    public float SprintSpeed;
    [SyncVar]
    public float WalkingSpeed;

    [SyncVar]
    public int Team;

    // Vital Information
    [SyncVar]
    public int HP;
    [SyncVar]
    public int MaxHP;
    [SyncVar]
    public int Stamina;
    [SyncVar]
    public int MaxStamina;

    // Gun Information
    [SyncVar]
    public float FireRate;
    [SyncVar]
    public float ClipSize;
    [SyncVar]
    public float ReloadTime;
    [SyncVar]
    public float Damage;
    [SyncVar]
    public float BulletSpeed;
    [SyncVar]
    public bool AutomaticFire;
    [SyncVar]
    public int FiringMode = 0;
    [SyncVar]
    private float FiringCooldown;
    [SyncVar]
    public int SpecialID;
    public string HabilityName;
    public string Hability2Name;
    [SyncVar]
    public float HabilityCharge;
    [SyncVar]
    public float SecondaryCharge;
    [SyncVar]
    public float HabilityChargingSpeed;
    [SyncVar]
    public float SecondaryChargingSpeed;
    [SyncVar]
    public float Invincible;
    [SyncVar]
    public float BuffSpeed;
    public bool Local;

    [SyncVar]
    public bool Dead;
    [SyncVar]
    public bool Boss;

    [SerializeField]
    GameObject DeadPanelPlayer;

    private void Start()
    {
        LN = GameObject.Find("Linking Point").GetComponent<Link>();
        TDC = GetComponent<TopDownController>();
        CCP = GameObject.Find("Choose Character").GetComponent<ChooseCharacterPanel>();
    }

    private void OnEnable()
    {
        NetworkInfo.NI.CmdConnected();
        DeadPanelPlayer = GameObject.Find("Dead Canvas");
        DeadPanelPlayer.SetActive(false);
    }

    public void BecomeReady()
    {
        CmdBecomeReady();
    }

    private void Awake()
    {
        DeadPanelPlayer = GameObject.Find("Dead Canvas");

    }

    [Command]
    public void CmdBecomeReady()
    {
        //CharacterStatus = 1;
        if (!PlayerReady)
        {
            NetworkInfo.NI.PlayersReady++;
            PlayerReady = true;
        }
    }
    [Command]
    public void CmdChooseCharacter(int I)
    {
        if (I == NetworkInfo.NI.BossNumber)
        {
            I += 4;
        }

        if (I == 0)
        {
            // Mage
            // Time do personagem
            Team = 0;
            // Hp maximo do personagem,o limite que ele pode ser healado
            MaxHP = 120;
            // HP inicial do personagem
            HP = 120;
            // Velocidade andando
            WalkingSpeed = 4;
            // Velocidade correndo
            SprintSpeed = 7;
            // Velocidade dos projeteis
            BulletSpeed = 900;
            // Se ele pode segurar pra atirar
            AutomaticFire = true;
            // Stamina limite
            MaxStamina = 700;
            // Stamina inicial
            Stamina = 400;
            // Dano do ataque principal
            Damage = 15;
            // O tempo em segundos que ele espera entre tiros
            FireRate = 0.40f;
            // ID do special(nao deveria mecher muito com excesao do boss
            SpecialID = 0;
            // Setup das informaçoes de tela
            CmdSpecialSetup();
        }
        if (I == 1)
        {
            // Paladin
            Team = 0;
            MaxHP = 300;
            HP = 300;
            WalkingSpeed = 3;
            SprintSpeed = 8;
            BulletSpeed = 0;
            AutomaticFire = false;
            MaxStamina = 250;
            Stamina = 250;
            Damage = 30;
            FireRate = 0.60f;
            SpecialID = 2;
            FiringMode = 2;
            CmdSpecialSetup();

        }
        if (I == 2)
        {
            // Druid
            Team = 0;
            MaxHP = 200;
            HP = 200;
            WalkingSpeed = 4;
            SprintSpeed = 6;
            BulletSpeed = 1100;
            AutomaticFire = true;
            MaxStamina = 250;
            Stamina = 250;
            Damage = 15;
            FireRate = 0.60f;
            SpecialID = 1;
            CmdSpecialSetup();
        }
        if (I == 3)
        {
            // Chronomage
            Team = 0;
            MaxHP = 170;
            HP = 170;
            WalkingSpeed = 4;
            SprintSpeed = 7;
            BulletSpeed = 1100;
            AutomaticFire = true;
            MaxStamina = 700;
            Stamina = 400;
            Damage = 20;
            FireRate = 0.50f;
            SpecialID = 3;
            CmdSpecialSetup();
        }
        if (I == 4)
        {
            // Boss Mage
            // Logan configura aqui
            Team = 1;
            MaxHP = 170;
            HP = 170;
            WalkingSpeed = 4;
            SprintSpeed = 7;
            BulletSpeed = 1100;
            AutomaticFire = true;
            MaxStamina = 700;
            Stamina = 400;
            Damage = 20;
            FireRate = 0.50f;
            SpecialID = 4;
            CmdSpecialSetup();
        }
        if (I == 5)
        {
            // Boss Paladino
            // Logan configura aqui
            Team = 1;
            MaxHP = 170;
            HP = 170;
            WalkingSpeed = 4;
            SprintSpeed = 7;
            BulletSpeed = 1100;
            AutomaticFire = true;
            MaxStamina = 700;
            Stamina = 400;
            Damage = 20;
            FireRate = 0.50f;
            SpecialID = 5;
            CmdSpecialSetup();
        }
        if (I == 6)
        {
            // Boss Druida
            // Logan configura aqui
            Team = 1;
            MaxHP = 170;
            HP = 170;
            WalkingSpeed = 4;
            SprintSpeed = 7;
            BulletSpeed = 1100;
            AutomaticFire = true;
            MaxStamina = 700;
            Stamina = 400;
            Damage = 20;
            FireRate = 0.50f;
            SpecialID = 6;
            CmdSpecialSetup();
        }
        if (I == 7)
        {
            // Boss ChronoMage
            // Logan configura aqui
            Team = 1;
            MaxHP = 170;
            HP = 170;
            WalkingSpeed = 4;
            SprintSpeed = 7;
            BulletSpeed = 1100;
            AutomaticFire = true;
            MaxStamina = 700;
            Stamina = 400;
            Damage = 20;
            FireRate = 0.50f;
            SpecialID = 7;
            CmdSpecialSetup();
        }

        if(SpecialID > 3)
        {
            Boss = true;
            Team = 1;

        }

    }

    private void Update()
    {
        if (!CharacterReady)
        {
            if (isLocalPlayer)
            {
                CCP.LinkPanel(this);
                LN.MainCamera.GetComponent<CameraFollow>().Target = transform;
                GetComponent<TestMouse>().PlayerCamera = LN.MainCamera.GetComponent<Camera>();
            }

        }

        if (isLocalPlayer)
        {
            Local = true;
        }

        if (Dead)
        {
            TDC.enabled = false;
            if (isLocalPlayer)
            {
                LN.DeadScreen.SetActive(true);
            }
        }

        if (SpecialID == 0)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.5f, 0, 0.5f);
        }
        else if (SpecialID == 1)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0);
        }
        else if (SpecialID == 2)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1);
        }
        else if (SpecialID == 3)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 1);
        }
        else if (SpecialID > 3)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
        }


        FiringCooldown += Time.deltaTime;
        HabilityCharge += HabilityChargingSpeed * Time.deltaTime;
        SecondaryCharge += SecondaryChargingSpeed * Time.deltaTime;
        if(Invincible > -0.1f)
        {
            Invincible -= Time.deltaTime;
        }
        if (BuffSpeed > -0.1f)
        {
            BuffSpeed -= Time.deltaTime;
        }
        
        if(SpecialID == 2)
        {
            if (BuffSpeed > 0)
            {
                WalkingSpeed = 6;
                SprintSpeed = 16;
            }
            else 
            {
                WalkingSpeed = 3;
                SprintSpeed = 8;
            }
        }

        if (!isLocalPlayer) { return; }

        if (Input.GetButtonDown("Fire3"))
        {
            if (HabilityCharge > 100) { Special(); }
        }

        if (Input.GetButtonDown("Fire4"))
        {
            if (SecondaryCharge > 100) { SecondarySpecial(); }
        }

        if (Stamina > 0 && Input.GetButton("Fire2"))
        {
            TDC.Speed = SprintSpeed;
            Stamina--;
        } else
        {
            TDC.Speed = WalkingSpeed;
            if (Stamina <= MaxStamina)
            {
                Stamina++;
            }
        }
        if (AutomaticFire)
        {
            if (FiringCooldown > FireRate && Input.GetButton("Fire1"))
            {
                CmdShoot();
                FiringCooldown = 0;
            }
        } else
        {
            if (FiringCooldown > FireRate && Input.GetButtonDown("Fire1"))
            {
                CmdShoot();
                FiringCooldown = 0;
            }
        }
    }
    [Command]
    void CmdShoot()
    {
        GameObject GO;

        GO = Instantiate(ProjectilePrefabs[FiringMode]);
        GO.transform.position = GunPosition.transform.position;
        Bullet BL = GO.GetComponent<Bullet>();
        BL.Damage = (int)Damage;
        if (FiringMode == 1) { GO.GetComponent<Bullet>().Heal = true; }
        GO.GetComponent<Rigidbody>().AddForce(BulletSpeed * transform.forward);
        BL.Shooter = gameObject;
        GO.GetComponent<Bullet>().Team = Team;
        NetworkServer.Spawn(GO);
    }

    public void SelectSlotButton(int I)
    {
        CmdSlotButton(I);
    }


    [Command]
    void CmdSlotButton(int I)
    {
        NetworkInfo.NI.CmdSelectSlot(I);
    }

    [Command]
    void CmdCustomShoot(int ProjetileIndex,float CustomBulletSpeed,int BulletDamage,bool Heal)
    {
        GameObject GO;
        GO = Instantiate(ProjectilePrefabs[ProjetileIndex]);
        GO.transform.position = GunPosition.transform.position;
        if (ProjetileIndex != 4)
        {
            Bullet BL = GO.GetComponent<Bullet>();
            BL.Damage = BulletDamage;
            if (Heal) { GO.GetComponent<Bullet>().Heal = true; }
            BL.Shooter = gameObject;
        } else if (ProjetileIndex == 4)
        {
            ZaWarudo ZW = GO.GetComponent<ZaWarudo>();
            ZW.Shooter = gameObject;
        }
        GO.GetComponent<Bullet>().Team = Team;
        GO.GetComponent<Rigidbody>().AddForce(CustomBulletSpeed * transform.forward);
        NetworkServer.Spawn(GO);
    }

    [Command]
   public void CmdSpecialSetup()
    {
        if (SpecialID == 0)
        {
            HabilityName = "Blink";
            Hability2Name = "Teste1";
            // Velocidade que a primeira habilidade carrega
            HabilityChargingSpeed = 10f;
            // Velocidade que a Segunda habilidade carrega
            SecondaryChargingSpeed = 8f;
        }
        if(SpecialID == 1)
        {
            HabilityName = "Switch";
            Hability2Name = "Healar Tudo";
            HabilityChargingSpeed = 20f;
            SecondaryChargingSpeed = 8f;
        }
        if(SpecialID == 2)
        {
            HabilityName = "Invencible";
            Hability2Name = "Teste3";
            HabilityChargingSpeed = 50f;
            SecondaryChargingSpeed = 8f;
        }
        if (SpecialID == 3)
        {
            HabilityName = "Freeze Time";
            Hability2Name = "Teste4";
            HabilityChargingSpeed = 5f;
            SecondaryChargingSpeed = 10f;
        }
        if (SpecialID == 4)
        {
            Hability2Name = "Teste1";
            HabilityName = "Level UP";
            HabilityChargingSpeed = 6f;
            SecondaryChargingSpeed = 8f;
        }
        if (SpecialID == 5)
        {
            HabilityName = "LevelUp";
            Hability2Name = "Heal";
            HabilityChargingSpeed = 10f;
            SecondaryChargingSpeed = 8f;
        }
        if (SpecialID == 6)
        {
            HabilityName = "LevelUp";
            Hability2Name = "Beserk";
            HabilityChargingSpeed = 20f;
            SecondaryChargingSpeed = 8f;
        }
        if (SpecialID == 7)
        {
            HabilityName = "LevelUp";
            Hability2Name = "Heal";
            HabilityChargingSpeed = 50f;
            SecondaryChargingSpeed = 8f;
        }

    }
    void Special()
    {
        if (SpecialID == 0) { TDC.TeleportCharacter(15); }
        if (SpecialID == 1) { if (FiringMode == 0) { FiringMode = 1; } else { FiringMode = 0; } }
        if (SpecialID == 2) { CmdBecomeInvincible(2); }
        // Freeze Time
        if (SpecialID == 3)
        {
            CmdCustomShoot(4, 0, 0, false);
        }
        if (SpecialID == 4)
        {
            WalkingSpeed *= 0.5f;
            SprintSpeed *= 0.5f;
            FireRate *= 0.2f;
            Damage *= 0.2f;
            MaxStamina *= 2;
            MaxHP += MaxHP / 5;
        }
        if (SpecialID == 5)
        {
            WalkingSpeed *= 0.5f;
            SprintSpeed *= 0.5f;
            FireRate *= 0.2f;
            Damage *= 0.2f;
            MaxStamina *= 2;
            MaxHP += MaxHP / 5;
        }
        if (SpecialID == 6)
        {
            WalkingSpeed *= 0.5f;
            SprintSpeed *= 0.5f;
            FireRate *= 0.2f;
            Damage *= 0.2f;
            MaxStamina *= 2;
            MaxHP += MaxHP / 5;
        }
        if (SpecialID == 7)
        {
            WalkingSpeed *= 0.5f;
            SprintSpeed *= 0.5f;
            FireRate *= 0.2f;
            Damage *= 0.2f;
            MaxStamina *= 2;
            MaxHP += MaxHP / 5;
        }
        CmdSpendSpecial(false);
    }
    [Command]
    void CmdSpendSpecial(bool secondary)
    {
        if (!secondary) {
            HabilityCharge = 0;
                } else
        {
            SecondaryCharge = 0;
        }
    }

    [Command]
    void CmdBecomeInvincible(int Time)
    {
        Invincible = Time;
    }

    [Command]
    void CmdBecomeFast(int Time)
    {
        BuffSpeed = Time;
    }



    void SecondarySpecial()
    {
        // Pyroblast
        if(SpecialID == 0)
        {
            CmdCustomShoot(3, BulletSpeed * 0.5f, (int)Damage * 3, false);
        }

        // HEala o mapa todo
        if(SpecialID == 1)
        {
            CmdCustomShoot(5, 0, 10, true);
        }
        // Ficar rapido e invencivel
        if (SpecialID == 2)
        {
            CmdBecomeInvincible(2);
            CmdBecomeFast(2);
        }

        if (SpecialID == 3)
        {
            CmdCustomShoot(5, 0, 10, true);
        }

        // Pyroblast
        if (SpecialID == 4)
        {
            CmdCustomShoot(3, BulletSpeed * 0.5f, (int)Damage * 3, false);
        }

        // HEala o mapa todo
        if (SpecialID == 5)
        {
            CmdCustomShoot(5, 0, 10, true);
        }
        // Ficar rapido e invencivel
        if (SpecialID == 6)
        {
            CmdBecomeInvincible(2);
            CmdBecomeFast(2);
        }
        if (SpecialID == 7)
        {
            CmdCustomShoot(5, 0, 10, true);
        }
        CmdSpendSpecial(true);
    }

    public void ZaWarudo()
    {
        GetComponent<TopDownController>().BecomeUnableToMove(6);
    }

    [Server]
    public void TakeDamage(int Damage)
    {
        if (Invincible < 0.1f)
        {
            Debug.Log("Trying to take Health away");
            HP -= Damage;
            if(HP < 1)
            {
                Die();
                DeadPanelPlayer.SetActive(true);
            }
        }
    }

    [Server]
    void Die()
    {
        if (Boss)
        {
            NetworkInfo.NI.CmdBossDied();
        } else
        {
            NetworkInfo.NI.CmdPlayerDied();
            DeadPanelPlayer.SetActive(true);
        }
    }
    [Server]
    public void HealDamage(int Healing)
    {
        HP += Healing;
    }
}
