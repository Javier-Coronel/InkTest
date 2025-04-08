using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public bool IsShowing { get; private set; } = false;
    public CharacterName Name { get; private set; }
    public CharacterMood Mood { get; private set; }
    public CharacterPosition Position { get; private set; }
    private CharacterMoods _moods;
    private float _offScreenX, _onScreenX;
    public readonly float _animationSpeed = 1f;
    public void Init(CharacterName name, CharacterPosition position, CharacterMood mood, CharacterMoods moods)
    {
        Name = name;
        Mood = mood;
        Position = position;
        _moods = moods;
        Show();
    }
    public void Show()
    {
        SetPositionValues();
        transform.position = new Vector3(_offScreenX, transform.position.y, transform.localPosition.z);

        UpdateSprite();

        LeanTween.moveX(gameObject, _onScreenX, _animationSpeed).setEase(LeanTweenType.linear).setOnComplete(() => { IsShowing = true; });
    }
    public void Hide()
    {
        LeanTween.moveX(gameObject, _offScreenX, _animationSpeed).setEase(LeanTweenType.linear).setOnComplete(() => { IsShowing = false; });
    }
    private void SetPositionValues()
    {
        switch (Position)
        {
            case CharacterPosition.Left:
                _onScreenX = Screen.width * 0.25f;
                _offScreenX = -Screen.width * 0.25f;
            break;

            case CharacterPosition.Center:
                _onScreenX = Screen.width * 0.5f;
                _offScreenX = -Screen.width * 0.25f;
            break;

            case CharacterPosition.Right:
                _onScreenX = Screen.width * 0.75f;
                _offScreenX = Screen.width * 1.25f;
            break;
        }
    }
    private void UpdateSprite()
    {
        var sprite = _moods.GetMoodSprite(Mood);
        var image = GetComponent<Image>();

        image.sprite = sprite;
        image.preserveAspect = true;
    }
    public void ChangeMood(CharacterMood mood)
    {
        Mood = mood;
        UpdateSprite();
    }
}
