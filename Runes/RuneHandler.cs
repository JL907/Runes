using RoR2;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;

namespace RunesPlugin
{
    public class RuneHandler : MonoBehaviour
    {
        [FormerlySerializedAs("Keystone")]
        public GenericSkill keyStone;

        public void Awake()
        {
        }
    }
}
