using Const.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "MyScriptableObjects/MonsterData", order = 1)]
public class SoMonsters : ScriptableObject
{
    [SerializeField] private List<MdlMonsterData> _items= new List<MdlMonsterData>();

    public int Count => _items.Count;

    public MdlMonsterData GetDataByType(TypeMonster typeMonster)
        => _items.Where(x => x.typeMonster == typeMonster).FirstOrDefault();

    public TypeMonster GetNextMonsterType()
    {
        int index = UnityEngine.Random.Range(0, Count);
        TypeMonster typeMonster = (TypeMonster)index;
        return typeMonster;
    }
}

[Serializable]
public class MdlMonsterData
{
    public TypeMonster typeMonster;
    public int Health;
    public int Damage;
    public int Speed;
    public float CoolDownAttack;
    public float AttackDistance;    
}
