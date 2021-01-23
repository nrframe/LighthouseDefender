using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text roundNumText;

    public Text essenceFromEnemies;

    public Text enemiesKilled;

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

    //"Report"
    public Button nextLevelButton;

    public Button healLighthouseButton;

    public Button lighthouseArmorButton;

    public Button upgradeComboButton;

    public Button upgradeAccuracyButton;

    //"Lose"
    public Button tryAgainButton;

    private List<Button> listButtons = new List<Button>();

    // Start is called before the first frame update
    void Start()
    {
        
        listText.Add(findSurfaceText);

        
        listButtons.Add(resetTrackingButton);
        listButtons.Add(looksGoodButton);
        listButtons.Add(confirmLGButton);
        listButtons.Add(denyLGButton);
        
    }

    //called by looksGoodButton
    public void PromptForConfirmation()
    {
        findSurfaceText.text = "This is a good spot for the lighthouse?";
        TransitionScene("cordeny");

    }

    //called by confirmLGButton
    public void LoadLevel()
    {
        TransitionScene("level");
    }
    //called by denyLGButton
    public void PromptForTracking()
    {
        TransitionScene("init");
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
}
