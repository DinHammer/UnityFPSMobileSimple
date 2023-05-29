using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "MyScriptableObjects/PlayerData", order = 1)]
public class SoPlayer : ScriptableObject
{
    [SerializeField] float _speedRotation;
    [SerializeField] float _speedMove;
    [SerializeField] float _health;

    public float SpeedRotation => _speedRotation;
    public float SpeedMove => _speedMove;
    public float Health => _health;
}
