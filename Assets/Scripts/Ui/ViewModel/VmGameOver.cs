using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class VmGameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text _textHeader;
    [SerializeField] private Button _buttonRestart;
    [SerializeField] private Button _buttonExit;

    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void OnEnable()
    {        
        _buttonRestart.onClick.AddListener(OnButtonRestartClicked);
        _buttonExit.onClick.AddListener(OnButtonExitClicked);
    }

    private void OnDisable()
    {        
        _buttonRestart.onClick.RemoveListener(OnButtonRestartClicked);
        _buttonExit.onClick.RemoveListener(OnButtonExitClicked);
    }

    public void GameOver()
    {
        _textHeader.text = "Гамовер";
        _canvasGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnButtonRestartClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    private void OnButtonExitClicked()
    {
        SceneManager.LoadScene(0);
    }
}
