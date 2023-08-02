using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueView : MonoBehaviour
{
     [SerializeField] public TextMeshProUGUI _dialogueText;

    [SerializeField] DialogueData _dialogueData;
   // [SerializeField] public TextMeshProUGUI textComponent;
   // [SerializeField] private string[] _dialogueText;

    [SerializeField] private TextMeshProUGUI _characterNameText;
    [SerializeField] private Image _characterSprite;

    [SerializeField] private float typeSpeed = 20;

    public float duration = 1f;

    /*

    void NextLine()
    {
        if(index < _dialogueText.length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    /// 
   
    */

    public void StartDialogue()
    {
       
       // StartCoroutine(TypeLine());
        StartCoroutine(DisplayDialogue());
      //  StopAllCoroutines();
        
    }

    public void ScreenShake()
    {

        //Screen shake code here
        StartCoroutine(Shaking());

    }

    IEnumerator DisplayDialogue()
    {
        _characterNameText.text = _dialogueData.CharacterName;
        _characterSprite.sprite = _dialogueData.Portrait;

        for (int i = 0; i < _dialogueData.Dialogue.Count; i++)
        {
            //display dialogue and types out letter by letter
            StartCoroutine(TypeDialogue(_dialogueData.Dialogue[i]));

            yield return new WaitForSeconds(2f);

        }
    }

    private IEnumerator TypeDialogue(string p)
    {
        float elapsedTime = 0f;

        int charIndex = 0;
        charIndex = Mathf.Clamp(charIndex, 0, p.Length);

        while(charIndex < p.Length)
        {
            elapsedTime += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(elapsedTime);

            _dialogueText.text = p.Substring(0, charIndex);

            yield return null;
        }
        _dialogueText.text = p;
    }

    public IEnumerator Shaking()
    {
        Vector3 startPosition = _dialogueText.transform.position;
        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            _dialogueText.transform.position = startPosition + Random.insideUnitSphere;
            yield return null;
        }
        _dialogueText.transform.position = startPosition;
    }

}
