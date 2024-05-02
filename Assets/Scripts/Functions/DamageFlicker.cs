using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DamageFlicker : MonoBehaviour
{
    [SerializeField] private Color _flickColor = Color.red;
    [SerializeField] private float _flickOnDuration = 0.2f;
    [SerializeField] private float _flickOffDuration = 0.1f;
    [SerializeField] private int _flickNumber = 3;

    private SpriteRenderer _spriteRenderer;
    private Color _initialColor;
    private bool _isPlaying = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _initialColor = _spriteRenderer.color;
    }

    public void Play()
    {
        if( !_isPlaying ) StartCoroutine( Flick() );
    }

    IEnumerator Flick()
    {
        _isPlaying = true;
        int i = 0;

        while ( i < _flickNumber )
        {
            _spriteRenderer.color = _flickColor;
            yield return new WaitForSeconds( _flickOnDuration );
            _spriteRenderer.color = _initialColor;
            yield return new WaitForSeconds( _flickOffDuration );
            i++;
        }
        _isPlaying = false;
    }
}
