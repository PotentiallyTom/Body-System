//Arms
class HumanUpperArm : Limb
{
    public HumanUpperArm()
    {
        outwardConnectedLimbs = new Limb[1];
        outwardConnectedLimbs[0] = new HumanLowerArm();
        containedOrgans = new OrganStats[1];
        containedOrgans[0] = new HumanUpperArmMuscle();
    }
}
class HumanLowerArm : Limb
{
    public HumanLowerArm()
    {
        outwardConnectedLimbs = new Limb[1];
        outwardConnectedLimbs[0] = new HumanHand();
        containedOrgans = new OrganStats[1];
        containedOrgans[0] = new HumanLowerArmMuscle();
    }
}
class HumanHand : Limb
{
    public HumanHand()
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

//HumanTorso
class HumanTorso : Limb
{
    public HumanTorso()
    {
        outwardConnectedLimbs = new Limb[4];
        outwardConnectedLimbs[0] = new HumanUpperArm();
        outwardConnectedLimbs[1] = new HumanUpperArm();
        outwardConnectedLimbs[2] = new HumanThigh();
        outwardConnectedLimbs[3] = new HumanThigh();

        containedOrgans = new OrganStats[11];
        containedOrgans[0] = new HumanSpleen();
        containedOrgans[1] = new HumanKidney();
        containedOrgans[2] = new HumanKidney();
        containedOrgans[3] = new HumanAirway();
        containedOrgans[4] = new HumanLung();
        containedOrgans[5] = new HumanLung();
        containedOrgans[6] = new HumanBladder();
        containedOrgans[7] = new HumanSpine();
        containedOrgans[8] = new HumanIntestine();
        containedOrgans[9] = new HumanLiver();
        containedOrgans[10] = new HumanStomach();
        isRequiredForLife = true;
    }
}

//head
class Head : Limb
{
    public Head()
    {
        outwardConnectedLimbs = new Limb[1];
        outwardConnectedLimbs[0] = new HumanTorso();

        containedOrgans = new OrganStats[8];
        containedOrgans[0] = new HumanBrain();
        containedOrgans[1] = new HumanEye();
        containedOrgans[2] = new HumanEye();
        containedOrgans[3] = new HumanEar();
        containedOrgans[4] = new HumanEar();
        containedOrgans[5] = new HumanTounge();
        containedOrgans[6] = new HumanNose();
        containedOrgans[7] = new HumanJaw();
        isRequiredForLife = true;
    }
}