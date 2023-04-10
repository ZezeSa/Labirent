using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue_One : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    public string[] lines;
    public float textSpeed;
    private int index;

    public GameObject continueButton;


    private void Start()
    {
        StartCoroutine(Type());   
    }

    private void Update()
    {
        if (textComp.text == lines[index])
        {
            continueButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach (char c in lines[index].ToCharArray()) 
        {
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < lines.Length - 1)
        {
            index++;
            textComp.text = "";
            StartCoroutine(Type());
        }
        else 
        {
            textComp.text = "";
            continueButton.SetActive(false);
        }
    }

}
