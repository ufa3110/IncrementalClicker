using System.Threading.Tasks;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject Target;
    private float BulletSpeed = 3.0f;
    public Vector3 Destination;
    public int Damage = 10;

    public void TargetToEnemy(GameObject target)
    {
        Target = target;
    }

    // Start is called before the first frame update
    void Start()
    {
        Destination = Target.transform.position;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Destination == null || Target == null)
        {
            WaitTillDestroy();
            return;
        }
        var step = BulletSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, step);

        if (Vector3.Distance(transform.position, Target.transform.position) < 0.001f)
        {
            Target.GetComponent<EnemyController>().OnHit(this);
            Destroy(this.gameObject);
        }
    }

    public async Task WaitTillDestroy()
    {
        await Task.Delay(100);
        if (Destination == null || Target == null)
        {
            Destroy(this.gameObject);
        }
    }
}
