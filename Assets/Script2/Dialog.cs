using System.Collections;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton, dice, image, text;
    public static bool dialogEnd = false;
    public bool dialogEndForObject = false;
    

    public void CallDialog()
    {
            
            StartDialog();
            StartCoroutine(Type());       
       
    }

    private void Update()
    {
        if (textDisplay.text == sentences[index]) {
            continueButton.SetActive(true);
        }
        


    }
    public void StartDialog() {
        
        continueButton.SetActive(false);
        dice.SetActive(false);
        image.SetActive(true);
        text.SetActive(true);
        

    }


    public IEnumerator Type() {
        foreach (char letter in sentences[index].ToCharArray()) {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }

    public void NextSentence() {
        continueButton.SetActive(false);
        dice.SetActive(false);
        if (index < sentences.Length-1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());

        }
        else {
            textDisplay.text = "";
            image.SetActive(false);
            text.SetActive(false);
            continueButton.SetActive(false);
            dice.SetActive(true);
            dialogEnd = true;
            dialogEndForObject = true;
            
            
        }
    }



}
