using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Fighter : MonoBehaviour {
#region AnimatorProperties
	private float moveSpeed = 0;
	private bool simpleHit;
	private bool specialHit;
	private bool receiveDamage;

	#endregion

#region FighterProperties

	[SerializeField]
	private float health;
	[SerializeField]
	private float simpleHitDamage;
	[SerializeField]
	private float specialHitDamage;
	[SerializeField]
	private float specialHitForce;
    [SerializeField]
    private bool canAttack;
    [SerializeField]
    private bool isBlocking;
    [SerializeField]
    private bool isReceivingDamage;
    [SerializeField]
    private GameObject shield;
    private FighterShield myShield;
    [SerializeField]
    private int numberOfHits;


    #endregion

    #region Cooldowns
    [SerializeField]
	private float bodyHitCol_CD;
	[SerializeField]
	private float simpleHitCol_CD;
    [SerializeField]
    private float simpleHitSpawn_CD;
    [SerializeField]
    private float specialHitSpawn_CD;
    [SerializeField]
	private float specialHitCol_CD;

#endregion

#region FighterComponents
	private Animator myAnimator;
	private Rigidbody2D myRigidbody2D;
	private Collider2D bodyCollider;
	[SerializeField]
	private Collider2D simpleHitCollider;
	[SerializeField]
	private Collider2D specialHitCollider;


    #endregion

#region Getters/Setters

    public float Health
	{
		get
		{
			return health;
		}
		set{
			health = value;
		}
	}

    public bool IsBlocking
    {
        set
        {
            isBlocking = value;
        }
    }
    public bool CanAttack
    {
        get
        {
            return canAttack;
        }
    }

    public FighterShield MyShield
    {
        get
        {
            return myShield;
        }
    }
    public int NumberOfHits
    {
        get
        {
            return numberOfHits;
        }
        set
        {
            numberOfHits = value;
        }
    }

    #endregion


    public AudioSource source;
    public AudioClip swoosh;
    public AudioClip punch;
    public AudioClip ouch;

    void Start () {
		myAnimator = GetComponent <Animator>();
		myRigidbody2D = GetComponent <Rigidbody2D >();
		bodyCollider = GetComponent <Collider2D>();
		GetComponentInChildren <SimpleHitCollider>().InitializeDamage(simpleHitDamage);
		GetComponentInChildren <SpecialHitCollider>().InitializeDamage(specialHitDamage, specialHitForce);
        source = GameObject.Find("Audio Source").GetComponent<AudioSource>();
		simpleHitCollider.enabled = false;
		specialHitCollider.enabled = false;
        myShield = shield.GetComponent<FighterShield>();
		canAttack = true;
        isReceivingDamage = false;
	}
	
	void Update () {
		
	}

	public void MovePlayer(float horizontal)
    {
        Vector3 forces = Vector3.zero;

		forces += transform.right * horizontal;
        forces.y = 0.0f;

        myRigidbody2D.position += new Vector2(forces.x, forces.y) * Time.deltaTime ;
    }

	public void SimpleHit()
	{
		if(canAttack && !isBlocking)
        {
            canAttack = false;
			myAnimator.SetBool ("SimpleHit", true);
			StartCoroutine ("EnableSimpleHitCollider");
            source.PlayOneShot(punch);
		}

	}

	public void SpecialHit()
	{
		if(canAttack && !isBlocking){
            canAttack = false;
            myAnimator.SetBool ("SpecialHit", true );
			StartCoroutine ("EnableSpecialHitCollider");
            source.PlayOneShot(swoosh);
        }
	}

	public void ReceiveDamage(float damage)
	{
        if(myShield.IsBlocking == false)
        {
            Debug.Log("Damage received");
            canAttack = false;
            isReceivingDamage = true;
            myAnimator.SetBool("ReceiveDamage", true);
            Health -= damage;
            numberOfHits++;
            StartCoroutine("DisableBodyCollider");
            source.PlayOneShot(ouch);
        }

	}
	public void ApplyForce(float damageForce)
	{
        var bloodP = BloodPool.Instance.GetBlood();
        bloodP.transform.position = transform .position + new Vector3(0,3,-1);
        if(transform.localScale.x > 0)
        {
            bloodP .transform .localScale=new Vector3(-1,1,1);
            Debug.Log("Force applied");
            myRigidbody2D.AddForce(-transform.right * damageForce, ForceMode2D.Impulse);
        }	else if (transform.localScale.x < 0)
        {
            bloodP .transform .localScale=new Vector3(1,1,1);
            Debug.Log("Force applied");
            myRigidbody2D.AddForce(transform.right * damageForce, ForceMode2D.Impulse);
        }
            

	}

	public void Flip(){
		var myScale = transform.localScale;		
		myScale.x = -transform.localScale.x;
		transform.localScale = new Vector3(myScale.x,1,1);
	}

    public void Block(bool isBlocking)
    {
        shield.SetActive(isBlocking);
    }

	private IEnumerator EnableSimpleHitCollider()
	{
		yield return new WaitForSeconds (simpleHitSpawn_CD);
		simpleHitCollider .enabled = true;
        myAnimator.SetBool("SimpleHit", false);
        yield return new WaitForSeconds (simpleHitCol_CD);
		simpleHitCollider .enabled = false;
        yield return new WaitForSeconds(0.4f);
        canAttack = true;
	}

	private IEnumerator EnableSpecialHitCollider()
	{

		yield return new WaitForSeconds (specialHitSpawn_CD );
		specialHitCollider .enabled = true;
        myAnimator.SetBool("SpecialHit", false);
        yield return new WaitForSeconds (specialHitCol_CD);
		specialHitCollider .enabled = false;
        canAttack = true;
	}

	private IEnumerator DisableBodyCollider()
	{
	//	bodyCollider .enabled = false;
		yield return new WaitForSeconds (bodyHitCol_CD);
		myAnimator.SetBool ("ReceiveDamage", false);
		bodyCollider .enabled = true;
		canAttack = true;
        isReceivingDamage = false;
	}
}
