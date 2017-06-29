using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class ZaWarudo : NetworkBehaviour
{
    [SyncVar]
    public int Damage;
    [SyncVar]
    public bool Heal;

    public GameObject Shooter;

    private void Start()
    {
        Destroy(gameObject, 0.7f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != Shooter)
        {
            if (other.gameObject.tag == "Player")
            {
                Character CHARA;
                if (other.GetComponent<Character>() != null)
                {
                    CHARA = other.GetComponent<Character>();
                    if (CHARA.SpecialID == 1) { 

                        CHARA.ZaWarudo();
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
