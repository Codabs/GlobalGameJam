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
    public Quaternion DRRotation;

    public Vector3 RemovedValue;

    public Sprite RacineSprite;
    public Sprite EndOfRacineSprite;

    public SpriteRenderer _SpriteRenderer;
    public RacineClicker DuplicatedRoot;
    public GameObject RacinesManager;

    public void Start()
    {
        RacinesManager = GameObject.Find("RacinesManager");
        _SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        RootHp = RootBaseHp;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = RacineSprite;
    }

    public void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Value += 1;
        }*/

        if (Value >= MaxValue && HasDuplicated == false)
        {
            HasDuplicated = true;
            MoveDownClickableZone.Instance.MoveDown();
            this.gameObject.GetComponent<Rigidbody2D>().mass = 1000;
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            RandomValue = UnityEngine.Random.Range(Range/10, Range);
            Duplicate();
            RandomValue = -RandomValue;
            Duplicate();
        }
    }

    public void Duplicate()
    {
        DRRotation = Quaternion.Euler(0, 0, this.gameObject.transform.right.z + RandomValue);
        //DRPosition = new Vector3(this.gameObject.transform.position.x + RandomValue / 45, this.gameObject.transform.position.y - 1.5f);

        DRPosition += /*this.gameObject.transform.TransformDirection*/(new Vector3((Mathf.Clamp01(RandomValue) - 0.5f) * 0.75f, -1.5f));

        Debug.Log(DRPosition.ToString());

        DuplicatedRoot = Instantiate(this, DRPosition, DRRotation, RacinesManager.transform);
        DuplicatedRoot.transform.localPosition = DRPosition;

        DuplicatedRoot.Value = 0;
        DuplicatedRoot.MaxValue = MaxValue + AddedMaxValue;
        DuplicatedRoot.GetComponent<Rigidbody2D>().mass = 1;
        DuplicatedRoot.HasDuplicated = false;

        DuplicatedRoot.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (HasDuplicated == false)
        {
            RootHp -= 1;

            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f / 255f, 175f / 255f, (float)RootHp / (float)RootBaseHp);

            Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());

            if (RootHp <= 0)
            {
                this.gameObject.GetComponent<RacineClicker>().enabled = false;

                Resize();

                this.gameObject.GetComponent<SpriteRenderer>().color = new Color((float)RootHp / (float)RootBaseHp, 175f / 255f, (float)RootHp / (float)RootBaseHp);

                this.gameObject.GetComponent<SpriteRenderer>().sprite = EndOfRacineSprite;
            }
        }

        if (collision.gameObject.tag == "Wall")
        {
            this.gameObject.GetComponent<RacineClicker>().enabled = false;
        }
    }

    public void Resize()
    {
        RemovedValue = new Vector3(this.gameObject.transform.localScale.x / 1.25f, this.gameObject.transform.localScale.y / 1.25f);

        this.gameObject.transform.position += transform.TransformDirection(Vector3.up * RemovedValue.y * 0.25f);

        this.gameObject.transform.localScale = RemovedValue;


    }
}
