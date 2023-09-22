using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;

    private Coroutine _activeCoroutine;
    private bool _isInside;

    private float _stepVolume = 0.1f;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private float _finalVolume;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource.volume = 0;
    }

    public void StartSound()
    {
        _isInside = true;
        _finalVolume = _maxVolume;
        _audioSource.Play();
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    public void StopSound()
    {
        _isInside = false;
        _finalVolume = _minVolume;
        _audioSource.Play();
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    public void ChangeColor()
    {
        _spriteRenderer.color = _isInside ? Color.red : Color.green;
    }

    private IEnumerator ChangeVolume()
    {
        while(_audioSource.volume != _finalVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _finalVolume, _stepVolume * Time.deltaTime);
            yield return null;
        }
    }
}
