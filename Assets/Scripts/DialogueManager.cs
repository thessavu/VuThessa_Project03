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
    [SerializeField] public float _dialogueDuration = 1f;

    [Header("DialogueSO")]
    [SerializeField] private DialogueData _dialogue01;
    //02
    //03


    private void Start()
    {
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
    }

        public void StartDialogue()
    {
        _dialogueView.Display(_dialogue01);
        StartCoroutine(DisplayDialogue());
    }

    public void TextShake()
    {
        //Screen shake code here
        StartCoroutine(Shaking());
    }
    

    IEnumerator DisplayDialogue()
    {
        StartCoroutine(TypeDialogue(_dialogue01.Dialogue));

        if (_dialogue01._screenShake == true)
        {
            TextShake();
        }

        yield return new WaitForSeconds(2f);

    }

    private IEnumerator TypeDialogue(string p)
    {
        float elapsedTime = 0f;

        int charIndex = 0;
        charIndex = Mathf.Clamp(charIndex, 0, p.Length);

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
