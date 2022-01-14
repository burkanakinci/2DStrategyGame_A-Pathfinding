using UnityEngine;

namespace FactoryMethod
{
    public class SoldierFactory : _BuildFactory<PathNode>
    {
        public override GameObject build => Resources.Load<GameObject>("Prefabs/SoldierUtil");
        public override Transform buildParent => GameObject.FindGameObjectWithTag("SoldierParent").transform;
        public override void SpawnBuild(Vector3 spawnPos, PathNode notWalkableNode)
        {
            notWalkableNode.SetIsWalkable(false);
            Transform.Instantiate(build, spawnPos, Quaternion.identity, buildParent);
        }
    }
}
