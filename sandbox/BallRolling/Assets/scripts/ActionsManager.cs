using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionParameter
{
    public string ActionName;
    public int ActionSubType;
    public Vector3 VectorT;
    public Vector3 VectorR;
    public double Speed;
}

public abstract class MoveableObject
{
    public string Name;
}

public delegate void ActionDelegate( MoveableObject pObject, ActionParameter pActionParameter );

public class Creature : MoveableObject
{
    public Creature( string pName )
    {
        Name = pName;
    }

    // TODO: add special 
}

public class MoveableObjects
{
    public Dictionary<string, MoveableObject> Items;

    public void Add( string pName, MoveableObject pObject )
    {
        Items.Add(pName, pObject);
    }
}

public abstract class Action
{
    public abstract void Execute(MoveableObject pObjectName, ActionParameter pActionPara);
}

public class ActionRun : Action
{
    public ActionRun()
    {
        Name = "Run";
    }

    public string Name;

    public override void Execute(MoveableObject pObject, ActionParameter pActionPara)
    {
        // TODO: add the run action implementation
        // 1. get object's rigid body 
        // 2. get object's animation (from file)
        // 3. run the animation with the action parameter
    }
}

// TODO: create an object singleton class to store all the objects

public class ActionsManager
{
    private MoveableObjects ObjectsItems;    
    public Dictionary<string, ActionDelegate> ActionItems;

    public ActionsManager( ref MoveableObjects pActableDictionary )
    {
        // Initialize the dictionary of object
        ObjectsItems = pActableDictionary;
    }

    public void Add( string pName, ActionDelegate pActionDelegate )
    {
        ActionItems.Add(pName, pActionDelegate);
    }

    public void Execute( string pObjectName, string pActionName, ActionParameter pActionParameter )
    {
        MoveableObject lObject = ObjectsItems.Items[pObjectName];
        ActionDelegate lAction = ActionItems[pActionName];

        lAction(lObject, pActionParameter);
    }
}


public class Example : MonoBehaviour {

    Creature mMonsterDog;
    Creature mMonsterCat;
    MoveableObjects mObjects = new MoveableObjects();
    ActionsManager mActions;

    // Use this for initialization
    void Start () {
        mMonsterDog = new Creature("Monster Dog");
        mMonsterCat = new Creature("Monster Cat");

        // objects
        InitMoveableObjects();

        // actions
        mActions = new ActionsManager(ref mObjects);
        InitActions();
    }

    void InitMoveableObjects()
    {
        mObjects.Add(mMonsterDog.Name, mMonsterDog);
        mObjects.Add(mMonsterCat.Name,  mMonsterCat);
    }

    void InitActions()
    {
        MoveableObject lObject = new Creature("Lion");
        ActionRun lRun = new ActionRun();
        mActions.Add( lObject.Name, lRun.Execute );
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // get the action parameter
            ActionParameter lPara = new ActionParameter();
            lPara.ActionName = "Run";
            lPara.VectorT = new Vector3( 1, 0, 0 );
            lPara.Speed = 1.0;
            
            mActions.Execute( mMonsterDog.Name, "Run", lPara );
        }
    }
}
