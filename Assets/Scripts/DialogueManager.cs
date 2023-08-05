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
    [Tooltip("Just insert the Dialogue_pnl")]
    public Animator _animator;

    [Header("Dialogue Parameters")]
    [Tooltip("Typing speed of the text")]
    [SerializeField] private float _typeSpeed = 20;
    [Tooltip("Duration of how long the dialogue remains on screen")]
    [SerializeField] public float _dialogueDuration = 3f;
    [Tooltip("How much time has passed")]
    [SerializeField] private float _elapsedTime = 0f;

    [Header("DialogueSO")]
    [SerializeField] private DialogueData _dialogue01;
    [SerializeField] private DialogueData _dialogue02;
    //[SerializeField] private DialogueData _dialogueXX;


    private void Start()
    {
        //turns dialogue panel off when game has started
        _dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        //calculates amount of time that has passed
        _elapsedTime += Time.deltaTime;

        //starts the dialogue
        if (Input.GetKeyDown(KeyCode.Space) && _elapsedTime < _dialogueDuration)
        {
            _dialoguePanel.SetActive(true);
            _animator.SetBool("IsOpen", true);

            StartDialogue();
        }
        //allows for next dialogue to play after set amount of time
        else if (Input.GetKeyDown(KeyCode.Space) && _elapsedTime > _dialogueDuration)
        {
            StartDialogue02();
        }

    }

    //DIALOGUE01 STARTS HERE
    public void StartDialogue()
    {
        //displays dialogue info taken from DialogueView script
        _dialogueView.Display(_dialogue01);
        //types and displays the dialogue
        StartCoroutine(DisplayDialogue());
    }

    public void TextShake()
    {
        //Screen shake code here
        StartCoroutine(Shaking());
    }

    public void EndDialogue()
    {
        //Goes into OnClick() Event of Continue_btn
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

        //dialogue01
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

        //code that types out the dialogue
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

        //Code that shakes the dialogue
        while (_elapsedTime < _dialogueDuration)
        {
            //_elapsedTime += Time.deltaTime;
            _dialogueView._dialogueText.transform.position = startPosition + Random.insideUnitSphere;
            yield return null;
        }
        _dialogueView._dialogueText.transform.position = startPosition;
    }

    //DIALOGUE02 STARTS HERE

    //dialogue02
    public void StartDialogue02()
    {
        _dialogueView.Display02(_dialogue02);
        StartCoroutine(DisplayDialogue02());
    }

    public void TextShake02()
    {
        //Screen shake code here
        StartCoroutine(Shaking02());

    }

    IEnumerator DisplayDialogue02()
    {

        StartCoroutine(TypeDialogue02(_dialogue02.Dialogue));
        yield return new WaitForSeconds(10f);

    }

    private IEnumerator TypeDialogue02(string p)
    {
        float elapsedTime = 0f;

        int charIndex = 0;
        charIndex = Mathf.Clamp(charIndex, 0, p.Length);

        //if statement for screenshake
        if (_dialogue02._screenShake == true)
        {
            TextShake02();
        }

        //plays the audio
        if (_dialogue02.DialogueAudio != null)
        {
            AudioSource newSound = Instantiate(_dialogue02.DialogueAudio, transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
        }

        //types out the dialogue
        while (charIndex < p.Length)
        {
            elapsedTime += Time.deltaTime * _typeSpeed;
            charIndex = Mathf.FloorToInt(elapsedTime);

            _dialogueView._dialogueText.text = p.Substring(0, charIndex);

            yield return null;
        }

        _dialogueView._dialogueText.text = p;
    }

    
    public IEnumerator Shaking02()
    {
        //shakes the dialogue
        Vector3 startPosition = _dialogueView._dialogueText.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < _dialogueDuration)
        {
            elapsedTime += Time.deltaTime;
            _dialogueView._dialogueText.transform.position = startPosition + Random.insideUnitSphere;
            yield return null;
        }
        _dialogueView._dialogueText.transform.position = startPosition;
    }
}
