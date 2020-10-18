using UnityEngine;
using System.Collections.Generic;


namespace Shipov_FP_Adventure
{
    public sealed class Footsteps : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _audioClips = new List<AudioClip>();
        private AudioSource _audioClip;

        private int _random;
        private int _minSound = 0;
        private int _maxSound;

        private void Start()
        {
            _audioClip = GetComponent<AudioSource>();
            _maxSound = _audioClips.Count;
        }

        public void PlayStepSound()
        {
            _random = Random.Range(_minSound, _maxSound);
            _audioClip.clip = _audioClips[_random];
            _audioClip.Play();
        }
    }
}
