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
        private string _line = "";

        [SerializeField]
        private CharacterInfo _characterInfo;

        [Output(dynamicPortList = true)]
        public string[] _choices;

        public string Line => _line;

        public bool IsEnding => _choices.Length <= 0;

        public DialogueNode AnswerDialogue(int index)
        {
            if (IsEnding)
                return null;

            NodePort port = GetPort($"_choices {index}");
            if (port.ConnectionCount <= 0)
                return null;

            DialogueNode nextNode = port.Connection.node as DialogueNode;
            return nextNode;
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}