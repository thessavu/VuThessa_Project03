using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueView : MonoBehaviour
{
    [Header("Panel Inputs")]
    [SerializeField] public TextMeshProUGUI _dialogueText;
    [SerializeField] public TextMeshProUGUI _characterNameText;
    [SerializeField] public Image _characterSprite;
    
    [Header("Emotion Sprites")]
    [SerializeField] public Sprite _characterSpriteNormal;
    [SerializeField] public Sprite _characterSpriteHappy;
    [SerializeField] public Sprite _characterSpriteMad;
    [SerializeField] public Sprite _characterSpriteSad;
    [SerializeField] public Sprite _characterSpriteScared;
    
    // public EmotionType _emotionType;
   // EmotionType _emotionType;
   [Header("DialogueSO")]
    [SerializeField] private DialogueData _dialogue01;

    public void Display(DialogueData data)
    {
         _dialogueText.text = data.Dialogue;
        _characterNameText.text = data.CharacterName;
        
        if ( _dialogue01._emotion == EmotionType.Normal)
        {
            Debug.Log("normal face is being displayed");
            _characterSprite.sprite = _characterSpriteNormal;
        }
        else if (_dialogue01._emotion == EmotionType.Happy)
        {
            Debug.Log("happy face is being displayed");
            _characterSprite.sprite = _characterSpriteHappy;
        }
        else if (_dialogue01._emotion == EmotionType.Mad)
        {
            Debug.Log("Angry face is being displayed");
            _characterSprite.sprite = _characterSpriteMad;
        }
        else if (_dialogue01._emotion == EmotionType.Sad)
        {
            Debug.Log("sad face is being displayed");
            _characterSprite.sprite = _characterSpriteSad;
        }
        else if (_dialogue01._emotion == EmotionType.Scared)
        {
            Debug.Log("scared face is being displayed");
            _characterSprite.sprite = _characterSpriteScared;
        }
    }
}
