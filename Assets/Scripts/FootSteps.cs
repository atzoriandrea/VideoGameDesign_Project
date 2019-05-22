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
    public AudioClip eat, drink, jump, pick;
    private Transform player;
    float distVolume;
    float distance;
    private AudioSource audioSource;
    //private TerrainDetector terrainDetector;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Character_Hero_Knight_Male").transform;
        //terrainDetector = new TerrainDetector();
    }

    //Suono dei passi
    private void Step()
    {
        AudioClip clip = GetRandomStep();
        if (!gameObject.name.Equals("Character_Hero_Knight_Male")) {
            distance = Vector3.Distance(transform.position, player.position);
            if (distance <= 6)
                distVolume = 1;
            else if (distance > 6 && distance <= 12)
                distVolume = 0.7f;
            else if (distance > 12 && distance <= 18)
                distVolume = 0.3f;
            else if (distance > 18)
                distVolume = 0;
            audioSource.PlayOneShot(clip,distVolume);
        }
        else
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

    //suono dell'attacco (non dell'impatto con il nemico)
    private void Sword()
    {
        AudioClip clip = GetRandomSwordSnd();
        audioSource.PlayOneShot(clip,0.1f);
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

    //suono cure: mele e pozioni
    private void Eat()
    {
        if (Inventory.selected == 5)
            audioSource.PlayOneShot(eat, 0.6f);
        if (Inventory.selected == 4)
            audioSource.PlayOneShot(drink, 1);
    }
    private void Jump() { //suono salto
        audioSource.PlayOneShot(jump);
    }
    private void Pick() //Suono raccolta
    {
        audioSource.PlayOneShot(pick);
    }
}