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

        public Dictionary<string, string> Tokens { get; private set; } = new Dictionary<string, string>();

        public DialogueNode CurrentNode
        {
            get
            {
                if (!initialized)
                {
                    Debug.LogWarning("Graph not initialized");
                }
                return currentNode;
            }
            set => currentNode = value;
        }

        private DialogueNode currentNode = null;

        private bool initialized = false;

        public void NextNode(int index)
        {
            currentNode = currentNode.AnswerDialogue(index);
        }

        public void Init()
        {
            DialogueNode firstNode = nodes.FirstOrDefault(x => x.Inputs.Any(y => !y.IsConnected)) as DialogueNode;
            currentNode = firstNode;
            initialized = true;
        }
    }
}