using System.IO;
using UnityEngine;


using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float _speed;
    private readonly float _gravity = -9.8f;
    public float JumpForce;
    private bool _crouch;
    public bool attacking;
    public Player player;
    private float _firstHealt;
    private float _firstExperience;
    private CharacterController _charCont;
    Vector3 movement;
    public GameObject wall1, wall2, wall3;
    float deltaX, deltaZ;
    private int _healthText;
    private int _experienceText;
    public Text healthText;
    public Text experienceText;
    public Text arrowsText, potionsText, applesText;
    Animator anim;
    public AudioClip denied;
    public Sword sword;
    [HideInInspector]
    public int worth = 50;
    [Header("HealthBar")]
    public Image healthBar;
    [Header("ExperienceBar")]
    public Image experienceBar;
    // Use this for initialization
    void Start()
    {
       
        _charCont = GetComponent<CharacterController>();
        JumpForce = 5.0f;
        _speed = 2f;
        _firstHealt = player.maxHealth;
        _firstExperience = player.limitExperience;
        _crouch = false;
        anim = GetComponent<Animator>();
        attacking = false;
    }
    void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        PrintHealthAndExperience();

        Print_Arrows_Potions_Apples_Quantity();

        if (Input.GetKeyDown(KeyCode.C)) {
            _crouch = !_crouch;
            anim.SetBool("crouch", _crouch);
        }
    
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("schivata");
        }


        //if (_charCont.isGrounded)
        //{
        deltaX = Input.GetAxis("Horizontal") * _speed;
        deltaZ = Input.GetAxis("Vertical") * _speed;
        //camminata avanti
        if ((deltaZ > 0) && !Input.GetKey(KeyCode.LeftShift))
        {
            if (!_crouch)
            {
                anim.SetBool("walkback", false);
                anim.SetBool("walking", true);
            }
            else 
            {
                anim.SetBool("crouchwalk", true);
            }
        }
        //camminata indietro
        else if ((deltaZ < 0) && !Input.GetKey(KeyCode.LeftShift))
        {
            if (!_crouch)
            {
                anim.SetBool("walkback", true);
                anim.SetBool("walking", false);
            }
            else {
                anim.SetBool("crouchback", true);
            }
        }
        //fermo
        else
        {
            anim.SetBool("crouchback", false);
            anim.SetBool("crouchwalk", false);
            anim.SetBool("walking", false);
            anim.SetBool("walkback", false);
        }
        movement = new Vector3(deltaX, movement.y, deltaZ);//Vettore movimento
        movement = transform.TransformDirection(movement);
        //corsa avanti
        if (Input.GetKey(KeyCode.Space) && deltaZ >= 0 && movement.y < _gravity)
        {
            movement.y = JumpForce;
        }
        //corsa indietro
        else if (Input.GetKey(KeyCode.Space) && deltaZ < 0) {
            movement.y = JumpForce;
        }
        //}
        
        movement.y += _gravity * Time.deltaTime;
        //ferma salto
        if (_charCont.isGrounded && !Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("jump", false);
            //anim.SetBool("jumpback", false);
        }
        _charCont.Move(movement * Time.deltaTime);
        //Corsa in avanti
        if (Input.GetKey(KeyCode.LeftShift) &&  deltaZ >= 0)
        {
            _crouch = false;
            anim.SetBool("crouch",false);
            anim.SetBool("crouchback", false);
            anim.SetBool("crouchwalk", false);
            anim.SetBool("walkback", false);
            anim.SetBool("runback", false);
            anim.SetBool("walking", false);
            anim.SetBool("running", true);
            _speed = 4.5f;
        }
        //Corsa all'indietro
        if (Input.GetKey(KeyCode.LeftShift) && deltaZ < 0)
        {
            _crouch = false;
            anim.SetBool("crouch", false);
            anim.SetBool("crouchback", false);
            anim.SetBool("crouchwalk", false);
            anim.SetBool("running", false);
            anim.SetBool("walking", false);
            anim.SetBool("walkback", false);
            anim.SetBool("runback", true);
            _speed = 3.5f;
        }
        //fine corsa
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("runback", false);
            anim.SetBool("running", false);
            _speed = 2f;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("sword_att")) {
            attacking = true;
        }
        else
        {
            attacking = false;
        }

        if(player.experience >= player.limitExperience)
        {
            float tempExp = player.limitExperience;
            player.level++;
            player.limitExperience += 10;
            player.experience = player.experience - tempExp;

        }

        _firstExperience = GetFirstExperience();
        _experienceText = GetFCurrentExperience();
    }

    public void TakeDamage (float amount)
    {
        player.health -= amount;
        healthBar.fillAmount = player.health / 100f;
        
        if (player.health <= 0)
        {
            anim.SetTrigger("death");
            anim.SetBool("isDead", true);
            
        }
    }

    private void PrintHealthAndExperience()
    {
        _experienceText = (int)player.experience;
        _healthText = (int)player.health;
        healthBar.fillAmount = player.health / _firstHealt;
        healthText.text = _healthText + "/" + _firstHealt;
        experienceText.text = _experienceText + "/" + _firstExperience;
    }

    private float GetFirstExperience()
    {
        return player.limitExperience;
    }

    private int GetFCurrentExperience()
    {
        return (int)player.experience;
    }

    public void GetExperience(float exp)
    {
        player.experience += exp;
        if (player.experience > player.limitExperience)
            experienceBar.fillAmount = (player.experience - player.limitExperience)/ player.limitExperience;
        else
            experienceBar.fillAmount = player.experience / player.limitExperience; 
    }

    private void Print_Arrows_Potions_Apples_Quantity()
    {
        arrowsText.text = "x" + player.arrow;
        potionsText.text = "x" + player.potions;
        applesText.text = "x" + player.apples;
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Equals("Walls"))
        {
            Vector3 directionToTarget = other.gameObject.transform.position - transform.position;
            float angle = Vector3.Angle(GetComponent<Transform>().forward, directionToTarget);
            if(Mathf.Abs(angle) < 225 && Mathf.Abs(angle) > 135)
                GetComponent<Rigidbody>().AddForce(transform.right * -2000, ForceMode.Impulse);
            else if (Mathf.Abs(angle) > 45 && Mathf.Abs(angle) < 135)
                GetComponent<Rigidbody>().AddForce(transform.forward * -2000, ForceMode.Impulse);
            else if (Mathf.Abs(angle) >= 225 && Mathf.Abs(angle) < 315)
                GetComponent<Rigidbody>().AddForce(transform.forward * 2000, ForceMode.Impulse);
            else
                GetComponent<Rigidbody>().AddForce(transform.right * 2000, ForceMode.Impulse);
            GetComponent<AudioSource>().PlayOneShot(denied);
        }
        if (other.gameObject.tag.Equals("Apple") || other.gameObject.tag.Equals("Potion") || other.gameObject.tag.Equals("Key") || other.gameObject.tag.Equals("PowerUp"))
        {
            other.gameObject.GetComponent<Transform>().Find("Canvas").gameObject.SetActive(true);
        }
        else if (other.gameObject.tag.Equals("Ammo"))
        {
            if (player.arrow < 10)
            {
                if (player.arrow + 3 > 10)
                    player.arrow = 10;
                else
                    player.arrow += 3;
                Destroy(other.gameObject);
            }
        }
    }
        public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Apple"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                if (player.apples < 10)
                {
                    anim.SetTrigger("raccogli");
                    player.apples += 1;
                    Destroy(other.gameObject);
                }
                else
                {
                    other.gameObject.GetComponent<Transform>().Find("Canvas").gameObject.GetComponent<Transform>().Find("Image").gameObject.GetComponent<Transform>().Find("Text").GetComponent<Text>().text = "Non puoi avere più di 10 mele";
                }
            }

        }
        else if (other.gameObject.tag.Equals("Potion"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                if (player.potions < 1)
                {
                    anim.SetTrigger("raccogli");
                    player.potions += 1;
                    Destroy(other.gameObject);
                }
                else
                {
                    other.gameObject.GetComponent<Transform>().Find("Canvas").gameObject.GetComponent<Transform>().Find("Image").gameObject.GetComponent<Transform>().Find("Text").GetComponent<Text>().text = "Hai già 1 pozione";
                }
            }

        }
        else if (other.gameObject.tag.Equals("Key"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                anim.SetTrigger("raccogli");
                switch (other.gameObject.name)
                {
                    case "Key1":
                        player.keys[0] = true;
                        other.gameObject.GetComponent<Transform>().Find("Canvas").gameObject.GetComponent<Transform>().Find("Image").gameObject.GetComponent<Transform>().Find("Text").GetComponent<Text>().text = "Hai Raccolto la 1^ chiave";
                        wall1.SetActive(false);
                        break;
                    case "Key2":
                        player.keys[1] = true;
                        other.gameObject.GetComponent<Transform>().Find("Canvas").gameObject.GetComponent<Transform>().Find("Image").gameObject.GetComponent<Transform>().Find("Text").GetComponent<Text>().text = "Hai Raccolto la 2^ chiave";
                        wall2.SetActive(false);
                        break;
                    case "Key3":
                        player.keys[2] = true;
                        other.gameObject.GetComponent<Transform>().Find("Canvas").gameObject.GetComponent<Transform>().Find("Image").gameObject.GetComponent<Transform>().Find("Text").GetComponent<Text>().text = "Hai Raccolto la 3^ chiave";
                        wall3.SetActive(false);
                        break;
                }


            }
        }
        else if (other.gameObject.tag.Equals("PowerUp"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                anim.SetTrigger("raccogli");
                switch (other.gameObject.name)
                {
                    case "PowerUp_Res":
                        player.maxHealth += 25;
                        _firstHealt = player.maxHealth;
                        Destroy(other.gameObject);
                        break;
                    case "PowerUp_Spada":
                        sword.damage += 5;
                        sword.level++;
                        Destroy(other.gameObject);
                        break;
                }
            }
        }


    }


    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Apple") || other.gameObject.tag.Equals("Potion") || other.gameObject.tag.Equals("Key") || other.gameObject.tag.Equals("PowerUp"))
        {
            other.gameObject.GetComponent<Transform>().Find("Canvas").gameObject.GetComponent<Transform>().Find("Image").gameObject.GetComponent<Transform>().Find("Text").GetComponent<Text>().text = "Raccogli (F)";
            other.gameObject.GetComponent<Transform>().Find("Canvas").gameObject.SetActive(false);
        }
    }
    public void GameLoaded()
    {
        if (player.keys[0])
            wall1.SetActive(false);
        if (player.keys[1])
            wall2.SetActive(false);
        if (player.keys[2])
            wall3.SetActive(false);
    }
}

