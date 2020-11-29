
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    private static GameObject character, optionMenu;
    
    public static int diceSideThrown = 0;
    public static int playerStartWayPoint = 0;
    public Dialog dialog1, dialog2, dialog3;
    public bool []conditionForOnce = {true, true}, conditionForDialog = { true, false, false };
    public Button continueButton;
   


    void Start()
    {

        dialog1.CallDialog();
        character = GameObject.Find("Character");
        optionMenu = GameObject.Find("OptionMenu");
        optionMenu.SetActive(false);
        character.GetComponent<Move>().moveAllowed = false;

        continueButton.onClick.AddListener(DialogContinue);
    }



    void DialogContinue()
    {
        if (conditionForDialog[0]) { dialog1.NextSentence(); }
        if (conditionForDialog[1]) { dialog2.NextSentence(); }
        if (conditionForDialog[2]) { dialog3.NextSentence(); }
    }

    void Event()
    {
       
        character.GetComponent<Move>().moveAllowed = false;
        diceSideThrown = 0;
        
        
    }
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape) && Dialog.dialogEnd) {
            optionMenu.SetActive(true);
            Time.timeScale = 0;
            
        }



        if (character.GetComponent<Move>().waypointIndex > playerStartWayPoint + diceSideThrown) {
            character.GetComponent<Move>().moveAllowed = false;
           
            playerStartWayPoint = character.GetComponent<Move>().waypointIndex - 1;
        }


        if (character.GetComponent<Move>().waypointIndex == 4 && conditionForOnce[0])
        {
            
            conditionForDialog[1] = true;
            conditionForDialog[0] = false;
            dialog2.CallDialog();
            Event(); conditionForOnce[0] = false;
            GameObject.Find("Sword").SetActive(false);
        }



        if (character.GetComponent<Move>().waypointIndex == 7 && conditionForOnce[1])
        {
            
            conditionForDialog[1] = false;
            conditionForDialog[2] = true;
            dialog3.CallDialog();
            Event(); conditionForOnce[1] = false;
            GameObject.Find("Monster").SetActive(false);
        }

        if (character.GetComponent<Move>().waypointIndex == 11){
            SceneManager.LoadScene(8);
        }

        if (dialog3.dialogEndForObject)
            SceneManager.LoadScene(5);

    }

    public static void MovePlayer() {
        character.GetComponent<Move>().moveAllowed = true;
        

    }
}
