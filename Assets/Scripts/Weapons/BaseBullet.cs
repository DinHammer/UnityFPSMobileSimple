using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _damage = 5;
    [SerializeField] private float _speed = 10;    

    public bool IsReleased { get; private set; }
    public float Damage => _damage;
    protected Vector3 prtDirection;    

    private void Update()
    {
        if (IsReleased)
        {            
            _rb.velocity = prtDirection * _speed;
        }
    }

    public void Init()
    {
        gameObject.SetActive(false);
    }

    public virtual void Activation(Vector3 direction, Vector3 position)
    {
        transform.position = position;
        IsReleased = true;
        prtDirection = direction;
        gameObject.SetActive(true);
    }

    public virtual void Deactivation()
    {
        IsReleased = false;
        gameObject.SetActive(false);
    }
}
