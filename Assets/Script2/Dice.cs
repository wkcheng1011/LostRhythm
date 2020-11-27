using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private bool coroutineAllowed = true;

    private void Start () {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
	}
	

    private void OnMouseDown()
    {
        if(coroutineAllowed)
        StartCoroutine("RollTheDice");
    }


    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
 
            randomDiceSide = Random.Range(0, 5);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }


        GameControl.diceSideThrown = randomDiceSide + 1;
        GameControl.MovePlayer();
        coroutineAllowed = true;
    
    }

}
