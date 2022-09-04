using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace EnsignBandeng.DialogueSystem
{
    public class DialogueHandler : MonoBehaviour, IDialogueHandler
    {
        [SerializeField] DialogueGraph _target;
        [SerializeField] TextMeshProUGUI _textMesh;
        [SerializeField] bool _startImmediately = false;
        [SerializeField, Range(1, 100)] float _speed = 50f;
        public DialogueGraph TargetDialogueGraph { get => _target; set => _target = value; }

        public event Action<DialogueNode> LineNarrated;
        public event Action NarrationEnd;

        DialogueNode _current;
        bool _narrating = false;

        public void Start()
        {
            if (_startImmediately)
            {
                InitializeDialogue();
            }
        }

        public void InitializeDialogue()
        {
            _current = _target.GetFirstNode();
            NarrateLine();
        }

        public void InitializeDialogue(DialogueGraph dialogue)
        {
            _target = dialogue;
            InitializeDialogue();
        }

        public void NarrateLine()
        {
            if (_current.IsEnding) return;
            if (_narrating)
            {
                StopAllCoroutines();
                _textMesh.maxVisibleCharacters = _current.Line.Length;
                return;
            }
            StartCoroutine(Narrate(_current));
        }

        public void NarrateLine(int choiceIndex)
        {
            if (_current.IsEnding) return;
            if (_narrating)
            {
                StopAllCoroutines();
                _textMesh.maxVisibleCharacters = _current.Line.Length;
                _narrating = false;
                LineNarrated?.Invoke(_current);
                return;
            }
            _current = _current.AnswerDialogue(choiceIndex);
            StartCoroutine(Narrate(_current));
            if (_current.IsEnding)
            {
                NarrationEnd?.Invoke();
            }
        }

        IEnumerator Narrate(DialogueNode node)
        {
            var text = node.Line;
            _narrating = true;
            var length = text.Length;
            _textMesh.text = text;
            for (int i = 0; i < length; i++)
            {
                _textMesh.maxVisibleCharacters = i + 1;
                yield return new WaitForSeconds(1/_speed);
            }
            LineNarrated?.Invoke(_current);
            _narrating = false;
        }
    }

}