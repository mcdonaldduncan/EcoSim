using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prey : MonoBehaviour, ICreature
{
    public SurvivalRequirement[] Needs { get; set; }
    public CreatureState State { get; set; }
    public string Species { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int PopulationMax { get; set; }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
