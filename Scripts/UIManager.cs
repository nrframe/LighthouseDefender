using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("TextBoxes")]

    public Text findSurfaceText;

    private List<Text> listText = new List<Text>();

    [Header("Buttons")]

    public Button resetTrackingButton;

    public Button looksGoodButton;

    public Button confirmLGButton;

    public Button denyLGButton;

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

    }

    //called by confirmLGButton
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
