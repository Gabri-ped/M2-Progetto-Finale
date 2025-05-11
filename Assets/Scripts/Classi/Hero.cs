using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Hero
{
    [SerializeField] private string name;
    [SerializeField] private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private ELEMENT resistance;
    [SerializeField] private ELEMENT weakness;
    [SerializeField] private Weapon weapon;

 public Hero(string name,int hp,Stats baseStats,ELEMENT resistance,ELEMENT weakness,Weapon weapon)
    {
        this.name = name;
        this.hp = hp;
        this.baseStats = baseStats;
        this.resistance = resistance;
        this.weakness = weakness;
        this.weapon = weapon;
    }
    public string GetName()
    {
        return name;
    }
    public int GetHP() 
    { 
        return hp;
    }
    public Stats GetBaseStats()
    {
        return baseStats;
    }
    public ELEMENT GetResistance()
    {
        return resistance;
    }
    public ELEMENT GetWeakness()
    {
        return weakness;
    }
    public Weapon Weapon 
    {
       get { return weapon; }  
       set => weapon = value;
    }
    private void SetName(string name)
    {
        this.name =name;
    }
    private void SetHp(int hp)
    {
        this.hp=hp;
    }
    private void SetBaseStats(Stats baseStats)
    {
        this.baseStats=baseStats;
    }
    private void SetResistance(ELEMENT resistance)
    {
        this.resistance=resistance;
    }
    private void SetWeakness(ELEMENT weakness)
    { 
        this.weakness=weakness; 
    }
    public void AddHp(int amount)
    {
        SetHp(this.hp += amount);
    }
    public void TakeDamage(int damage)
    {
        AddHp(-damage);
    }
    public bool IsAlive()
    {
        if(this.hp > 0) return true;
        return false;
    }










}

