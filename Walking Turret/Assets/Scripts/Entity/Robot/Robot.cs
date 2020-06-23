using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Entity
{
    protected override EntityController GetController() {
        return new RobotController();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
