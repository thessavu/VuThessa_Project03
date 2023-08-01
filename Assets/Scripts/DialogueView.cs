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

  

    IEnumerator TypeSentence(string sentence)
    {
         _dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            _dialogueText.text += letter;

            yield return null;
        }
    }

    public void Display(DialogueData data)
    {
        _dialogueText.text = data.Dialogue;
        _characterNameText.text = data.CharacterName;
        _characterSprite.sprite = data.Portrait;
    }

}
