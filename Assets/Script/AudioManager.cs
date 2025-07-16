using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Sound Effects")]
    public AudioClip diamondSound;
    public AudioClip bombSound;
    public AudioClip timeBonusSound;
    public AudioClip enemyDeathSound;
    public AudioClip playerHurtSound;
    public AudioClip playerJumpSound;
    public AudioClip playerSideMoveSound;
    public AudioClip playerWalkingSound;
    public AudioClip playerIdleSound;

    [Header("Background Music")]
    public AudioClip backgroundMusic1;
    public AudioClip backgroundMusic2;
    public AudioClip backgroundMusic3;
    public AudioClip winMusic;
    public AudioClip loseMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (musicSource == null || sfxSource == null)
            {
                Debug.LogWarning("🎧 AudioSource belum diset di Inspector!");
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null && sfxSource != null)
            sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip music)
    {
        if (music != null && musicSource != null && musicSource.clip != music)
        {
            musicSource.clip = music;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    // Stop background music
    public void StopMusic()
    {
        musicSource.Stop();
    }

    // Shortcut SFX methods
    public void PlayDiamond() => PlaySound(diamondSound);
    public void PlayBomb() => PlaySound(bombSound);
    public void PlayTimeBonus() => PlaySound(timeBonusSound);
    public void PlayEnemyDeath() => PlaySound(enemyDeathSound);
    public void PlayPlayerHurt() => PlaySound(playerHurtSound);
    public void PlayPlayerJump() => PlaySound(playerJumpSound);
    public void PlayPlayerSideMove() => PlaySound(playerSideMoveSound);
    public void PlayPlayerWalking() => PlaySound(playerWalkingSound);
    public void PlayPlayerIdle() => PlaySound(playerIdleSound);

    // Shortcut music methods
    public void PlayBGM1() => PlayMusic(backgroundMusic1);
    public void PlayBGM2() => PlayMusic(backgroundMusic2);
    public void PlayBGM3() => PlayMusic(backgroundMusic3);
    public void PlayWinMusic() => PlayMusic(winMusic);
    public void PlayLoseMusic() => PlayMusic(loseMusic);
}
