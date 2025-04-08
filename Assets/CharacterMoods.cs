using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoods : MonoBehaviour
{
    public CharacterName Name;
    public Sprite Bag;
    public Sprite Phone;
    public Sprite Flex;
    public Sprite GetMoodSprite(CharacterMood mood)
    {
        switch (mood)
        {
            case CharacterMood.Bag:
            return Bag;
            case CharacterMood.Phone:
            return Phone ?? Bag;
            case CharacterMood.Flex:
            return Flex ?? Bag;
            default:
                Debug.Log($"No se encontró el Sprite para el personaje: {Name}, mood : {mood}");
            return Bag;
        }
    }
}
