using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public double HP;
    public double MaxHP;
    public double Damage;

    public GameObject Target;
    public float MoveSpeed = 0.5f;

    public float HPPercent { get => (float)(MaxHP / HP * 100f); }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }

        if (Target == null)
        {
            return;
        }
        var step = MoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, step);

        if (Vector3.Distance(transform.position, Target.transform.position) < 0.001f)
        {
            //Target.GetComponent<PlayerController>().OnHit(this);
            Destroy(this.gameObject);
        }

    }

    public void OnHit(BulletController bullet)
    {
        HP -= bullet.Damage;
        //передать объект пули, ее урон и отнять от хп.
    }

    public EnemyController(double health, double damage)
    {
        this.HP = health;
        this.MaxHP = health;
        this.Damage = damage;
    }
}
