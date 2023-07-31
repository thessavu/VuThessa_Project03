using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private TextMeshProUGUI _characterNameText;
    [SerializeField] private Image _characterSprite;

    public void Display(DialogueData data)
    {
        _dialogueText.text = data.Dialogue;
        _characterNameText.text = data.CharacterName;
        _characterSprite.sprite = data.Portrait;
    }
}
