using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    /*
     * Objenin herhangi noktasýna deðdiðimiz zaman da çalýþýyordu, bunun olmamasý için...
     * 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player") //Hiyerarþideki ismi player mý diye kontrol ediyoruz...
        {
            collision.gameObject.transform.SetParent(transform); //Player'ýn, hareketli platformumuzun çocuðu olarak atýyoruz...
        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player") 
        {
            collision.gameObject.transform.SetParent(null); //Playerý, hiyerarþideki yerine geri koyuyoruz...
        }

    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") //Hiyerarþideki ismi player mý diye kontrol ediyoruz...
        {
            collision.gameObject.transform.SetParent(transform); //Player'ýn, hareketli platformumuzun çocuðu olarak atýyoruz...
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null); //Playerý, hiyerarþideki yerine geri koyuyoruz...
        }
    }
}
