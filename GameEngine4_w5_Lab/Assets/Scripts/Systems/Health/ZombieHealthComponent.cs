using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.Health;

public class ZombieHealthComponent : HealthComponent
{
    private StateMachine ZombieStateMachine;
    // Start is called before the first frame update
    void Awake()
    {
        ZombieStateMachine = GetComponent<StateMachine>();
    }

    public override void Destroy()
    {
        ZombieStateMachine.ChanceState(ZombieStateType.Dead);
    }
}
