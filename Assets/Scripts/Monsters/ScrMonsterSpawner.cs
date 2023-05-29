using Const.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class ScrMonsterSpawner : MonoBehaviour
{
    [SerializeField] List<MdlMonsterItem> _monsterPool = new List<MdlMonsterItem>();
    [SerializeField] int DefaultMonsterCountByType = 100;
    [SerializeField] ScrPlayer _player;
    [SerializeField] private Transform _spawnArea;
    [SerializeField] private Vector2 delay = new Vector2(2, 3);

    private List<MdlMonsterItem> _items = new List<MdlMonsterItem>();
    private SoMonsters _soMonster;

    public int Count => _monsterPool.Count;
    //private float CurrentDelay { get; set; }
    private float _last_spawn = float.MinValue;
    private float _coolDown = 0f;

    public void Init(SoMonsters soMonsters)
    {
        _soMonster = soMonsters;
        MdlMonsterItem mdlMonsterItem = null;
        BaseMonster baseMonster = null;
        for (int i = 0; i < Count; i++)
        { 
            mdlMonsterItem = _monsterPool[i];
            for (int j = 0; j < DefaultMonsterCountByType; j++)
            {
                baseMonster = Instantiate<BaseMonster>(mdlMonsterItem.baseMonster, transform);
                baseMonster.Init(soMonsters.GetDataByType(mdlMonsterItem.typeMonster), _player);
                _items.Add(new MdlMonsterItem(baseMonster, mdlMonsterItem.typeMonster));
            }
        }

        InstantiateMonster();
        _coolDown = GetNextCooldown();
    }

    public void InstantiateMonster()
    {
        TypeMonster typeMonster = _soMonster.GetNextMonsterType();

        MdlMonsterItem mdlMonsterItem = _items.Where(x => x.baseMonster.Type == typeMonster && x.baseMonster.IsReleased == false).First();
        float coordX = UnityEngine.Random.Range(0, _spawnArea.localScale.x);
        float coordZ = UnityEngine.Random.Range(0, _spawnArea.localScale.z);
        mdlMonsterItem.baseMonster.Activate(new Vector3(coordX, 1, coordZ));
    }

    private void Update()
    {
        if (_last_spawn + _coolDown < Time.time)
        {
            _last_spawn = Time.time;
            _coolDown = GetNextCooldown();
            InstantiateMonster();
        }
    }

    private float GetNextCooldown()
        => UnityEngine.Random.Range(delay[0], delay[1]);
    
}

[Serializable]
public class MdlMonsterItem
{
    public MdlMonsterItem() { }
    public MdlMonsterItem(BaseMonster baseMonster, TypeMonster typeMonster) 
    {
        this.baseMonster= baseMonster;
        this.typeMonster= typeMonster;
    }

    public BaseMonster baseMonster;
    public TypeMonster typeMonster;
}
