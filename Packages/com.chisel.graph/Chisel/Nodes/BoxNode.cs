using Chisel.Core;
using UnityEngine;

namespace Chisel.Nodes
{
    public class BoxNode : ChiselGraphNode
    {
        [Input] public Vector3 center;
        [Input] public Vector3 size = Vector3.one;

        public override CSGTreeNode GetNode()
        {
            var box = new ChiselBoxDefinition();
            box.center = GetInputValue("center", center);
            box.size = GetInputValue("size", size);

            var brushContainer = new ChiselBrushContainer();
            BrushMeshFactory.GenerateBox(ref brushContainer, ref box);

            var instance = BrushMeshInstance.Create(brushContainer.brushMeshes[0]);
            var treeNode = CSGTreeBrush.Create(GetInstanceID(), instance);

            return treeNode;
        }
    }
}