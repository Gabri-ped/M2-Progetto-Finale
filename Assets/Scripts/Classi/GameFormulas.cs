using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

  static class GameFormulas
{
     public static bool HasElementAdvantage(ELEMENT attackElement, Hero defender)
    {
        if (attackElement == defender.GetWeakness())
        {
            return true;
        }
        return false;
    }
    public static bool HasElementDisadvantage(ELEMENT attackElement, Hero defender)
    {
        if (attackElement == defender.GetResistance())
        {
            return true;
        }
        return false;
    }
     public static float EvaluateElementModifier(ELEMENT attackElement, Hero defender)
    {
        if (!HasElementAdvantage(attackElement, defender))
        {
            return 1.5f;
        }
        else if (!HasElementDisadvantage(attackElement, defender))
        {
            return 0.5f;
        }
        else
            return 1f;
    }
     public static bool HasHit(Stats attacker, Stats defender)
    {
        int hitChance = attacker.aim - defender.eva;
        if (hitChance < Random.Range(0, 100))
        {
            Debug.Log("Miss");
            return false;
        }
        return true;
    }
    public  static bool IsCrit(int critValue)
    {
        if (critValue <= Random.Range(0, 100))
        {
            return true;
        }
        return false;
    }
    public static int CalculateDamage(Hero attacker, Hero defender)
    {
        Stats AttHero = Stats.Sum(attacker.GetBaseStats(), attacker.Weapon.GetbonusStats());
        Stats DefHero = Stats.Sum(defender.GetBaseStats(), defender.Weapon.GetbonusStats());
        int def;
        if (attacker.Weapon.GetdmgType() == Weapon.DAMAGE_TYPE.PHYSICAL)
        {
            def = DefHero.def;
        }
        else
        {
            def = DefHero.res;
        }
        int damage = AttHero.atk - def;
        float dannoModificato = (EvaluateElementModifier(attacker.Weapon.Getelem(), defender)) * damage;
        if (IsCrit(attacker.GetBaseStats().crt))
        {
            dannoModificato *= 2;
        }
        if (dannoModificato > 0)
        {
            return(int) dannoModificato;
        }
        else
        {
            dannoModificato = 0;
            return(int) dannoModificato;
        }

    }

}

