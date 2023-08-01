using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialogueView _dialogueView;

    [SerializeField] private DialogueData _dialogue01;
    //02
    //03
    private Queue<string> _sentences;

    DialogueView _letterType;

    private void Update()
    {
        //starts the dialogue
        StartDialogue();
        
    }

    
    public void StartDialogue()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _dialogueView.Display(_dialogue01);
        }
    }

    public void DisplayNextSentence()
    {
        if(_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //StopAllCoroutines();
       // StartCoroutine(_letterType.TypeSentence(_sentences));
    }

   

    void EndDialogue()
    {
        //run animator
    }
    
}
