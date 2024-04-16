using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip pistolSound;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private GameObject _bulletTrail;
    [SerializeField] private float _weaponRange = 10f;

    private void Start()
    {
        audioSource.clip = pistolSound;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
            audioSource.Play();
        }
    }
    
    private void Shoot()
    {
        var hit = Physics2D.Raycast(_gunPoint.position, transform.up, _weaponRange);

        var trail = Instantiate(_bulletTrail, _gunPoint.position, transform.rotation);
        var trailScript = trail.GetComponent<BulletTrail>();
        HitTarget(hit, trailScript);

    }

    private void HitTarget(RaycastHit2D hit, BulletTrail trailScript)
    {
        if (hit.collider != null)
        {
            trailScript.SetTargetPosition(hit.point);

            Target target = hit.collider.GetComponent<Target>();
            if (target)
            {
                Debug.Log("Hit " + hit.collider.name);
                target.TakeDamage(20);
            }
        }
        else
        {
            var endPosition = _gunPoint.position + transform.up * _weaponRange;
            trailScript.SetTargetPosition(endPosition);
        }

    }
}
