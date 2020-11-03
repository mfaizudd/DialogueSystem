#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using XNode;

namespace EnsignBandeng.DialogueSystem
{
    [NodeWidth(300)]
    public class DialogueNode : Node
    {

        [Input(backingValue = ShowBackingValue.Never)]
        public string choice;

        [TextArea, SerializeField]
#if ODIN_INSPECTOR
        [HideLabel]
#endif
        private string line = "";

#if ODIN_INSPECTOR
        [TabGroup("Actor")]
        [AssetList]
#endif
        public CharacterInfo characterInfo;

        [Output(dynamicPortList = true)]
        public string[] choices;

        public string Line
        {
            get
            {
                return line;
            }
        }

        public void Narrate()
        {

        }

        public void FinishNarrating()
        {

        }

        public DialogueNode AnswerDialogue(int index)
        {
            if (choices.Length <= 0)
                return null;

            NodePort port = GetPort($"choices {index}");
            if (port.ConnectionCount <= 0)
                return null;

            DialogueNode nextNode = port.Connection.node as DialogueNode;
            return nextNode;
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }

#if UNITY_EDITOR
        [ContextMenu("Set as starting node")]
        public void SetAsStartingNode()
        {
            DialogueGraph graph = this.graph as DialogueGraph;
            graph.CurrentNode = this;
            EditorUtility.SetDirty(graph);
        }
#endif
    }
}