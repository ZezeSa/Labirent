using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static bool key;

    bool insideDoor;

    [SerializeField] GameObject interactText;
    [SerializeField] GameObject warningText;


    [SerializeField] Sprite openDoor;
    SpriteRenderer door;

    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<SpriteRenderer>();
        key = false;
    }

    // Update is called once per frame
    void Update()
    {
      if (insideDoor)
        {
            ControlDoor();
        }
    }

    void ControlDoor()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (key)
            {
                door.sprite = openDoor;
            }
            else
            {
                interactText.SetActive(false);
                warningText.SetActive(true);

            }
        }
    
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    { 
        if(collision.gameObject.CompareTag("Player"))
        {
            insideDoor = true;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            insideDoor = false;
            interactText.SetActive(false);
            warningText.SetActive(false);
        }
    }


}
