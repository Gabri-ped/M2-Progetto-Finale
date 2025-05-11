using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{
    public Hero a = new Hero("Tidus", 50, new Stats(5, 3, 4, 6, 2, 80, 19), ELEMENT.FIRE, ELEMENT.LIGHTNING, new Weapon("Spada", Weapon.DAMAGE_TYPE.PHYSICAL, ELEMENT.FIRE, new Stats(7, 5, 4, 6, 2, 84, 15)));
    public Hero b = new Hero("Seymour", 42, new Stats(8, 2, 6, 5, 1, 85, 14), ELEMENT.LIGHTNING, ELEMENT.NONE, new Weapon("Anima", Weapon.DAMAGE_TYPE.MAGICAL, ELEMENT.LIGHTNING, new Stats(10, 5, 2, 8, 1, 86, 16)));

    private Stats dannoTotaleA;
    private Stats dannoTotaleB;
    void Start()
    {
         dannoTotaleA = Stats.Sum(a.GetBaseStats(), a.Weapon.GetbonusStats());
         dannoTotaleB = Stats.Sum(b.GetBaseStats(), b.Weapon.GetbonusStats());

    }

    private void Attacco(Hero attacker, Hero defender,Stats attackerStats,Stats defenderStats)
    {
        Debug.Log(attacker.GetName() + " Sta Attacando " + defender.GetName());
        if(GameFormulas.HasHit(attackerStats,defenderStats))
        {
            if (GameFormulas.HasElementAdvantage(attacker.Weapon.Getelem(), defender))
                {
                Debug.Log("WEAKNESS");
                }
            if(GameFormulas.HasElementDisadvantage(attacker.Weapon.Getelem(), defender))
            {
                Debug.Log("RESIST");
            }
            int CalcoloDanno = GameFormulas.CalculateDamage(attacker, defender);
            defender.TakeDamage(CalcoloDanno);
            Debug.Log("il danno è di: " + CalcoloDanno);
            if(defender.IsAlive() == false)
            {
                Debug.Log("il nome del vincitore è " +  attacker.GetName());
            }
        }
    }
    void Update()
    {
        if(a.IsAlive()&& b.IsAlive())
        {
            if (dannoTotaleA.spd > dannoTotaleB.spd) // comincia a il turno
            {
                Attacco(a, b,dannoTotaleA,dannoTotaleB);
            if(b.IsAlive())
                {
                    Attacco(b, a,dannoTotaleB,dannoTotaleA);
                }
            
            }
            else // comincia b il turno 
            {
                Attacco(b ,a,dannoTotaleB,dannoTotaleA);
                if(a.IsAlive())
                {
                    Attacco(a, b,dannoTotaleA,dannoTotaleB);
                }
                
            }
        }
        else
        {
            return;
        }


        
    }
}
