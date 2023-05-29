using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScrPlayerWeapons : MonoBehaviour
{
    [SerializeField] private List<PlayerWeaponItem> _weaponPool = new List<PlayerWeaponItem>();
    [SerializeField] private Transform _weaponPoint;
    [SerializeField] private ScrSrvBulletPool _srvBolletPool;

    private List<BaseWeapon> _weapons= new List<BaseWeapon>();

    private int CountWeapons => _weaponPool.Count;
    private int _currentWeaponIndex = 0;
    private float _last_shoot = float.MinValue;
    private BaseWeapon CurrentWeapon => _weapons[_currentWeaponIndex];

    public void Init()
    {
        PlayerWeaponItem weaponItem = null;
        BaseWeapon weapon = null;
        for (int i = 0; i < CountWeapons; i++)
        {
            weaponItem = _weaponPool[i];
            weapon = Instantiate<BaseWeapon>(weaponItem.weapon, _weaponPoint.position, Quaternion.identity, transform);
            weapon.Init(_srvBolletPool);
            _weapons.Add(weapon);
        }

        _weapons.First().Activate();
    }

    public void Manipulation(StrInputSystemOut inputSystemOut)
    {
        if (inputSystemOut.IsChangeWeapon == true)
        {
            ChangeWeapon();
        }

        if (inputSystemOut.IsShoot == true)
        {            
            DoShoot();
        }
    }

    private void ChangeWeapon()
    {
        _weapons[_currentWeaponIndex].Deactivate();

        _currentWeaponIndex++;
        if (_currentWeaponIndex == CountWeapons)
        {
            _currentWeaponIndex = 0;
        }

        _weapons[_currentWeaponIndex].Activate();
        _last_shoot = float.MinValue;
    }

    private void DoShoot()
    {

        if (_last_shoot + CurrentWeapon.CoolDown < Time.time)
        {
            _last_shoot = Time.time;

            Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

            CurrentWeapon.DoShoot(ray.direction);            
        }

    }
    
}

[Serializable]
class PlayerWeaponItem 
{
    public BaseWeapon weapon;
}
