//Arms
class UpperArm : Limb
{
    public UpperArm()
    {
        outwardConnectedLimbs = new Limb[1];
        outwardConnectedLimbs[0] = new LowerArm();
        containedOrgans = new OrganStats[1];
        containedOrgans[0] = new HumanUpperArmMuscle();
    }
}
class LowerArm : Limb
{
    public LowerArm()
    {
        outwardConnectedLimbs = new Limb[1];
        outwardConnectedLimbs[0] = new Hand();
        containedOrgans = new OrganStats[1];
        containedOrgans[0] = new HumanLowerArmMuscle();
    }
}
class Hand : Limb
{
    public Hand()
    {
        containedOrgans = new OrganStats[5];
        containedOrgans[0] = new HumanFinger();
        containedOrgans[1] = new HumanFinger();
        containedOrgans[2] = new HumanFinger();
        containedOrgans[3] = new HumanFinger();
        containedOrgans[4] = new HumanFinger();
    }
}

//Legs
class HumanThigh : Limb
{
    public HumanThigh()
    {
        outwardConnectedLimbs = new Limb[1];
        outwardConnectedLimbs[0] = new HumanShin();
        containedOrgans = new OrganStats[1];
        containedOrgans[0] = new HumanThighMuscle(); 
    }
}
class HumanShin : Limb 
{
    public HumanShin()
    {
        outwardConnectedLimbs = new Limb[1];
        outwardConnectedLimbs[0] = new HumanFoot();
        containedOrgans = new OrganStats[1];
        containedOrgans[0] = new HumanShinMuscle(); 
    }
}
class HumanFoot : Limb
{
    public HumanFoot()
    {
        containedOrgans = new OrganStats[5];
        containedOrgans[0] = new HumanToe(); 
        containedOrgans[1] = new HumanToe(); 
        containedOrgans[2] = new HumanToe(); 
        containedOrgans[3] = new HumanToe(); 
        containedOrgans[4] = new HumanToe(); 
    }
}

//Torso
class Torso : Limb
{

}

//head
class Head : Limb
{

}