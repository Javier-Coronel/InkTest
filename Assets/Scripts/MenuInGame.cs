using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuInGame : MonoBehaviour
{
    public UIDocument PauseMenu;
    public bool pauseMenuActivated;
    public AudioMixer audioMixer;
    
    void Start(){
        SetSound();
        PauseMenu.enabled=false;
    }

    void Update()
    {
        bool menu = Input.GetKeyDown(KeyCode.Escape);
        if(pauseMenuActivated){
            float volume = PauseMenu.rootVisualElement[0].Q<GroupBox>("StartingMenu").Q<Slider>("Volume").value/100;
            PlayerPrefs.SetFloat("Volume",volume);
            SetSound();
            if(menu)BackToTheGame();
        }else{
            if(menu)ActivateMenu();
        }
    }
    public void SetSound(){
        audioMixer.SetFloat("Volume",PlayerPrefs.GetFloat("Volume",0.5f)>Mathf.Epsilon?50*Mathf.Log10(PlayerPrefs.GetFloat("Volume",0.5f)):-80);
    }
    public void ActivateMenu()
    {
        pauseMenuActivated = true;
        PauseMenu.enabled = true;
        PauseMenu.rootVisualElement[0].visible = true;
        PauseMenu.rootVisualElement[0].Q<GroupBox>("StartingMenu").visible = true;
        PauseMenu.rootVisualElement[0].Q<GroupBox>("StartingMenu").Q<Button>("Back").clicked += BackToTheGame;
        PauseMenu.rootVisualElement[0].Q<GroupBox>("StartingMenu").Q<Button>("Exit").clicked += ()=>{
                SceneManager.LoadScene(0);
                Destroy(gameObject);
            };
        PauseMenu.rootVisualElement[0].Q<GroupBox>("StartingMenu").Q<Slider>("Volume").value=PlayerPrefs.GetFloat("Volume",0.5f)*100;
        Time.timeScale = Mathf.Epsilon;
    }
    public void BackToTheGame(){
        pauseMenuActivated = false;
        PauseMenu.rootVisualElement[0].Q<GroupBox>("StartingMenu").visible = true;
        PauseMenu.rootVisualElement[0].visible=false;
        PauseMenu.enabled = false;
        Time.timeScale = 1;
    }
}
