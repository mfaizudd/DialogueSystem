using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnsignBandeng.DialogueSystem
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Dialogue/Character Info")]
    public class CharacterInfo : ScriptableObject
    {
        public Sprite CharacterSprite { get => characterSprite; }
        public Color Tint { get => tint; }
        public string CharacterName { get => characterName; }


        [SerializeField]
        private Sprite characterSprite = null;

        [SerializeField]
        private Color tint = Color.white;

        [SerializeField]
        private string characterName = null;
    }
}