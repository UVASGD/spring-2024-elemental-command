using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILogicReceiver
{
    //Objects likely should also have a list of LogicElements that power it
    public void UpdateLogic();
    //Look into ElementPowerer or Door to see how to implement this, lowkey should be done
    //different but its too late now
}
