using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.DialogeSystem.UI
{
    public class TypeWriterEffect : MonoBehaviour
    {
        [SerializeField] private float typewriterSpeed = 20f;
        public bool IsRunning { get; private set; }
        private Coroutine TypingCoroutine;

        private readonly List<Punctuation> punctuations = new List<Punctuation>()
        {
            new Punctuation(new HashSet<char> {'!', '.', '?'}, 0.6f),
            new Punctuation(new HashSet<char> {',', ';', ':'}, 0.3f)
        };

        public void Run(string textToType, TMP_Text textLabel)
        {
            if (TypingCoroutine != null)
                StopCoroutine(TypingCoroutine);
            TypingCoroutine = StartCoroutine(TypeText(textToType, textLabel));
        }

        public void Stop()
        {
            if (TypingCoroutine != null)
                StopCoroutine(TypingCoroutine);
            IsRunning = false;
        }

        private IEnumerator TypeText(string textToType, TMP_Text textLabel)
        {    
            textLabel.text = string.Empty;
            IsRunning = true;
            
            for (int i = 0; i < textToType.Length; i++)
            {
                textLabel.text += textToType[i];
                
                if (IsPunctuation(textToType[i], out float waitTime))
                    yield return new WaitForSeconds(waitTime);
                else
                    yield return new WaitForSeconds(1f / typewriterSpeed);
            }
            
            IsRunning = false;
        }

        private bool IsPunctuation(char c, out float waitTime)
        {
            foreach (var punctuation in punctuations)
            {
                if (punctuation.Punctuations.Contains(c))
                {
                    waitTime = punctuation.WaitTime;
                    return true;
                }
            }
            waitTime = 0;
            return false;
        }

        private readonly struct Punctuation
        {
            public readonly HashSet<char> Punctuations;
            public readonly float WaitTime;

            public Punctuation(HashSet<char> punctuations, float waitTime)
            {
                Punctuations = punctuations;
                WaitTime = waitTime;
            }
        }
    }
}