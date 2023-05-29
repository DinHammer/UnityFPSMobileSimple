using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController _controller;
    [SerializeField] Transform _transformCamera;    

    private SoPlayer _soPlayer;

    public void Init(SoPlayer soPlayer)
    {
        _soPlayer= soPlayer;
    }
    public void Move(StrInputSystemOut inputSystemOut)
    {        

        Vector3 move = new Vector3(inputSystemOut.Direction.x, 0, inputSystemOut.Direction.y);
        move = move.x * _transformCamera.right.normalized + move.z * _transformCamera.forward.normalized;
        move.y = 0f;

        _controller.Move(move * Time.deltaTime * _soPlayer.SpeedMove);


        float targetAngle = _transformCamera.eulerAngles.y;
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _soPlayer.SpeedRotation * Time.deltaTime);
    }
}
