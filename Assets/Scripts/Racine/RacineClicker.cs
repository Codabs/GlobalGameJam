using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class RacineClicker : MonoBehaviour
{
    public int RootBaseHp;
    public int RootHp;
    public float Value;
    public float MaxValue;
    public float AddedMaxValue;
    public bool HasDuplicated;
    public int Range;
    public float RandomValue;

    public int RacinesNeededForNextPalier;
    public int RacinesInPalier;
    public int Palier;
    public Vector3 DRPosition;
    public Quaternion DRRotation;

    public Vector3 RemovedValue;

    public Sprite RacineSprite;
    public Sprite RacineSprite1;
    public Sprite RacineSprite2;
    public Sprite EndOfRacineSprite;
    public Sprite EndOfRacineSprite1;
    public Sprite EndOfRacineSprite2;

    public SpriteRenderer _SpriteRenderer;
    public RacineClicker DuplicatedRoot;
    public GameObject RacinesManager;

    public void Start()
    {
        RacinesManager = GameObject.Find("RacinesManager");
        _SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        RootHp = RootBaseHp;

        if((int)Random.Range(0, 2.99f) == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = RacineSprite;
        }
        if ((int)Random.Range(0, 2.99f) == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = RacineSprite1;
        }
        if ((int)Random.Range(0, 2.99f) == 3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = RacineSprite2;
        }

    }

    public void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Value += 1;
        }*/

        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(128f / 255f + (Value / MaxValue) /2, 128f / 255f + (Value / MaxValue) /2, 128f / 255f + (Value / MaxValue) /2);



        if (RacinesInPalier == RacinesNeededForNextPalier)
        {
            Value -= MaxValue * Time.deltaTime / 4;
        }

        if (Value >= MaxValue && HasDuplicated == false)
        {
            HasDuplicated = true;
            MoveDownClickableZone.Instance.MoveDown();
            this.gameObject.GetComponent<Rigidbody2D>().mass = 1000;
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            RandomValue = Random.Range(Range/10, Range);
            Duplicate();
            RandomValue = -RandomValue;
            Duplicate();
            this.gameObject.GetComponent<RacineClicker>().enabled = false;
        }
    }

    public void Duplicate()
    {
        DRRotation = Quaternion.Euler(0, 0, this.gameObject.transform.right.z + RandomValue);
        //DRPosition = new Vector3(this.gameObject.transform.position.x + RandomValue / 45, this.gameObject.transform.position.y - 1.5f);

        DRPosition += /*this.gameObject.transform.TransformDirection*/(new Vector3((Mathf.Clamp01(RandomValue) - 0.5f) * 0.75f, -1f));

        Debug.Log(DRPosition.ToString());

        DuplicatedRoot = Instantiate(this, DRPosition, DRRotation, RacinesManager.transform);
        DuplicatedRoot.transform.localPosition = DRPosition;

        DuplicatedRoot.Value = 0;
        DuplicatedRoot.RacinesInPalier += 1;
        if(RacinesInPalier >= RacinesNeededForNextPalier)
        {
            DuplicatedRoot.MaxValue = MaxValue * AddedMaxValue;
            DuplicatedRoot.Palier += 1;
            DuplicatedRoot.RacinesInPalier = 0;
        }



        DuplicatedRoot.GetComponent<Rigidbody2D>().mass = 1;
        DuplicatedRoot.HasDuplicated = false;

        DuplicatedRoot.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (HasDuplicated == false)
        {
            RootHp -= 1;

            //this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255f / 255f, 175f / 255f, (float)RootHp / (float)RootBaseHp);

            Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());

            if (RootHp <= 0)
            {
                Resize();

                //this.gameObject.GetComponent<SpriteRenderer>().color = new Color((float)RootHp / (float)RootBaseHp, 175f / 255f, (float)RootHp / (float)RootBaseHp);


                if ((int)Random.Range(0, 2.99f) == 0)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = EndOfRacineSprite;
                }
                if ((int)Random.Range(0, 2.99f) == 2)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = EndOfRacineSprite1;
                }
                if ((int)Random.Range(0, 2.99f) == 3)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = EndOfRacineSprite2;
                }

                this.gameObject.GetComponent<RacineClicker>().enabled = false;

                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
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

        this.gameObject.transform.position += transform.TransformDirection(Vector3.up * RemovedValue.y * 0.55f);

        this.gameObject.transform.localScale = RemovedValue;


    }
}
