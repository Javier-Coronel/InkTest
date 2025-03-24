using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButtonScript : MonoBehaviour
{
    private InkManager _inkManager;
    // Start is called before the first frame update
    void Start()
    {
        _inkManager = FindAnyObjectByType<InkManager>();
        if (_inkManager == null)
        {
            Debug.LogError("No se encontro InkManager");
            return;
        }
        GetComponent<Button>().onClick.AddListener(onClick);
    }
    public void onClick()
    {
        _inkManager.DisplayNextLine();
    }
}
