using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using System.Linq;

public class CharacterManager : MonoBehaviour
{
    private List<Character> _Characters;
    [SerializeField]
    private GameObject _characterPrefab;
    [SerializeField]
    private CharacterMoods _rasputinMoods;
    [SerializeField]
    private CharacterMoods _pipoMoods;
    [SerializeField]
    private CharacterMoods _peonMoods;
    [SerializeField]
    private CharacterMoods _alfilMoods;
    [SerializeField]
    private CharacterMoods _rocaMoods;
    [SerializeField]
    private CharacterMoods _caballoMoods;
    [SerializeField]
    private CharacterMoods _reinaMoods;
    [SerializeField]
    private CharacterMoods _reyMoods;

    // Start is called before the first frame update
    void Awake()
    {
        _Characters = new List<Character>();
    }
    public void CreateCharacter(string name, string position, string mood)
    {
        Debug.Log(name+" "+position+" "+mood);
        if(!Enum.TryParse(name, out CharacterName nameEnum)){
            Debug.LogWarning("Fallo"+nameEnum);
        }
        if (!Enum.TryParse(position, out CharacterPosition positionEnum))
        {
            Debug.LogWarning("Fallo" + positionEnum);
        }
        if (!Enum.TryParse(mood, out CharacterMood moodEnum))
        {
            Debug.LogWarning("Fallo" + moodEnum);
        }
        CreateCharacter(nameEnum, positionEnum, moodEnum);
    }
    public void CreateCharacter(string name, string position, string mood, string color){
        Debug.Log(name+" "+position+" "+mood+" "+color);
        if(!Enum.TryParse(name, out CharacterName nameEnum)){
            Debug.LogWarning("Fallo"+nameEnum);
        }
        if (!Enum.TryParse(position, out CharacterPosition positionEnum))
        {
            Debug.LogWarning("Fallo" + positionEnum);
        }
        if (!Enum.TryParse(mood, out CharacterMood moodEnum))
        {
            Debug.LogWarning("Fallo" + moodEnum);
        }if (!Enum.TryParse(color, out CharacterColor colorEnum))
        {
            Debug.LogWarning("Fallo " + colorEnum + " " + color);
        }

        CreateCharacter(nameEnum, positionEnum, moodEnum + (int)colorEnum);
    }
    public void CreateCharacter(CharacterName name, CharacterPosition position, CharacterMood mood)
    {
        var character = _Characters.FirstOrDefault(c => c.Name == name);
        if (character == null)
        {
            var CharacterObject = Instantiate(_characterPrefab, gameObject.transform,false);
            character = CharacterObject.GetComponent<Character>();
            _Characters.Add(character);

        }else if (character.IsShowing)
        {
            return;
        }
        character.Init(name, position, mood, GetMoodSetForCharacter(name));

    }
    public void HideCharacter(string name)
    {
        if(!Enum.TryParse(name, out CharacterName nameEnum)){
            return;
        }
        HideCharacter(nameEnum);
    }
    public void HideCharacter(CharacterName name)
    {
        var character = _Characters.FirstOrDefault(_c => _c.Name == name);
        if (character?.IsShowing != true)
        {
            Debug.Log("No esta mostrado");
        }
        else
        {
            character?.Hide();
        }

    }
    public void ChangeMood(string name, string mood)
    {
        if (!Enum.TryParse(name, out CharacterName nameEnum))
        {
            Debug.LogWarning("Fallo"+nameEnum);
            return;
        }
        if (!Enum.TryParse(mood, out CharacterMood moodEnum))
        {
            Debug.LogWarning("Fallo"+moodEnum);
            return;
        }

        ChangeMood(nameEnum, moodEnum);
    }
    public void ChangeMood(CharacterName name, CharacterMood mood)
    {
        var character = _Characters.FirstOrDefault(_c => _c.Name == name);
        if(character?.IsShowing != true)
        {
            return;
        }
        else
        {
            character.ChangeMood(mood);
        }
    }
    private CharacterMoods GetMoodSetForCharacter(CharacterName name)
    {
        switch (name)
        {
            case CharacterName.rasputin:
            return _rasputinMoods;
            case CharacterName.pipo:
            return _pipoMoods;
            case CharacterName.peon:
            return _peonMoods;
            case CharacterName.alfil:
            return _alfilMoods;
            case CharacterName.roca:
            return _rocaMoods;
            case CharacterName.caballo:
            return _caballoMoods;
            case CharacterName.reina:
            return _reinaMoods;
            case CharacterName.rey:
            return _reyMoods;
            default:
            return null;
        }
    }
}
