using UnityEngine;

namespace FactoryMethod
{
    public abstract class _BuildFactory<T>
    {
        public abstract GameObject build { get; }
        public abstract Transform buildParent { get; }
        public abstract void SpawnBuild(Vector3 spawnPos, T notWalkableNode);

    }
}
