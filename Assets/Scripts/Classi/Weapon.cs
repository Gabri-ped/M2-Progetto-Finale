using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Weapon
{
    [SerializeField] public enum DAMAGE_TYPE { PHYSICAL, MAGICAL }
    [SerializeField] private string name;
    [SerializeField] private DAMAGE_TYPE dmgType;
    [SerializeField] private ELEMENT elem;
    [SerializeField] private Stats bonusStats;

    public Weapon(string name, DAMAGE_TYPE dmgType, ELEMENT elem, Stats bonusStats)
    {
        this.name = name;
        this.dmgType = dmgType;
        this.elem = elem;
        this.bonusStats = bonusStats;
    }
    public string GetName() 
    { 
        return name;
    }
    public DAMAGE_TYPE GetdmgType()  
    { 
        return dmgType; 
    }
    public ELEMENT Getelem() 
    { 
        return elem; 
    }
    public Stats GetbonusStats() 
    {
        return bonusStats;
    }
    private void SetName(string name)
    { 
        this.name=name;
    }
    private void SetDmgType(DAMAGE_TYPE dmgType)
    {
        this.dmgType=dmgType;
    }
    private void SetElement(ELEMENT elem)
    {
        this.elem=elem;
    }
    private void SetBonusStats(Stats bonusStats)
    {
        this.bonusStats=bonusStats;
    }
}



    