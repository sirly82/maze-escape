using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed = 2f;
    public float detectionRange = 5f;
    public float rotationSpeed = 5f; // Added rotation speed parameter
    public LayerMask obstacleMask;
    public float groundCheckDistance = 0.2f;
    
    private Transform player;
    private int currentPoint = 0;
    private bool isChasing = false;
    private Vector3 lastGroundPosition;
    private float chaseDelay = 0.5f; // waktu tunggu sebelum mulai ngejar
    private float chaseTimer = 0f;

    [HideInInspector] public bool hasBeenKilled = false;

    void OnTriggerEnter(Collider other)
    {
        if (hasBeenKilled) return; // Sudah dihancurkan dari atas

        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlayPlayerHurt();
            Debug.Log("Musuh menyentuh Player");
            GameManager.Instance.DecreaseScore(10);

            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        // Face the first patrol point at start
        if (patrolPoints.Length > 0)
        {
            LookAtTarget(patrolPoints[currentPoint].position);
        }
    }

    void Update()
    {
        if (!IsGrounded())
        {
            transform.position = lastGroundPosition;
        }
        else
        {
            lastGroundPosition = transform.position;
        }

        if (!isChasing)
        {
            Patrol();
            DetectPlayer();
        }
        else
        {
            ChasePlayer();
        }

        Debug.DrawRay(transform.position, (player.position - transform.position).normalized * detectionRange, Color.red);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(
            transform.position + Vector3.up * 0.1f, 
            Vector3.down, 
            groundCheckDistance
        );
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform targetPoint = patrolPoints[currentPoint];
        Vector3 flatTarget = new Vector3(
            targetPoint.position.x, 
            transform.position.y, // Pertahankan ketinggian yang sama
            targetPoint.position.z
        );

        LookAtTarget(flatTarget);
        transform.position = Vector3.MoveTowards(
            transform.position,
            flatTarget,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }

    void DetectPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        if (distanceToPlayer < detectionRange && HasLineOfSightToPlayer())
        {
            chaseTimer += Time.deltaTime;

            if (chaseTimer >= chaseDelay)
            {
                isChasing = true;
                chaseTimer = 0f;
            }
        }
        else
        {
            chaseTimer = 0f; // reset kalau player keluar range
        }
    }

    bool HasLineOfSightToPlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Raycast untuk cek penghalang
        if (Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleMask))
        {
            return false; // Ada penghalang
        }
        return true;
    }

    void ChasePlayer()
    {
        if (!HasLineOfSightToPlayer())
        {
            isChasing = false;
            return;
        }

        Vector3 chaseTarget = new Vector3(
            player.position.x, 
            transform.position.y, // Tetap di ketinggian awal
            player.position.z
        );

        LookAtTarget(chaseTarget);
        float chaseSpeed = speed * 1.0f;
        transform.position = Vector3.MoveTowards(
            transform.position, 
            chaseTarget, 
            chaseSpeed * Time.deltaTime
        );

        // If player moves out of range, return to patrol
        if (Vector3.Distance(transform.position, player.position) > detectionRange * 1.2f)
        {
            isChasing = false;
        }
    }

    // Helper method to smoothly rotate towards a target position
    void LookAtTarget(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        
        // Ignore vertical difference if this is a ground-based enemy
        direction.y = 0;
        
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation, 
                targetRotation, 
                rotationSpeed * Time.deltaTime
            );
        }
    }
}