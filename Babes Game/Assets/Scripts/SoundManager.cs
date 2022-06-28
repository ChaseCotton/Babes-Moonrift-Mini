using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip shootSound, enemyDie, enemyEnd, background, roundStart, loseSound;
    static AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        roundStart = Resources.Load<AudioClip>("start");
        shootSound = Resources.Load<AudioClip>("fire");
        background = Resources.Load<AudioClip>("back");
        enemyEnd = Resources.Load<AudioClip>("end");
        enemyDie = Resources.Load<AudioClip>("die");
        loseSound = Resources.Load<AudioClip>("lose");


        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "fire":
                audioSource.PlayOneShot(shootSound);
                break;
            case "start":
                audioSource.PlayOneShot(roundStart);
                break;
            case "back":
                audioSource.PlayOneShot(background);
                break;
            case "end":
                audioSource.PlayOneShot(enemyEnd);
                break;
            case "die":
                audioSource.PlayOneShot(enemyDie);
                break;
            case "lose":
                audioSource.PlayOneShot(loseSound);
                break;

        }
    }

}
