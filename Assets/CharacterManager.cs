using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using System.Linq;

public class CharacterManager : MonoBehaviour
{
    private List<Character> _Character;
    private GameObject _characterPrefab;
    private CharacterMoods _rasputinMoods;
    private CharacterMoods _pipoMoods;

    // Start is called before the first frame update
    void Start()
    {
        _Character = new List<Character>();
    }
    public void CreateCharacter(string name, string position, string mood)
    {
        if(!Enum.TryParse(name, out CharacterName nameEnum)){
            Debug.LogWarning("Fallo"+nameEnum);
        }
        if (!Enum.TryParse(name, out CharacterPosition positionEnum))
        {
            Debug.LogWarning("Fallo" + nameEnum);
        }
        if (!Enum.TryParse(name, out CharacterMood moodEnum))
        {
            Debug.LogWarning("Fallo" + nameEnum);
        }
        CreateCharacter(nameEnum, positionEnum, moodEnum);
    }
    public void CreateCharacter(CharacterName name, CharacterPosition position, CharacterMood mood)
    {
        var character = _Character.FirstOrDefault(c => c.Name == name);
        if (character == null)
        {
            var CharacterObject = Instantiate(_characterPrefab, gameObject.transform,false);
            character = CharacterObject.GetComponent<Character>();
            _Character.Add(character);

        }else if (character.IsShowing)
        {
            return;
        }
        character.Init(name, position, mood);

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
        var character = _Character.FirstOrDefault(_c => _c.Name == name);
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
            return;
        }
        if (!Enum.TryParse(name, out CharacterMood moodEnum))
        {
            return;
        }

        ChangeMood(nameEnum, moodEnum);
    }
    public void ChangeMood(CharacterName name, CharacterMood mood)
    {
        var character = _Character.FirstOrDefault(_c => _c.Name == name);
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
            case CharacterName.Rasputin:
                return _rasputinMoods;
            case CharacterName.Pipo:
                return _pipoMoods;
            default:

                return null;
        }
    }
}
