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

    private void Start()
    {
        LN = GameObject.Find("Linking Point").GetComponent<Link>();
        TDC = GetComponent<TopDownController>();
        CCP = GameObject.Find("Choose Character").GetComponent<ChooseCharacterPanel>();
    }

    private void OnEnable()
    {
        NetworkInfo.NI.CmdConnected();
    }

    public void BecomeReady()
    {
        CmdBecomeReady();
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
        if (ProjetileIndex < 4)
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
            HabilityChargingSpeed = 10f;
            SecondaryChargingSpeed = 8f;
        }
        if(SpecialID == 1)
        {
            HabilityName = "Switch";
            Hability2Name = "Healar Tudo";
            HabilityChargingSpeed = 20f;
        }
        if(SpecialID == 2)
        {
            HabilityName = "Invencible";
            Hability2Name = "Teste3";
            HabilityChargingSpeed = 50f;
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
            Hability2Name = "Teste5";
            HabilityName = "Level UP";
            HabilityChargingSpeed = 6f;
        }
    }
    void Special()
    {
        if (SpecialID == 0) { TDC.TeleportCharacter(15); }
        if (SpecialID == 1) { if (FiringMode == 0) { FiringMode = 1; } else { FiringMode = 0; } }
        if (SpecialID == 2) { CmdBecomeInvincible(2); }
        if (SpecialID == 4)
        {
            WalkingSpeed *= 0.5f;
            SprintSpeed *= 0.5f;
            FireRate *= 0.2f;
            Damage *= 0.2f;
            MaxStamina *= 2;
            MaxHP += MaxHP / 5;
        }
        // Freeze Time
        if (SpecialID == 3)
        {
            CmdCustomShoot(4, 0, 0, false);
        }
        HabilityCharge = 0;
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
        SecondaryCharge = 0;
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
        }
    }
    [Server]
    public void HealDamage(int Healing)
    {
        HP += Healing;
    }
}
