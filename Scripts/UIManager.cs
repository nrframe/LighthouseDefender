using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    [Header("TextBoxes")]

    //"Initializing"
    public Text findSurfaceText;

    //"ConfirmOrDeny"
    public Text cOrDenyText;

    //"Level"
    public Text timerText;

    public Text essenceText;

    //"Report"
    public Text reportEssenceText;

    public Text roundNumText;

    public Text essenceFromEnemies;

    public Text enemiesKilledText;

    public Text lighthouseDamageText;

    public Text lighthouseHealthText;

    public Text accuracyBonusText;

    public Text untouchedBonusText;

    public Text flawlessBonusText;

    public Text totalEssenceGainedText;

    //"Lose"
    public Text roundEndedText;

    public Text totalEnemiesKilledText;

    public Text commentText;

    private List<Text> listText = new List<Text>();

    [Header("Buttons")]

    //"Initializing"
    public Button resetTrackingButton;

    public Button looksGoodButton;

    //"ConfirmOrDeny"
    public Button confirmLGButton;

    public Button denyLGButton;

    //"Level"


    //"Report"
    public Button nextLevelButton;

    public Button healLighthouseButton;

    public Button lighthouseArmorButton;

    public Button upgradeComboButton;

    public Button upgradeAccuracyButton;

    //"Lose"
    public Button tryAgainButton;

    private List<Button> listButtons = new List<Button>();

    //Game Management Objects

    public static int roundNum = 0;

    public static int essence = 0;

    public int lighthouseHealth = 100;

    public int lighthouseArmor = 0;

    public static bool pauseGame = true;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Text go in Resources.FindObjectsOfTypeAll(typeof(Text)) as Text[])
        {
            if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                listText.Add(go);
        }

        foreach (Button go in Resources.FindObjectsOfTypeAll(typeof(Button)) as Button[])
        {
            if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                listButtons.Add(go);
        }

    //"Initializing"
    findSurfaceText.text = "Point the camera at the image Target";

    //"ConfirmOrDeny"
    cOrDenyText.text = "Is this where you want the lighthouse?";

    //"Lose"
     commentText.text = "Don't give up! Try again";

    TransitionScene("Initializing");
    }

    public void TransitionScene(string tagOfDesireScene)
    {

        foreach (Text currentText in listText)
        {
            if (currentText.CompareTag(tagOfDesireScene))
                currentText.gameObject.SetActive(true);

            else
                currentText.gameObject.SetActive(false);
        }

        foreach (Button currentButton in listButtons)
        {
            if (currentButton.CompareTag(tagOfDesireScene))
                currentButton.gameObject.SetActive(true);

            else
                currentButton.gameObject.SetActive(false);
        }

    }
    //========================================== Initilalizing Functions =====================================================

    public void ResetTracking()
    {
        TrackingManager.counter = 0;
    }

    public void LooksGood()
    {
        TransitionScene("ConfirmOrDeny");
    }

    //========================================== ConfirmOrDeny Functions =====================================================

    public void ConfirmLG()
    {

        TransitionScene("Level");
        roundNum++;
        pauseGame = false;
    }

    public void DenyLG()
    {
        TransitionScene("Initializing");
    }

    //========================================== Report Functions =====================================================

    public void NextLevel()
    {
        TransitionScene("Level");
        roundNum++;
        pauseGame = false;
    }

    public void HealLighthouse()
    {
        if (essence > 20)
        {
            essence -= 20;
            if (lighthouseHealth < 81)
                lighthouseHealth += 20;

            else
                lighthouseHealth = 100;
        }
        reportEssenceText.text = (essence.ToString()) ;
    }

    public void LightHouseArmor()
    {
        if (essence > 20)
        {
            lighthouseArmor += 20;
            essence -= 20;
        }
        reportEssenceText.text = (essence.ToString());
    }

    public void UpgradeCombo()
    {
        //TODO figure out how to tell if they miss ghost
    }

    public void UpgradeAccuracy()
    {
        if (essence > 20)
        {
            essence -= 20;

            foreach (GameObject enemy in EnemyManager.currentEnemies)
            {

            }

            reportEssenceText.text = (essence.ToString());
        }
        

    }
     
    //========================================== Lose Functions =====================================================

    public void TryAgain()
    {
    roundNum = 0;

    essence = 0;

    lighthouseHealth = 100;

    lighthouseArmor = 0;

    TransitionScene("Level");
    }

}


