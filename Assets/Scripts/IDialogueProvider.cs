using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnsignBandeng.DialogueSystem
{
    public interface IDialogueProvider
    {
        DialogueGraph TargetDialogue { get; set; }
    }
}