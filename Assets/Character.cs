using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool IsShowing { get; private set; } = false;
    public CharacterName Name { get; private set; }
    public CharacterMood Mood { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init(CharacterName name, CharacterPosition position, CharacterMood mood)
    {

    }
    public void Hide()
    {

    }
    public void ChangeMood(CharacterMood mood)
    {
        
    }
}
