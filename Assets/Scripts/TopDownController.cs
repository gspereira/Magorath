using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class TopDownController : NetworkBehaviour
{
    public float HorizontalAxis;
    public float VerticalAxis;

    float UnableMovement;

    public float Speed;
    [SerializeField]
    bool RigidBodyMovement;

    Rigidbody RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        MoveCharacter();
        UnableMovement -= Time.deltaTime;
    }

    public void BecomeUnableToMove(float Time)
    {
        UnableMovement = Time;

    }

    void MoveCharacter()
    {
        if (UnableMovement < 0.1f)
        {
            if (!RigidBodyMovement)
            {
                Vector3 TRA = transform.position;
                TRA.x += HorizontalAxis * Speed * Time.deltaTime;
                TRA.z += VerticalAxis * Speed * Time.deltaTime;
                transform.position = TRA;
            } else
            {
                RB.velocity = new Vector3(HorizontalAxis * Speed,0, VerticalAxis * Speed);
            }
        }
    }
    public void TeleportCharacter(int Ammount)
    {
        Vector3 TRA = transform.position;
        TRA.x += HorizontalAxis * Ammount;
        TRA.z += VerticalAxis * Ammount;
        transform.position = TRA;
    }




}
