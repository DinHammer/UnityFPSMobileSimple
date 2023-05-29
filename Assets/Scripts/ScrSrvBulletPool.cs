using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ScrSrvBulletPool : MonoBehaviour
{
    [SerializeField] List<MdlBulletPoolItem> _bulletPool = new List<MdlBulletPoolItem>();
    List<BaseBullet> _items = new List<BaseBullet>();

    public int CountPool => _bulletPool.Count;
    public int CountItems => _items.Count;

    public void Init()
    {
        MdlBulletPoolItem poolItem = null;
        BaseBullet baseBullet = null;
        for (int i = 0; i < CountPool; i++)
        {
            poolItem = _bulletPool[i];
            for (int j = 0; j < poolItem.Count; j++)
            {
                baseBullet = Instantiate<BaseBullet>(poolItem.baseBullet, transform);
                baseBullet.Init();
                _items.Add(baseBullet);
            }
        }
    }

    public BaseBullet GetBullet<T>(T bulletIn) where T : BaseBullet 
    {
        T bulletOut = null;

        for (int i = 0; i < CountItems; i++)
        {
            if (_items[i].TryGetComponent<T>(out T bulletThis))
            {
                if (bulletThis.gameObject.activeSelf == false)
                {
                    bulletOut = bulletThis;
                    break;
                }
            }
        }

        return bulletOut;
    }

}

[Serializable]
public class MdlBulletPoolItem
{
    public BaseBullet baseBullet;
    public int Count;
}
