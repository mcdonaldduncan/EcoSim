using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface ICreature
{
    SurvivalRequirement[] Needs { get; set; }
    CreatureState State { get; set; }
    string Species { get; set; }
    string Name { get; set; }
    int Age { get; set; }
    int PopulationMax { get; set; }
}