using System;
using System.Collections;
using System.Collections.Generic;

enum Creature_Stats
{
    //Five senses
    Sight,
    Taste,
    Smell,
    Hearing,
    Touch,
    
    //Gastro-intestinal System
    Mastication,
    Digestion,

    //Strength
    Arm_Strength,
    Core_Strength,
    Leg_Strength,
    
    //Manipulation
    Manipulation,
    
    //Brain Function
    Brain_Function,

    //Blood
    Blood_Filtration,
    Immunity,
    Clotting,

    //Movement
    Mobility,

    //Respiratory system
    Breathing,
    Oxygen_Exchange,

    //Talking
    Talking,


}
struct WeightValue
{
    public float Weight; //how important something is
    public float Efficiency; //how well something is performing compared to its max
    public WeightValue(float w, float e)
    {
        Weight = w;
        Efficiency = e;
    }
    public WeightValue(float w)
    {
        Weight = w;
        Efficiency = 1;
    }

    public static WeightValue Sum(WeightValue a, WeightValue b)
    {
        if(a.Weight ==0 && b.Weight == 0) return new WeightValue(0,1);
        float combinedEfficiency = (a.Efficiency * a.Weight + b.Efficiency * b.Weight) / (a.Weight + b.Weight);
        return new WeightValue(a.Weight + b.Weight, combinedEfficiency);
    }

    public override string ToString()
    {
        return $"{Weight}, {Efficiency}";
    }
}

class OrganStats
{
    protected Dictionary<Creature_Stats, WeightValue> stats;
    protected bool isRequiredForLife = false;
    public OrganStats()
    {
        stats = Populate();
    }
    public OrganStats(OrganStats o)
    {
        stats = o.stats;
    }

    public static OrganStats Sum(OrganStats a, OrganStats b)
    {
        OrganStats o = new OrganStats();
        foreach(Creature_Stats i in Enum.GetValues<Creature_Stats>())
        {
            WeightValue q = WeightValue.Sum(a.Get(i),b.Get(i)); 
            o.Set(i, q);
        }
        return o;
    }

    public static Dictionary<Creature_Stats,WeightValue> Populate()
    {
        Dictionary<Creature_Stats, WeightValue> toReturn = new Dictionary<Creature_Stats, WeightValue>();
        foreach(Creature_Stats i in Enum.GetValues<Creature_Stats>())
        {
            toReturn.Add(i, new WeightValue(0));
        }
        return toReturn;
    }

    public WeightValue Get(Creature_Stats key)
    {
        return stats[key];
    }
    public void Set(Creature_Stats key, WeightValue value)
    {
        stats[key] = value;
    }
    public void Set(Creature_Stats key, float value)
    {
        stats[key] = new WeightValue(value, 1);
    }

    public override string ToString()
    {
        return this.GetType().ToString();
    }
}

abstract class Limb
{
    //The limbs that are removed should the body part be removed (ie new Limb arm would contain new Limb hand)
    protected Limb[] outwardConnectedLimbs = new Limb[0]; 
    //organs the Limb contains (ie liver for torso)
    protected OrganStats[] containedOrgans = new OrganStats[0];
    //if removed, should the creature immediately die?
    protected bool isRequiredForLife = false;
    protected float durability = 70; //probabilty the Limb takes organ damage
    public int Mass = 100; //the probability that this limb is hit (number of hit tickets consumed)
    public OrganStats GetBranchStats()
    {
        OrganStats toReturn = GetMyStats();
        if(outwardConnectedLimbs.Length == 0)
        {
            return toReturn;
        }
        else
        {
            foreach(Limb l in outwardConnectedLimbs)
            {
                toReturn = OrganStats.Sum(toReturn, l.GetBranchStats());
            }
            return toReturn;
        }
    }
    public Limb GetRandomNextLimb()
    {
        if(this.outwardConnectedLimbs.Length == 0)
        {
            return null;
        }
        else
        {
            return outwardConnectedLimbs[new Random().Next(outwardConnectedLimbs.Length)];
        }
    }
    public OrganStats getRandomOrgan()
    {
        return containedOrgans[new Random().Next(containedOrgans.Length)];
    }
    public OrganStats GetMyStats()
    {
        OrganStats toReturn = new OrganStats();
        foreach(OrganStats o in containedOrgans)
        {
            toReturn = OrganStats.Sum(toReturn, o);
        }
        return toReturn;
    }
}
abstract class Creature
{
    protected Limb head; //The "head" of the object, the access point for the limb tree
    protected bool isAlive;
    protected OrganStats stats;
    public void calculateStats()
    {
        stats =  head.GetBranchStats();
    }
    public void die()
    {
        this.isAlive = false;
    }
    public String DisplayStats()
    {
        String toReturn = "";
        foreach(Creature_Stats o in Enum.GetValues<Creature_Stats>())
        {
            toReturn += o.ToString() +": " + stats.Get(o).Efficiency.ToString() + "\n";
        }
        return toReturn;
    }

    public OrganStats getRandomOrgan() //returns a reference to a random organ using the weighting system
    {
        //rolls for targets 
        Random r = new Random();
        int tickets = r.Next(9999);
        Limb currentTarget = this.head;
        while(true)
        {
            tickets -= currentTarget.Mass;
            //picks the next target
            if(tickets < 0)
            {
                return currentTarget.getRandomOrgan();
            }
            else
            {
                Limb nextTarget = currentTarget.GetRandomNextLimb();
                if(nextTarget == null)
                {
                    //overflows back to the head if the value is too large
                    currentTarget = this.head;
                }
                else
                {
                    currentTarget = nextTarget;
                }
            }
        }
    }
}
