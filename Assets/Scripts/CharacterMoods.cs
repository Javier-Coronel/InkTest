using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoods : MonoBehaviour
{
    public CharacterName Name;
    
    
    public Sprite Normal;
    public Sprite Angry;
    public Sprite Bag;
    public Sprite Phone;
    public Sprite Flex;
    public Sprite NormalBlack;
    public Sprite AngryBlack;
    public Sprite BagBlack;
    public Sprite PhoneBlack;
    public Sprite FlexBlack;
    public Sprite GetMoodSprite(CharacterMood mood)
    {
        switch (mood)
        {
            case CharacterMood.normal:
            return Normal;

            case CharacterMood.normalBlack:
            return NormalBlack??Normal;

            case CharacterMood.angry:
            return Angry??Normal;

            case CharacterMood.angryBlack:
            return AngryBlack??NormalBlack??Normal;

            case CharacterMood.bag:
            return Bag??Normal;

            case CharacterMood.bagBlack:
            return BagBlack??NormalBlack??Normal;

            case CharacterMood.phone:
            return Phone ?? Normal;

            case CharacterMood.phoneBlack:
            return PhoneBlack??NormalBlack??Normal;

            case CharacterMood.flex:
            return Flex ?? Normal;

            case CharacterMood.flexBlack:
            return FlexBlack??NormalBlack??Normal;

            default:
                Debug.Log($"No se encontro el Sprite para el personaje: {Name}, mood : {mood}");
            return Normal;
        }
    }
}
