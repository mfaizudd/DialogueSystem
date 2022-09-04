using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

namespace EnsignBandeng.DialogueSystem
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/Dialogue")]
    public class DialogueGraph : NodeGraph
    {
        public DialogueNode NextNode(DialogueNode node, int index)
        {
            return node.AnswerDialogue(index);
        }

        public DialogueNode GetFirstNode()
        {
            return nodes.FirstOrDefault(x => x.Inputs.Any(y => !y.IsConnected)) as DialogueNode;
        }
    }
}