using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    [Header("DialogueHUD_cnv")]
    [SerializeField] private DialogueView _dialogueView;

    [Header("Dialogue_pnl")]
    [SerializeField] private GameObject _dialoguePanel;
    public Animator _animator;

    [Header("Dialogue Parameters")]
    [SerializeField] private float _typeSpeed = 20;
    [SerializeField] public float _dialogueDuration = 10f;
    [SerializeField] private float _elapsedTime = 0f;

    [Header("DialogueSO")]
    [SerializeField] private DialogueData _dialogue01;
    //[SerializeField] private DialogueData _dialogueXX;
    //[SerializeField] private DialogueData _dialogueXX;


    private void Start()
    {
        _elapsedTime += Time.deltaTime;
        _dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        //starts the dialogue
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _dialoguePanel.SetActive(true);
            _animator.SetBool("IsOpen", true);

            StartDialogue();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            EndDialogue();
        }
        
    }

    public void StartDialogue()
    {
        _dialogueView.Display(_dialogue01);
        //test
        //StartCoroutine(TypeDialogue(_dialogue01.Dialogue));
         StartCoroutine(DisplayDialogue());
    }

    public void TextShake()
    {
        //Screen shake code here
        StartCoroutine(Shaking());
    }

    public void EndDialogue()
    {
        Debug.Log("End of Dialogue");
        StopAllCoroutines();
        _animator.SetBool("IsOpen", false);
    }

    IEnumerator DisplayDialogue()
    {
        StartCoroutine(TypeDialogue(_dialogue01.Dialogue));

        yield return new WaitForSeconds(10f);

    }

    private IEnumerator TypeDialogue(string p)
    {
        float elapsedTime = 0f;

        int charIndex = 0;
        charIndex = Mathf.Clamp(charIndex, 0, p.Length);

        if (_dialogue01._screenShake == true)
        {
            TextShake();
        }

        //Audio Player
        if (_dialogue01.DialogueAudio != null)
        {
            AudioSource newSound = Instantiate(_dialogue01.DialogueAudio, transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
        }


        while (charIndex < p.Length)
        {
            elapsedTime += Time.deltaTime * _typeSpeed;
            charIndex = Mathf.FloorToInt(elapsedTime);

            _dialogueView._dialogueText.text = p.Substring(0, charIndex);
            
            yield return null;
        }
       

        _dialogueView._dialogueText.text = p;

    }

    public IEnumerator Shaking()
    {
        Vector3 startPosition = _dialogueView._dialogueText.transform.position;
        //float elapsedTime = 0f;

        while (_elapsedTime < _dialogueDuration)
        {
            //_elapsedTime += Time.deltaTime;
            _dialogueView._dialogueText.transform.position = startPosition + Random.insideUnitSphere;
            yield return null;
        }
        _dialogueView._dialogueText.transform.position = startPosition;
    }

    
}
