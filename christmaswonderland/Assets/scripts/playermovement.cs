using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    private CharacterController characterController;
    
    public Animator animator;
    public RuntimeAnimatorController anim1;
    public RuntimeAnimatorController anim2;
    public RuntimeAnimatorController anim3;
    public RuntimeAnimatorController anim4;
    public RuntimeAnimatorController anim5;
    public RuntimeAnimatorController anim6;
    
    private int charselec = 1;
    public float speed = 5f;
    public float jumpspeed = 5f;
    [SerializeField]
    private Vector3 move;
    private float horizontal = 0f;
    private float vertical = 0f;
    private bool ch = false; 
    private bool cv = false;
    private float yspeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        charselec = PlayerPrefs.GetInt("CharacterSelected");
        if (charselec == 1)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = anim1 as RuntimeAnimatorController;
        } else if(charselec == 2)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = anim2 as RuntimeAnimatorController;
        } else if(charselec == 3)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = anim3 as RuntimeAnimatorController;
        } else if (charselec == 4)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = anim4 as RuntimeAnimatorController;
        } else if (charselec == 5)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = anim5 as RuntimeAnimatorController;
        } else if (charselec == 6)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = anim6 as RuntimeAnimatorController;
        }

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //jumping
        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                yspeed = jumpspeed;
            }
        } else
        {
            yspeed += Physics.gravity.y * Time.deltaTime;
        }

        //applymovement
        move = new Vector3(horizontal, yspeed, vertical);
        
        //animation
        if(horizontal != 0f)
        {
            ch = true;
        } else
        {
            ch = false;
        }
        if(vertical != 0f)
        {
            cv = true;
        } else
        {
            cv = false;
        }
        if(yspeed > 0f)
        {
            animator.SetBool("isjumping", true);
        } else
        {
            animator.SetBool("isjumping", false);
        }
        if (ch || cv)
        {
            animator.SetFloat("blend", 1);
        } else
        {
            animator.SetFloat("blend", 0);
        }


    }

    
    void FixedUpdate()
    {
        characterController.Move(move*Time.deltaTime*speed);
    }

    //para charselec scene
    public void confirmselec()
    {
        SceneManager.LoadScene("gscene");
    }

    public void bobbyselec()
    {
        charselec = 1;
        PlayerPrefs.SetInt("CharacterSelected", charselec);
    }

    public void santaselec()
    {
        charselec = 2;
        PlayerPrefs.SetInt("CharacterSelected", charselec);
    }

    public void elfselec()
    {
        charselec = 3;
        PlayerPrefs.SetInt("CharacterSelected", charselec);
    }

    public void frankselec()
    {
        charselec = 4;
        PlayerPrefs.SetInt("CharacterSelected", charselec);
    }

    public void rudolphselec()
    {
        charselec = 5;
        PlayerPrefs.SetInt("CharacterSelected", charselec);
    }

    public void trunksselec()
    {
        charselec = 6;
        PlayerPrefs.SetInt("CharacterSelected", charselec);
    }
}
