using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrRootGame : MonoBehaviour
{    
    [SerializeField] private ScrSrvBulletPool _srvBooletPool;
    [SerializeField] private ScrPlayer _player;
    [SerializeField] private ScrMonsterSpawner _monsterSpawner;
    [SerializeField] private SoMonsters _soMonsters;
    [SerializeField] private SoPlayer _soPlayer;

    private void Start()
    {

        /*Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;*/
        
        _srvBooletPool.Init();
        _player.Init(_soPlayer);
        _monsterSpawner.Init(_soMonsters);
    }
}
