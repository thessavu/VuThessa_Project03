using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DialogueSO", fileName = "DLG_")]
public class DialogueData : ScriptableObject
{
    //dialogue data here
    [Header("Character Info")]
    [SerializeField] private string _characterName = "...";
    public Sprite _portrait = null;
    [Multiline]
    [SerializeField] private string _dialogue = "...";
    [Tooltip("Taken from Audio in Prefabs")]
    [SerializeField] private AudioSource _dialogueAudio;

    [Header("Options")]
    [SerializeField] public bool _screenShake;
    [SerializeField] public EmotionType _emotion = EmotionType.Normal;

    public string Dialogue => _dialogue;
    public string CharacterName => _characterName;
    public Sprite Portrait => _portrait;
    public AudioSource DialogueAudio => _dialogueAudio;
    public EmotionType Emotion => _emotion;
  
}
