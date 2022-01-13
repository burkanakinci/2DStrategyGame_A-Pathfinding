using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryMethod
{
    public abstract class _BuildFactory
    {
        public abstract GameObject build { get; }
        public abstract Transform buildParent { get; }
        public abstract void SpawnBuild(Vector3 spawnPos, List<PathNode> notWalkableNode);
        
    }
}
