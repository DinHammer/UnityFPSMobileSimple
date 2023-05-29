using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VmGameMain : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtHealth;
    [SerializeField] private Button _buttonExit;

    public void SetHealthText(float value)
    {
        _txtHealth.text = $"Çהמנמגüו: {value}";
    }

    private void OnEnable()
    {        
        _buttonExit.onClick.AddListener(OnButtonExitClicked);
    }

    private void OnDisable()
    {        
        _buttonExit.onClick.RemoveListener(OnButtonExitClicked);
    }

    private void OnButtonExitClicked()
    {
        SceneManager.LoadScene(0);
    }
}
