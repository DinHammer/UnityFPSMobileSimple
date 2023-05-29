using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPlayerInputs : MonoBehaviour
{
    private GameInputs _inputs;
    private Vector2 _direction;
    private Vector2 _look;
    private bool _isShoot;
    private bool _isChangeWeapon;

    public void Init()
    {
        _inputs = new GameInputs();
        _inputs.Enable();
    }

    public StrInputSystemOut GetPlayerInputs()
    {
        _direction = _inputs.Main.Move.ReadValue<Vector2>();
        _look = _inputs.Main.Look.ReadValue<Vector2>();

        _isShoot = false;
        if (_inputs.Main.Shoot.triggered)
        {
            _isShoot = true;
        }

        _isChangeWeapon= false;
        if (_inputs.Main.ChangeWeapon.triggered)
        {
            _isChangeWeapon = true;
        }

        return new StrInputSystemOut(_direction, _look, _isShoot, _isChangeWeapon);
    }
}
