using UnityEngine;
using System.Collections.Generic;
using System;

namespace Shipov_FP_Adventure
{
    public sealed class MusicChanger : MonoBehaviour
    {

        [SerializeField] private List<AudioClip> _audioClips;
        [SerializeField] private AudioSource _musicSource;
        private AudioClip _neededClip;
        private bool _isVolumeToLow;
        private bool _isMusicChange;
        public float _musicChangeTime;
        public float _currentMusicChangeTime;
        public float _currentVolumeUpTime;
        public float _currentMaxVol;

        private void Start()
        {
            _currentMusicChangeTime = 0.0f;
            _currentVolumeUpTime = 0.0f;
        }

        private void Update()
        {
            CheckMusicChange();
            ChangeMaxVol();
        }

        public void BattleMusic()
        {
            _isMusicChange = true;
            _neededClip = _audioClips[2];
        }

        public void VillageMusic()
        {
            _isMusicChange = true;
            _neededClip = _audioClips[1];
        }

        public void CalmMusic()
        {
            _isMusicChange = true;
            _neededClip = _audioClips[0];
        }

        private void CheckMusicChange()
        {
            if (_isMusicChange)
            {
                if (_currentMusicChangeTime < _musicChangeTime)
                {
                    _currentMusicChangeTime += Time.deltaTime;
                    _musicSource.volume -= Time.deltaTime;
                }
                else
                {
                    _currentMusicChangeTime = 0.0f;
                    _isMusicChange = false;
                    _musicSource.clip = _neededClip;
                    _musicSource.Play();
                    _isVolumeToLow = true;
                }

            }

            if (_isVolumeToLow)
            {
                if (_currentVolumeUpTime < _musicChangeTime)
                {
                    _currentVolumeUpTime += Time.deltaTime;
                    _musicSource.volume += Time.deltaTime;
                }
                else
                {
                    if (_musicSource.volume != _currentMaxVol)
                    {
                        _musicSource.volume = _currentMaxVol;
                       
                    }
                    _isVolumeToLow = false;
                    _currentVolumeUpTime = 0.0f;
                }
            }
        }

        private void ChangeMaxVol()
        {
            if (_currentMaxVol != _musicSource.volume)
            {
                _currentMaxVol = _musicSource.volume;
            }
        }
    }
}
