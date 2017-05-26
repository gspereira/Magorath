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

    public bool CharacterReady = false;

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
    public float MaxStamina;

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
    [SyncVar]
    public float HabilityCharge;
    [SyncVar]
    public float HabilityChargingSpeed;
    [SyncVar]
    public int HabilityCounter;

    public bool Local;

    private void Start()
    {
        LN = GameObject.Find("Linking Point").GetComponent<Link>();
        TDC = GetComponent<TopDownController>();
        CCP = GameObject.Find("Choose Character").GetComponent<ChooseCharacterPanel>();
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
        if (!isLocalPlayer) { return; }

        if (Input.GetButtonDown("Fire3"))
        {
            if (HabilityCharge > 100) { Special(); }
        }
        if(Stamina > 0 && Input.GetButton("Fire2"))
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
    [Command]
   public void CmdSpecialSetup()
    {
        if (SpecialID == 0)
        {
            HabilityName = "Blink";
            HabilityChargingSpeed = 10f;
        }
        if(SpecialID == 1)
        {
            HabilityName = "Switch";
            HabilityChargingSpeed = 20f;
        }
        if (SpecialID == 2)
        {
            HabilityName = "Level UP";
            HabilityChargingSpeed = 6f;
        }
    }
    void Special()
    {
        if (SpecialID == 0) { TDC.TeleportCharacter(15); }
        if (SpecialID == 1) { if (FiringMode == 0) { FiringMode = 1; } else { FiringMode = 0; } }
        if (SpecialID == 2)
        {
            if (HabilityCounter < 5)
            {
                WalkingSpeed *= 0.75f;
                SprintSpeed *= 0.75f;
                FireRate *= 0.2f;
                Damage *= 1.5f;
                MaxStamina *= 1.2f;
                HabilityCounter++;
            }
        }
        HabilityCharge = 0;
    }

    [Server]
    public void TakeDamage(int Damage)
    {
        Debug.Log("Trying to take Health away");
        HP -= Damage;
    }
    [Server]
    public void HealDamage(int Healing)
    {
        HP += Healing;
    }
}
