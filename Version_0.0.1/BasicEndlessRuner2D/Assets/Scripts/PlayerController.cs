using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private float moveSpeedStore;

    public float jumpForce;
    public bool grounded;
    public LayerMask whatIsGround; // una variable tipo LayerMask (mascara de capas) permite realizar una seleccion de capas(layers)
    public Transform groundCheck;
    public float groundCheckRadious;


    private Rigidbody2D myRigidbody2D;  // creamos una variable tipo RigidBody, componente que se encuentra en el inspector
                                        //private Collider2D myCollider2D;  // creamos una variable tipo Collider2D, componente que se encuentra en el inspector 

    public float jumpTime;
    private float jumpTimeCounter;

    private bool stopedJumping;
    private bool canDoubleJump;

    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount; // es el contador que mantiene pendiente del incremento de velocidad

    private float speedMilestoneCountStore;

    public GameManager theGameManager;

    public AudioSource jumpSound;
    public AudioSource deathSound;

    private Animator myAnimator;  // creamos una variable tipo Animator, componente que se encuentra en el inspector 

    // Use this for initialization
    void Start()
    {

        myRigidbody2D = GetComponent<Rigidbody2D>();   // capturamos el componente RigidBody que se encuentra en el objeto
        //myCollider2D = GetComponent<Collider2D> ();   // capturamos el componente Collider2D que se encuentra en el objeto

        myAnimator = GetComponent<Animator>(); //capturamos el componente Animator que se encuentra en el objeto 

        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;

        speedMilestoneCountStore = speedMilestoneCount;

        speedIncreaseMilestoneStore = speedIncreaseMilestone;

    }

    // Update is called once per frame
    void Update()
    {

        //grounded = Physics2D.IsTouchingLayers (myCollider2D, whatIsGround); // la variable va a ser verdadera si el objeto esta colisionando (myCollider)
        // con alguna capa seleccionada en la mascara de capas 

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadious, whatIsGround);

        if (transform.position.x > speedMilestoneCount)
        {

            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

            moveSpeed = moveSpeed * speedMultiplier;

        }

        myRigidbody2D.velocity = new Vector2(moveSpeed, myRigidbody2D.velocity.y);  // accedemos a la velocidad del componente y creando un nuevo vector le asignamos
                                                                                    // un valor a esa velocidad con una variable ya declarada, en este caso es Vector2
                                                                                    // por lo que solamente se modifican las posiciones (x,y)

        if (Input.GetKeyDown(KeyCode.Space) )
        {    // verifica si se esta oprimiendo la tecla espacio o un click izquierdo

            if (grounded)
            {

                myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpForce); // accedemos a la velocidad del componente y creando un nuevo vector le asignamos
                                                                                           // un valor al eje y con una variable ya declarada, en este caso es Vector2
                                                                                           // por lo que solamente se modifican las posiciones (x,y)
                stopedJumping = false;
                // sonido al saltar
                //jumpSound.Play ();

            }

            if (!grounded && canDoubleJump)
            {

                myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                stopedJumping = false;
                canDoubleJump = false;
                // sonidos al saltar(doble salto)
                //jumpSound.Play ();
            }

        }

        if (Input.GetKeyDown(KeyCode.Space) )
        {

            if (jumpTimeCounter > 0)
            {

                myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;

            }
        }

		if ((Input.GetKeyUp(KeyCode.Space)  && !stopedJumping))
        {

            jumpTimeCounter = 0;
            stopedJumping = true;
        }

        if (grounded)
        {

            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }


        myAnimator.SetFloat("Speed", myRigidbody2D.velocity.x);
        myAnimator.SetBool("Grounded", grounded);

    }

    void OnCollisionEnter2D(Collision2D other)

    {

        if (other.gameObject.tag == "Killbox")
        {


            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            stopedJumping = true;
            //sonido al morir
            //deathSound.Play ();
        }

    }
}
