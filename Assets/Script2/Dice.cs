using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Scene30 gameControl;

    public Sprite[] diceSides;
    public SpriteRenderer spriteRenderer;
    public bool coroutineAllowed = true;

    public int diceSideThrown;
    public bool active
    {
        get
        {
            return gameObject.activeSelf;
        }
        set
        {
            gameObject.SetActive(value);
        }
    }

    public void Roll()
    {
        if (coroutineAllowed)
        {
            StartCoroutine("RollTheDice");
        }
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 5);
            spriteRenderer.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        diceSideThrown = randomDiceSide + 1;
        gameControl.MovePlayer();
        coroutineAllowed = true;
    }
}
