using Const.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonster : MonoBehaviour
{
    private MdlMonsterData _mdlMonsterData = null;
    private ScrPlayer _player = null;

    public bool IsReleased { get; private set; }
    public TypeMonster Type => _mdlMonsterData.typeMonster;

    private float _health;
    private float _last_damage_cool_down = float.MinValue;

    public void Init(MdlMonsterData mdlMonsterData, ScrPlayer player)
    {
        _mdlMonsterData = mdlMonsterData;
        _player = player;

        Deactivate();
    }

    public void Activate(Vector3 position) 
    {
        gameObject.SetActive(true);
        IsReleased = true;
        transform.position= position;
        _health = _mdlMonsterData.Health;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        IsReleased = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<BaseBullet>(out BaseBullet baseBullet))
        {
            baseBullet.Deactivation();

            _health -= baseBullet.Damage;
        }

        if (_health <= 0)
        {
            Deactivate();
        }
    }

    private void Update()
    {
        if (IsReleased == true)
        {
            if (Vector3.Distance(transform.position, _player.CurrentPosition) <= _mdlMonsterData.AttackDistance)
            {
                if (_last_damage_cool_down + _mdlMonsterData.CoolDownAttack < Time.time)
                {
                    _last_damage_cool_down= Time.time;
                    _player.GetDamage(_mdlMonsterData.Damage);
                }
                
            }
            else
            {
                var step = _mdlMonsterData.Speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, _player.CurrentPosition, step);
            }
        }                        
    }

}
