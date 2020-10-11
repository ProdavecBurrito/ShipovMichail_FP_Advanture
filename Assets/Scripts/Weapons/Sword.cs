using UnityEngine;


namespace Shipov_FP_Adventure
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] private GameObject _weapon;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip[] _attackClips;
        [SerializeField] private AudioClip _drawSound;
        [SerializeField] private AudioClip _drawOffSound;
        private int _sound;

        public void SwordAttack()
        {
            _weapon.SetActive(true);
            _audioSource.clip = _attackClips[GetRandomSound()];
            _audioSource.Play();
        }

        public void StopSwordAttack()
        {
            _weapon.SetActive(false);
        }

        private int GetRandomSound()
        {
            return _sound = Random.Range(0, _attackClips.Length);
        }

        public void PlayDrawSound()
        {
            _audioSource.clip = _drawSound;
            _audioSource.Play();
        }

        public void PlayOffDrawSound()
        {
            _audioSource.clip = _drawOffSound;
            _audioSource.Play();
        }
    }
}
