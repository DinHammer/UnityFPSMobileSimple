using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VmMenu : MonoBehaviour
{
    [SerializeField] private Button _buttonStart;
    [SerializeField] private Button _buttonExit;

    private void OnEnable()
    {
        _buttonStart.onClick.AddListener(OnButtonStartClicked);
        _buttonExit.onClick.AddListener(OnButtonExitClicked);
    }

    private void OnDisable()
    {
        _buttonStart.onClick.RemoveListener(OnButtonStartClicked);
        _buttonExit.onClick.RemoveListener(OnButtonExitClicked);
    }

    private void OnButtonStartClicked()
    {
        
        SceneManager.LoadScene(1);
    }

    private void OnButtonExitClicked()
    {
        Application.Quit();
    }
}
