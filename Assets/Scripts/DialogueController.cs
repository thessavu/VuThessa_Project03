using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private GameObject _dialoguePanel;

    [SerializeField] private DialogueView _dialogueView;

    public Animator _animator;

  //  [SerializeField] private DialogueData _dialogue01;
    //02
    //03

    [SerializeField] List<DialogueData> _dialogue = new List<DialogueData>();

    DialogueView _letterType;

 

}
