using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnsignBandeng.DialogueSystem
{
    public interface IDialogueHandler
    {
        DialogueGraph TargetDialogueGraph { get; set; }
        event Action NarrationEnd;
        void InitializeDialogue();
        void InitializeDialogue(DialogueGraph dialogue);
        void NarrateLine(int choiceIndex = 0);
    }
}