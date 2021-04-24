using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class NonNullTileRule : RuleTile<NonNullTileRule.Neighbor> {

    public class Neighbor : RuleTile.TilingRule.Neighbor {

    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        switch (neighbor) {
            case Neighbor.NotThis: return tile == null;
            case Neighbor.This: return tile != null;
        }
        return base.RuleMatch(neighbor, tile);
    }
}