using UnityEngine;

public class FootSteps : MonoBehaviour
{
    
    public AudioClip stepOne;
    public AudioClip stepTwo;
    public AudioClip stepThree;
    public AudioClip stepFour;
    public AudioClip stepFive;
    public AudioClip stepSix;
    public AudioClip swordAttOne;
    public AudioClip swordAttTwo;
    public AudioClip swordAttThree;
    public AudioClip swordAttFour;
    public AudioClip heavyAttOne;
    public AudioClip heavyAttTwo;

    private AudioSource audioSource;
    //private TerrainDetector terrainDetector;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        //terrainDetector = new TerrainDetector();
    }

    private void Step()
    {
        AudioClip clip = GetRandomStep();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomStep()
    {
        

        switch((new System.Random()).Next(0,6))
        {
            case 0:
                return stepOne;
            case 1:
                return stepTwo;
            case 2:
                return stepThree;
            case 3:
                return stepFour;
            case 4:
                return stepFive;
            default:
                return stepSix;
        }
        
    }
    private void Sword()
    {
        AudioClip clip = GetRandomSwordSnd();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomSwordSnd()
    {

        if (!audioSource.gameObject.tag.Equals("Bruto") || !audioSource.gameObject.tag.Equals("Boss2") || (!audioSource.gameObject.tag.Equals("Player") && Inventory.selected != 3))
            switch ((new System.Random()).Next(0, 4))
            {
                case 0:
                    return swordAttOne;
                case 1:
                    return swordAttTwo;
                case 2:
                    return swordAttThree;
                default:
                    return swordAttFour;
            }
        else {
            switch ((new System.Random()).Next(0, 2))
            {
                case 0:
                    return heavyAttOne;
                default:
                    return heavyAttTwo;
            }
        }

    }
}