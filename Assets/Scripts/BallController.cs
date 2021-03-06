﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {

    public float speed = 1f;
    public float sideSpeed = 2f;
    private Vector2 screenDivision = new Vector2(Screen.width / 2, (Screen.height / 3)*2);
    private Vector2 touchPosition = new Vector2(Screen.width / 2, (Screen.height / 3) * 2);
    private bool bouncing = false;

    public GameObject splash;
    public GameObject collision;
    public Sprite[] paints;
    private Sprite paint;
    private int rand;
    private int colorIndex = 0;
    private GameObject instance;
    private Vector4[] colorList = new Vector4[3];
    public AudioClip splashSound;
    public AudioClip bounceSound;
    public AudioClip endSound;
    private GameObject audioSource;

    void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.tag == "Block") {
            if (audioSource != null) {
                audioSource.GetComponent<AudioSource>().PlayOneShot(splashSound, 1);
            }

            collision.GetComponent<ParticleSystem>().startColor = this.transform.GetComponent<SpriteRenderer>().color;
            Instantiate(collision, this.transform.position, collision.transform.rotation);

            rand = Random.Range(0, paints.Length - 1);

            paint = Sprite.Create(paints[rand].texture, new Rect(paints[rand].rect.x, paints[rand].rect.y, paints[rand].rect.width, paints[rand].rect.height), new Vector2(0.5f, 0.5f), 100);

            splash.GetComponent<SpriteRenderer>().color = this.transform.GetComponent<SpriteRenderer>().color;
            splash.transform.position = collider.contacts[0].point;
            splash.transform.rotation = collider.transform.rotation;

            splash.GetComponent<SpriteRenderer>().sprite = paint;
            instance = (GameObject)Instantiate(splash);
            instance.transform.parent = collider.gameObject.transform;
            hit();
        } else if (collider.gameObject.tag == "End") {
            if (audioSource != null) {
                audioSource.GetComponent<AudioSource>().PlayOneShot(endSound, 1);
            }
            SceneManager.LoadScene("Levels");

        } else {
            StartCoroutine("bounceDelay");
            if (touchPosition.x > screenDivision.x) {
                touchPosition.x = screenDivision.x - 1;
            } else if (touchPosition.x < screenDivision.x) {
                touchPosition.x = screenDivision.x + 1;
            }

            if (audioSource != null) {
                audioSource.GetComponent<AudioSource>().PlayOneShot(bounceSound, 0.4f);
            }
        }
    }

    // Use this for initialization
    void Start() {
        colorList[0] = new Vector4(0, 0, 1, 1);
        colorList[1] = new Vector4(1, 0, 0, 1);
        colorList[2] = new Vector4(0, 1, 0, 1);
        this.transform.GetComponent<SpriteRenderer>().color = colorList[colorIndex];

        audioSource = GameObject.Find("AudioEffects");
    }

    // Update is called once per frame
    void Update() {
        //keyboard debug
        if (Input.GetAxisRaw("Horizontal") < 0 && !bouncing) {
            touchPosition.x = screenDivision.x - 1;
        } else if (Input.GetAxisRaw("Horizontal") > 0 && !bouncing) {
            touchPosition.x = screenDivision.x + 1;
        }

        if (Input.touchCount > 0 && !bouncing && Input.touches[0].position.y < screenDivision.y) {
            touchPosition = Input.touches[0].position;
        }
        if (touchPosition.x > screenDivision.x) {
            this.transform.Translate(Vector2.right * sideSpeed * Time.deltaTime);
        } else if (touchPosition.x < screenDivision.x) {
            this.transform.Translate(Vector2.left * sideSpeed * Time.deltaTime);
        }

        if (this.transform.GetComponent<Rigidbody2D>().isKinematic == false) {
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    public void hit() {
        this.transform.GetComponent<CircleCollider2D>().enabled = false;
        this.transform.GetComponent<Rigidbody2D>().isKinematic = true;
        this.transform.GetComponent<SpriteRenderer>().enabled = false;
        //particles
        StartCoroutine("deadDelay");
    }

    IEnumerator deadDelay() {
        yield return new WaitForSeconds(0.7f);

        if (colorIndex < colorList.Length - 1) {
            colorIndex++;
        } else {
            colorIndex = 0;
        }
        this.transform.GetComponent<SpriteRenderer>().color = colorList[colorIndex];

        this.transform.position = new Vector2(0, 0);
        this.transform.GetComponent<SpriteRenderer>().enabled = true;
        this.transform.GetComponent<Rigidbody2D>().isKinematic = false;
        this.transform.GetComponent<CircleCollider2D>().enabled = true;
    }

    IEnumerator bounceDelay() {
        bouncing = true;
        yield return new WaitForSeconds(0.1f);
        bouncing = false;
    }
}
