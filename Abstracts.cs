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
    private float Weight; //how important something is
    float Efficiency; //how well something is performing compared to its max
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

    public static WeightValue sum(WeightValue a, WeightValue b)
    {
        return new WeightValue(a.Weight + b.Weight, a.Efficiency + b.Efficiency);
    }
}

class OrganStats
{
    private Dictionary<Creature_Stats, WeightValue> stats;
    protected bool isRequiredForLife = false;
    public OrganStats()
    {
        stats = Populate();
    }
    public OrganStats(OrganStats o)
    {
        stats = o.stats;
    }
    public OrganStats(OrganStats a, OrganStats b)
    {
        foreach(Creature_Stats i in Enum.GetValues<Creature_Stats>())
        {
            WeightValue q = WeightValue.sum(a.Get(i),b.Get(i));
            stats.Add(i, q);
        }
    }

    public static Dictionary<Creature_Stats,WeightValue> Populate()
    {
        Dictionary<Creature_Stats, WeightValue> toReturn = new Dictionary<Creature_Stats, WeightValue>();
        foreach(Creature_Stats i in Enum.GetValues<Creature_Stats>())
        {
            toReturn.Add(i, new WeightValue());
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
}

abstract class Limb
{
    //The limbs that are removed should the body part be removed (ie new Limb arm would contain new Limb hand)
    protected Limb[] outwardConnectedLimbs = new Limb[0]; 
    //organs the Limb contains (ie liver for torso)
    protected OrganStats[] containedOrgans = new OrganStats[0];
    //if removed, should the creature immediately die?
    protected bool isRequiredForLife = false;
    protected float durability = 70;
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
                toReturn = new OrganStats(toReturn, l.GetBranchStats());
            }
            return toReturn;
        }
    }
    public OrganStats GetMyStats()
    {
        OrganStats toReturn = new OrganStats();
        foreach(OrganStats o in containedOrgans)
        {
            toReturn = new OrganStats(toReturn, o);
        }
        return toReturn;
    }
}
abstract class Creature
{
    private Limb head; //The "head" of the object, the access point for the limb tree
    private bool isAlive;
    private OrganStats stats;
    abstract public OrganStats calculateStats();
    abstract public void die();
}
