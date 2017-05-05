using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class TestMouse : NetworkBehaviour
{
    public Camera PlayerCamera;
    [SerializeField]
    float Altura;
    
    public Quaternion TRA3;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
        }
    }


    void Update()
    {
        Vector3 TRA1 = transform.eulerAngles;
        RaycastHit hit;
            Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
        

            transform.LookAt(hit.point);
            Vector3 TRA2 = transform.eulerAngles;
            TRA2.x = TRA1.x;
            transform.eulerAngles = TRA2;
        }
        }
}