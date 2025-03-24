using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;
public class InkManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset _inkJSONAsset;
    private Story _story;
    [SerializeField]
    private TMP_Text _textField;
    [SerializeField]
    private VerticalLayoutGroup _verticalLayoutGroup;
    [SerializeField]
    private GameObject _choiceButtonsContainer;
    [SerializeField]
    private Button _choiceButtonPrefab;
    private CharacterManager _characterManager;
    // Start is called before the first frame update
    void Start()
    {
        _characterManager = FindObjectOfType<CharacterManager>();
        StartStory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Inicializa la historia
    /// </summary>
    void StartStory()
    {
        _story = new Story(_inkJSONAsset.text);
        _story.BindExternalFunction("ShowCharacter", (string name, string position, string mood) => _characterManager.CreateCharacter(name, position, mood));
        _story.BindExternalFunction("HideCharacter", (string name) => _characterManager.HideCharacter(name));
        _story.BindExternalFunction("ChangeMood", (string name,string mood) => _characterManager.ChangeMood(name,mood));
        DisplayNextLine();

    }
    /// <summary>
    /// Muestra la siguiente linea de texto de la historia
    /// </summary>
    public void DisplayNextLine()
    {
        if (_story.canContinue)
        {
            string text = _story.Continue();
            text = text?.Trim();
            _textField.text = text;
            _textField.fontStyle = FontStyles.Italic;
        }
        else if (_story.currentChoices.Count>0)
        {
            DisplayChoices();
        }
    }
    private void DisplayChoices()
    {
        if (_choiceButtonsContainer.GetComponentsInChildren<Button>().Length > 0) return;
        for (int i=0;i<_story.currentChoices.Count;i++)
        {
            var choice = _story.currentChoices[i];
            var button = CreateChoiceButton(choice.text);
            button.onClick.AddListener(() => OnClickButtonChoice(choice));
        }
    }
    Button CreateChoiceButton(string text)
    {
        var choiceButton = Instantiate(_choiceButtonPrefab);
        choiceButton.transform.SetParent(_choiceButtonsContainer.transform,false);
        var buttonText = choiceButton.GetComponentInChildren<TMP_Text>();
        buttonText.text = text;

        return choiceButton;
    }
    void OnClickButtonChoice(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index);
        ClearChoices();
        _story.Continue();
        DisplayNextLine();

    }
    void ClearChoices()
    {
        if (_choiceButtonsContainer != null)
        {
            foreach (var button in _choiceButtonsContainer.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }
}
