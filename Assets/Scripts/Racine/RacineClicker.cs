using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class RacineClicker : MonoBehaviour
{
    public int RootBaseHp;
    public int RootHp;
    public int Value;
    public int MaxValue;
    public int AddedMaxValue;
    public bool HasDuplicated;
    public int Range;
    public float RandomValue;
    public Vector3 DRPosition;

    public SpriteRenderer _SpriteRenderer;
    public RacineClicker DuplicatedRoot;

    public void Start()
    {
        _SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        RootHp = RootBaseHp;    
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Value += 1;
        }

        if(Value >= MaxValue && HasDuplicated == false)
        {
            HasDuplicated = true;

            this.gameObject.GetComponent<Rigidbody2D>().mass = 1000;
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            RandomValue = Random.Range(-Range, Range);
            Duplicate();
            RandomValue = -RandomValue; // chagner la ra ndom value pour etre toujours positive puis tjrs negative et refaire un roll pour etre plus de forme naturtelle
            Duplicate();
        }
    }

    public void Duplicate()
    {
        DRPosition = new Vector3(this.gameObject.transform.position.x + RandomValue / 45, this.gameObject.transform.position.y - 1.5f);
        DuplicatedRoot = Instantiate(this, DRPosition, Quaternion.Euler(0, 0, this.gameObject.transform.right.z + RandomValue));
        DuplicatedRoot.Value = 0;
        DuplicatedRoot.MaxValue = MaxValue + AddedMaxValue;
        DuplicatedRoot.GetComponent<Rigidbody2D>().mass = 1;
        DuplicatedRoot.HasDuplicated = false;

        DuplicatedRoot.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        Debug.Log(RandomValue);
        Debug.Log(DRPosition);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(HasDuplicated == false)
        {
            RootHp -= 1;

            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f /255f, 175f / 255f, (float)RootHp / (float)RootBaseHp);


            Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());

            if (RootHp <= 0)
            {
                this.gameObject.GetComponent<RacineClicker>().enabled = false;
            }

            if (collision.gameObject.tag == "Wall")
            {
                this.gameObject.GetComponent<RacineClicker>().enabled = false;
            }
        }
    }
}
