using System;

//Weight scales from 0 - 100

//Arm organs
class HumanUpperArmMuscle : OrganStats
{
    public HumanUpperArmMuscle()
    {
        Set(Creature_Stats.Arm_Strength, 70);
        Set(Creature_Stats.Manipulation, 10);
        Set(Creature_Stats.Mobility, 10);
    }
}
class HumanLowerArmMuscle : OrganStats
{
    public HumanLowerArmMuscle()
    {
        Set(Creature_Stats.Arm_Strength, 40);
        Set(Creature_Stats.Manipulation, 10);
        Set(Creature_Stats.Mobility, 10);
    }
}
class HumanFinger : OrganStats
{
    public HumanFinger()
    {
        Set(Creature_Stats.Manipulation, 20);
    }
}

//Leg Organs
class HumanThighMuscle : OrganStats
{
    public HumanThighMuscle()
    {
        Set(Creature_Stats.Leg_Strength, 50);
        Set(Creature_Stats.Core_Strength, 30);
        Set(Creature_Stats.Mobility, 40);
    }
}
class HumanShinMuscle : OrganStats
{
    public HumanShinMuscle()
    {
        Set(Creature_Stats.Leg_Strength, 40);
        Set(Creature_Stats.Mobility, 40);
    }
}
class HumanToe : OrganStats
{
    public HumanToe()
    {
        Set(Creature_Stats.Leg_Strength, 5);
        Set(Creature_Stats.Mobility, 10);
    }
}

//Torso based organs
class HumanLiver : OrganStats
{
    public HumanLiver()
    {
        Set(Creature_Stats.Immunity, 50);
        Set(Creature_Stats.Blood_Filtration, 70);
        this.isRequiredForLife = false;
    }
}
class HumanIntestine : OrganStats
{
    public HumanIntestine()
    {
        Set(Creature_Stats.Digestion, 50);
        this.isRequiredForLife = true;
    }
}
class HumanSpine : OrganStats
{
    public HumanSpine()
    {
        Set(Creature_Stats.Mobility, 100);
        Set(Creature_Stats.Mobility, 100);
        Set(Creature_Stats.Core_Strength, 60);
        this.isRequiredForLife = true;
    }
}

class HumanStomach : OrganStats
{

}
class HumanSpleen : OrganStats
{

}
class HumanLung : OrganStats
{

}
class HumanAirway : OrganStats
{

}
class HumanKidney : OrganStats
{

}
class HumanBladder : OrganStats
{

}

//Head
class HumanBrain : OrganStats
{

}
class HumanEye : OrganStats
{

}
class HumanEar : OrganStats
{

}
class HumanTounge : OrganStats
{

}
class HumanNose : OrganStats
{

}
class HumanJaw : OrganStats
{

}