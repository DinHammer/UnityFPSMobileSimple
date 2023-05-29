using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected ScrBarrel _barrel;
    [SerializeField] protected BaseBullet _bullet;
    [SerializeField] protected float _coolDown;

    private ScrSrvBulletPool _srvBuletPool;

    public float CoolDown => _coolDown;
    public BaseBullet Bullet => _bullet;

    public void Init(ScrSrvBulletPool srvBuletPool)
    { 
        _srvBuletPool = srvBuletPool;
        Deactivate();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void DoShoot(Vector3 direction) 
    {
        BaseBullet bullet = _srvBuletPool.GetBullet(_bullet);
        bullet.Activation(direction.normalized, _barrel.ShootingPoint);
    }


}
