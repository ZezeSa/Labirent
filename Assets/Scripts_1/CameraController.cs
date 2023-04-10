using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*Player ve Camera'nýn transform özelliklerini ayrý ayrý kontrol etmek ve kamerayý karakterden baðýmsýz olarak istediðimiz
    gibi hareket ettirebilmek için bu Controller'ý yazdýk.
    */
    [SerializeField] private Transform player;

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
