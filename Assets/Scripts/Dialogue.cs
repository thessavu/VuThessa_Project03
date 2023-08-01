using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Multiline]
   // [SerializeField] private string _dialogue = "...";
    [SerializeField] private string _characterName = "...";
    [SerializeField] private Sprite _portrait = null;

    public string[] _sentences;
}
