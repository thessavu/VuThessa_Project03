using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSO", fileName = "DLG_")]
public class DialogueData : ScriptableObject
{
    //dialogue data here


    [Multiline]
    // [SerializeField] private string _dialogue = "...";
    [SerializeField] List<string> _dialogue = new List<string>();

    [SerializeField] private string _characterName = "...";
    [SerializeField] private Sprite _portrait = null;

    [SerializeField] public bool _screenShake;


    public List<string> Dialogue => _dialogue;
    public string CharacterName => _characterName;
    public Sprite Portrait => _portrait;

}
