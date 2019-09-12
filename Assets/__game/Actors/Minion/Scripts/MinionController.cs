using UnityEngine;


public class MinionController : MonoBehaviour, IInteractable
{
    public float speedMove = 4.5f;
    public float radiusInteractable = 0.5f;
    public float maxFallSpeed = -25f;
    public float maxDurationMoveAfterFalling = 0.8f;
    public float checkObstaculeDistance = 0.5f;
    public Transform checkObstaculeOriginPosition;
    
    private PlayerController player;
    private bool moving;
    private LayerMask layerPlayer;
    private bool isPlayerEnter;
    private Rigidbody2D mRigidbody;
    private float fallTime;
    private bool isFalling;
    private bool hasObstacule;

    public void Interact()
    {
        if (isPlayerEnter)
        {
            //todo show gorra
            moving = true;
            isPlayerEnter = false;
            player.SetInteractable(null);
            player = null;
        }
        else
        {
            player.SetInteractable(null);
        }
    }

    private void Awake()
    {
        moving = false;
        layerPlayer = LayerMask.GetMask("Player");
        mRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!moving)
        {
            ChekOnPlayerEnter();
        }
        else
        {
            CheckForObstacule();
            Flip();
            Movement();
        }
    }

    private void CheckForObstacule()
    {
        RaycastHit2D obstaculeHit = Physics2D.Raycast(checkObstaculeOriginPosition.position, transform.right,checkObstaculeDistance);
        hasObstacule = obstaculeHit && !obstaculeHit.transform.gameObject.CompareTag("Player") && !obstaculeHit.transform.gameObject.CompareTag("Minions");
#if UNITY_EDITOR
        Color color = hasObstacule ? Color.green : Color.red;
        Debug.DrawRay(checkObstaculeOriginPosition.position, checkObstaculeDistance * transform.right, color);
#endif
    }

    private void Flip()
    {
        if (hasObstacule)
        {
            transform.Rotate(0, 180, 0);
        }
    }

    private void ChekOnPlayerEnter()
    {
        Collider2D colliderRadius = Physics2D.OverlapCircle(transform.position, radiusInteractable, layerPlayer);
        isPlayerEnter = colliderRadius;
        if (isPlayerEnter)
        {
            if (player == null)
            {
                player = colliderRadius.gameObject.GetComponent<PlayerController>();
            }
            player.SetInteractable(this);
        }
    }

    private void Movement()
    {
        Vector2 velocity = mRigidbody.velocity;
        if (velocity.y < 0)
        {
            if (!isFalling)
            {
                isFalling = true;
                fallTime = Time.time + maxDurationMoveAfterFalling;
            }
            if (velocity.y < maxFallSpeed)
                velocity.y = maxFallSpeed;
        }
        else
        {
            isFalling = false;
        }

        if (!isFalling)
        {
            Vector2 direction = transform.right;
            velocity.x = speedMove * direction.x;
        }
        else
        {
            if (fallTime > Time.time)
            {
                Vector2 direction = transform.right;
                velocity.x = speedMove * direction.x;
            }
            else
            {
                velocity.x = 0;
            }
        }
        
        mRigidbody.velocity = velocity;
    }

}
