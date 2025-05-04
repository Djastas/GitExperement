using System;
using System.Collections.Generic;
using UnityEngine;

namespace CorpKaktus.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimator : MonoBehaviour
    {
        [SerializeField] private List<Sprite> sprites = new();
        [SerializeField] private float timeForFrame;


        private float _counter;
        private int _currentFrame = 0;
        private SpriteRenderer _sr;

        private void Start()
        {
            _sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (_currentFrame >= sprites.Count) { _currentFrame = 0; }
            
            _sr.sprite = sprites[_currentFrame];
            _counter += Time.deltaTime;

            if (_counter > timeForFrame)
            {
                _currentFrame++;
                _counter = 0;
            }
           
        }
    }
}