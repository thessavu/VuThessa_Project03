using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private GameObject _dialoguePanel;

    [SerializeField] private DialogueView _dialogueView;

   // DialogueData _dialogueData;

    [SerializeField] private DialogueData _dialogue01;
    //02
    //03

    DialogueView _letterType;

    private void Start()
    {
        _dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        //starts the dialogue
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _dialoguePanel.SetActive(true);
            _dialogueView.StartDialogue();
        }

        if (_dialogue01._screenShake == true)
        {
            TextShake();
        }
    }

    public void DisplayNextSentence()
    {
        //
    }

    
   

    void EndDialogue()
    {
        //run animator
    }

    private void TextShake()
    {

        //Screen shake code here
        _dialogueView.ScreenShake();
       
    }


}
