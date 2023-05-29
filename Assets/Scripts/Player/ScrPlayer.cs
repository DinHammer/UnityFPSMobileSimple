using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScrPlayer : MonoBehaviour
{
    [SerializeField] ScrPlayerInputs _playerInputs;
    [SerializeField] ScrPlayerMovement _playerMovement;    
    [SerializeField] ScrPlayerWeapons _playerWeapons;

    private StrInputSystemOut _inputSystemOut;
    private SoPlayer _soPlayer;

    private float _healthCurrent;

    public Vector3 CurrentPosition => transform.position;
    public UnityEvent<float> evntHelthChanged;
    //public UnityEvent evntPlayerDied;

    
    private void Update()
    {
        //Debug.Log(transform.forward);

        _inputSystemOut = _playerInputs.GetPlayerInputs();
        _playerMovement.Move(_inputSystemOut);       
        _playerWeapons.Manipulation(_inputSystemOut);
    }

    public void Init(SoPlayer soPlayer)
    {
        _soPlayer = soPlayer;
        _playerInputs.Init();
        _playerMovement.Init(soPlayer);
        _playerWeapons.Init();
        _healthCurrent = _soPlayer.Health;
        evntHelthChanged?.Invoke(_healthCurrent);
    }

    public void GetDamage(float damage)
    {
        _healthCurrent -= damage;

        evntHelthChanged?.Invoke(_healthCurrent);

        if (_healthCurrent <= 0)
        {
            //evntPlayerDied?.Invoke();
            SceneManager.LoadScene(0);
        }
    }

    
}
