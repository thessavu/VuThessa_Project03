using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSO", fileName = "DLG_")]
public class DialogueData : ScriptableObject
{
    //dialogue data here
    [Header("Character Info")]
    [SerializeField] private string _characterName = "...";
    private Sprite _portrait = null;
    [Multiline]
    [SerializeField] private string _dialogue = "...";
    [SerializeField] private AudioSource _dialogueAudio;

    [Header("Options")]
    [SerializeField] public bool _screenShake;
    [SerializeField] public EmotionType _emotion = EmotionType.Normal;


    //public List<string> Dialogue => _dialogue;
    public string Dialogue => _dialogue;
    public string CharacterName => _characterName;
    public Sprite Portrait => _portrait;
    public AudioSource DialogueAudio => _dialogueAudio;
    public EmotionType Emotion => _emotion;
  
}
