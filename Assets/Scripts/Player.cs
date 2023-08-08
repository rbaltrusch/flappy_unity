using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D bird;
    [SerializeField] private List<AudioSource> jumpSounds;
    [SerializeField] private AudioSource pickupSound;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private AudioSource fallSound;
    [SerializeField] private AudioSource explodeSound;
    [SerializeField] private float fallSoundFadeDuration;
    [SerializeField] private float fallSoundVolume;
    [SerializeField] private float speed;
    [SerializeField] private float explodeY;

    private int score;
    private bool alive;
    private bool exploded;

    public delegate void ScoreIncreaseHandler(object sender, ScoreIncreaseArgs e);
    public event ScoreIncreaseHandler ScoreIncrease = delegate{};
    private void OnScoreIncrease() => ScoreIncrease(this, new ScoreIncreaseArgs(this.score));

    public delegate void DeathHandler(object sender, EventArgs e);
    public event DeathHandler DeathEvent = delegate{};
    private void OnDeathEvent() => DeathEvent(this, new EventArgs());

    private void Start()
    {
        alive = true;
        exploded = false;
        score = 0;
    }

    private void Update()
    {
        if (!exploded && transform.position.y < explodeY)
        {
            exploded = true;
            Die();
            fallSound.Stop();
            explodeSound.Play();
        }

        if (Input.GetKeyDown("space") && alive)
        {
            bird.velocity = Vector2.up * speed;
            RandUtil.Choice(jumpSounds)?.Play();
        }
    }

    public void AddPoints(int amount)
    {
        if (!alive)
        {
            return;
        }
        score += amount;
        OnScoreIncrease();
        pickupSound.Play();
        Debug.Log(string.Format("score: {0}", score));
    }

    public void Kill()
    {
        hitSound.Play();
        if (!exploded && !fallSound.isPlaying)
        {
            fallSound.Play();
            StartCoroutine(FadeAudio.StartFade(fallSound, fallSoundFadeDuration, fallSoundVolume));
        }
        Die();
        //bird.velocity = Vector2.zero;
    }

    private void Die()
    {
        alive = false;
        Debug.Log("died");
        OnDeathEvent();
    }
}
