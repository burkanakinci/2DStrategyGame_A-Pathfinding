using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBorder<T>
{
    SpriteRenderer spriteRenderer { get; set; }
    T nodesInBorder { get; set; }
    bool canBuild { get; set; }
    T NotWalkable(int x, int y);
    void Move(int x, int y);
}
