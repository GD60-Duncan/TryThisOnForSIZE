using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Cinemachine;

public class Movement : MonoBehaviour
{
    public bool IsGrounded; //{ get; private set; } = true;
    public Vector3 GroundNormal { get; private set; } = Vector3.up;
    public Vector3 MoveInput { get; private set; }

    public bool CanMove { get; set; } = true;
    public bool OnWall; //{get; set;}
    public bool CanWallSlide {get; set;}

    public bool WallHung {get; set;} 
    public float MoveSpeedMultiplier { get; set; } = 1f;
    public float ForcedMovement { get; set; } = 0f;

    [Header("Jumping Related")]

    public bool ClimbingJump = false;

    public Vector2 _groundedBoxSize;

    public Vector3 _groundedBoxOffset;

    public Vector3 _groundCheckStart = new Vector3(0f, 0.4f);
    
    public Vector2 _wallCheckSize;

    public Vector3 _wallCheckOffset;
    
    [SerializeField] private float _jumpforce = 5;

    [SerializeField] protected Rigidbody2D _rigid;

    [SerializeField] private Vector2 _jumpheight;

    [SerializeField] private ForceMode2D _force;

    [SerializeField] private LayerMask GroundMask;

    [SerializeField] private float ChecRadius;

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] protected Animator _character;

    [SerializeField] private GameObject _hat;

    [SerializeField] private int _gravityScale = 6;

    [Header("Movement Related")]

    [SerializeField] private float _accerationTarget;

    [SerializeField] private float _minAcceleration;

    [SerializeField] private AnimationCurve _acceractionCurve;


    //[SerializeField] private CinemachineImpulseSource _Isource;

    [SerializeField] private float _walkSpeed;

    [SerializeField] private float _runSpeed;

    [SerializeField] private GameObject _flipObj;

    protected float moveDirection = 1;

    [Header("Settings and Data")]

    [SerializeField] private GameObject _helpUi;

    [SerializeField] private GameObject _inputDisplay;

    [SerializeField] private SaveData _saveData;

    public float baseSpeed;

    private bool onceiling;

    public bool currentlyJumping  { get; private set; }

    public float currentAcceleration;

    private Vector3 wallDirection;

    private float animationSpeed;

    private Coroutine runState;

    
    
    void Start()
    {
        _jumpheight = new Vector2(0,2 * _jumpforce);
        //hurtboxsize = _hurtbox.radius;
        
        _rigid.gravityScale = _gravityScale;
        //_helpUi.SetActive(_saveData.Help);
        //_inputDisplay.SetActive(_saveData.Info);

        //Topspeed();
    
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //IsGrounded = CheckGrounded();
        CheckWall();
        CheckGounded();
        onceiling = CeilingChecking();

       
    }

    private void FixedUpdate()
    {
        Vector3 input = MoveInput;
        if (ForcedMovement > 0f) input = transform.forward * ForcedMovement;
        Vector3 right = Vector3.Cross(transform.up, input);
        Vector3 forward = Vector3.Cross(right, GroundNormal);

        animationSpeed = Mathf.Abs(Velocity.x);

        if(_character)
        {
            _character?.SetFloat("Speed", animationSpeed);
        }



        //_character.SetBool("Wallhung", WallHung);


    
        //Debug.DrawRay(transform.position, forward);
        // if(_rigid.velocity == Vector2.zero)
        // {
        //     Move(IsGrounded,1);
        // }

        if(IsGrounded == false && OnWall == false)
        {
            _rigid.gravityScale = _gravityScale;
        }
    }

    public Vector3 Velocity
    {
        get {
            if(_rigid  == null)
            {
               return Vector3.zero;
            }
            return _rigid.velocity;
        }

        private set => _rigid.velocity = value;
    }

    public Rigidbody2D Rigidbody
    {
        get
        {
            return _rigid;
        }
    }

    public void ChangeScale(Vector3 scale)
    {
        _flipObj.transform.localScale = new Vector2(Mathf.Abs(scale.x) * moveDirection, scale.y);
        //Debug.Log(moveDirection);

        
    }

    public void Jump()
    {
        currentlyJumping = true;
        _rigid.gravityScale = _gravityScale;
        CheckGounded();
        if(IsGrounded == true && currentlyJumping == false)
        {
            WallHung = false;
            currentlyJumping = true;
            _character.SetTrigger("Jump");
            Debug.Log("Jump");
            _rigid.AddForce(Vector2.up * _jumpforce * Mathf.Clamp(currentAcceleration,1.5f,3), _force);
            

        }

        //currentlyJumping = false;

            //_rigid.velocity += Vector2.up * Physics2D.gravity * (_jumpforce - 1) * Time.deltaTime;
    
    }

    public void JumpHasFinished()
    {
        currentlyJumping = false;
    }

    public void WallJump(bool jump)
    {
        WallHung = false;
        if(CeilingChecking() == true && OnWall == false)  
        {Debug.Log("Can't Jump"); return;}

        if(jump == false)
        {WallHang(); return;}

        //if(currentlyJumping == true) return;

        

        currentlyJumping = true;
        _rigid.gravityScale = _gravityScale;
       
        _character.SetTrigger("Jump");
        _audioSource.Play();
        _rigid.AddForce(_jumpheight * _jumpforce);
        OnWall = false;

        _rigid.AddForce(Vector2.up * _jumpforce * currentAcceleration);
    }

    public void ClimbJump(float direction)
    {
        //if(WallHung)
        //{WallHang(); return;}
        
        WallHung = false;
        if(CeilingChecking() == true && OnWall == false) return;

        //Debug.Log("Climb Jump");
        //ClimbingJump = true;
        WallHung = false;
        _character.SetTrigger("Jump");
        
        Vector2 deez = new Vector2(0 , _jumpforce * 3);

        wallDirection = new Vector3(direction * 0.5f, _wallCheckOffset.y, _wallCheckOffset.z);

        //_rigid.AddForce(_jumpheight);

        //_rigid.AddForce(Vector2.up * _jumpforce * currentAcceleration);

        StartCoroutine(CalucateGravity(5f,0.1f));
        
        _rigid.AddForce(deez,_force);
        //StartMove();
        
        
        
    }

    public void WallHang()
    {
            
            if(OnWall && CeilingChecking() == false)
            {
                WallHung = true;
                _character.SetBool("Wallhung", WallHung);
                Stop();
                if(CanWallSlide == false)
                {
                    _rigid.gravityScale = Vector3.zero.x; return;
                }
                
            }

            WallHung = false;
            
    }

    public void Move(bool MoveInput, float direction)
    {
        if(MoveInput == true)
        {
            
            _rigid.velocity = new Vector2(baseSpeed  * currentAcceleration * direction,_rigid.velocity.y);
            //Debug.Log(_rigid.velocity);
        }

        wallDirection = new Vector3(direction * 0.5f, _wallCheckOffset.y, _wallCheckOffset.z);



        //if(IsGrounded == false) return;

        Vector3 newScale = _flipObj.transform.localScale;

        //newScale.x = Mathf.Floor(direction);

        if(newScale.x == 0) return;

        moveDirection = Mathf.Floor(direction);

        ChangeScale(newScale);

        //ChangeScale(newScale);
       
    }

    public void SetLookDirection()
    {
        _rigid.velocity = new Vector2(2,2);
    }

    public void Stop()
    {
        Debug.Log("Stop");
        if(runState != null)
        {
             StopCoroutine(runState);
        }
        _rigid.velocity = Vector2.zero;
        currentAcceleration = 0;
    }

    public void SetMoveable(bool move)
    {
        CanMove = move;

        if(!CanMove)
        {
            Stop();
        }
    }



    private void CheckGounded()
    {
       Vector3 originPosition = transform.position + _groundedBoxOffset;

        Vector2 direction = Vector2.down;

        _character.SetBool("IsGrounded", IsGrounded);
        
        if (Physics2D.BoxCast(originPosition,_groundedBoxSize, 0, direction,0, GroundMask))
        {
            
            bool angleValid = Vector2.Angle(Vector2.up, _groundCheckStart) < 78;
            if (angleValid)
            {
               
                 
                 
                IsGrounded = true;
                WallHung = false;
                JumpHasFinished();
                return;
            }
        }

       IsGrounded = false;
       //currentlyJumping = false;
       
       
    }

    public void WallSlide()
    {
        if(IsGrounded == false)
        {
            _rigid.gravityScale = 1;
            return;
        }
        
        CanWallSlide = false;
    }

    private void CheckWall()
    {
        if(Physics2D.OverlapBox (transform.position + wallDirection, _wallCheckSize,0, GroundMask) && onceiling == false) 
       {
           OnWall = true;
           return;

       }

       OnWall = false;
    }

    private bool CeilingChecking()
    {
        Vector2 Box = new Vector2(0.5f,0.5f); 
        
        if(Physics2D.OverlapBox(_hat.transform.position, Box,0, GroundMask))
        {
            return true;
        }

        return false;
    }

    public bool IsWalking()
    {
        
        if(animationSpeed > _walkSpeed && animationSpeed < _runSpeed)
        {
            return true;
        }

        return false;
    }

    public bool IsRunning()
    {
        if(animationSpeed > _runSpeed)
        {
            return true;
        }

        return false;
    }

    public void Topspeed()
    {

        //_Isource.GenerateImpulse();
        currentAcceleration = _accerationTarget;
        _rigid.velocity = new Vector2(baseSpeed  * currentAcceleration * 1,_rigid.velocity.y);
    }

    public void MegaJump()
    {
        currentlyJumping = true;
        _rigid.gravityScale = _gravityScale;
        WallHung = false;
        //_character.SetTrigger("Jump");
        //_audioSource.Play();
        Vector2 Force = new Vector2(10 * _jumpheight.x * _jumpforce * 1000f,0);
        Debug.Log(Force);
        _rigid.AddForce(Vector2.one * 10 * _jumpforce,_force);
        


    }

    public void StartMove()
    {
       if(CanMove == false) return;
       
        //CanWallSlide = false;
        Debug.Log("Move" + currentAcceleration);
            //if(_)


            runState = StartCoroutine(CalculateAccleration(_minAcceleration));

    }

    private IEnumerator CalculateAccleration(float value)
    {
        
        //Debug.Log("StartA");
        currentAcceleration = 1.5f;
        while(value < _accerationTarget)
        {
            value += Time.deltaTime;
            //Debug.Log(value);
            //Debug.Log(_acceractionCurve.Evaluate(value));
            currentAcceleration = _acceractionCurve.Evaluate(value);
            //_hurtbox.radius = Mathf.Clamp(hurtboxsize / currentAcceleration, 0.2f, 0.5f);

            // if(WallHung)
            // {
            //     yield break;
            // }

            yield return new WaitForEndOfFrame();
            //_rigid.velocity = 
        }

        ClimbingJump = false;
        
        //_aclerationCurve.Evaluate();

    }

    private IEnumerator CalucateGravity(float gravitystart, float time)
    {
        
        float timer = 0f;
        _rigid.gravityScale = gravitystart;

        while(timer < time)
        {
            timer += Time.deltaTime;

            _rigid.gravityScale = Mathf.Lerp(gravitystart, _gravityScale, timer);

            //_rigid.AddForce()

            //Debug.Log(_rigid.gravityScale);

            yield return new WaitForEndOfFrame();
        }

    //_rigid.gravityScale = _gravityScale;
        //StartMove();

        ClimbingJump = false;
    }

    protected virtual void OnDrawGizmos()
    {
        //if(onceiling)
        {

            //return;
        }
        
        if(IsGrounded)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(transform.position + _groundedBoxOffset,_groundedBoxSize);
        }

        else
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, ChecRadius);
            Gizmos.DrawCube(transform.position + _groundedBoxOffset,_groundedBoxSize);
        }
        //Gizmos.color = Color.red;
        
        
    }

}
