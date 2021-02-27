using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footballer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        setupborders();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        shoot();
    }

    [SerializeField] float runspeed = 10f;

    private void move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * runspeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xmin, xmax);
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * runspeed;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, ymin, ymax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    float xmin, xmax, ymin, ymax;
    [SerializeField] float padding = 1f;

    private void setupborders()
    {
        Camera gameCamera = Camera.main;

        xmin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xmax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        ymin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        ymax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    [SerializeField] GameObject ballprefab;
    [SerializeField] float shootspeed = 20f;
    [SerializeField] float shootingtime = 2f;

    Coroutine shootingcoroutine;
    private void shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shootingcoroutine =  StartCoroutine(shootcontinuously());
        }

        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(shootingcoroutine);
        }
    }
    IEnumerator shootcontinuously()
    {
        while (true)
        {
            float ranNum = Random.Range(-2f, 2f);
            GameObject ball = Instantiate(ballprefab, this.transform.position, Quaternion.identity) as GameObject;
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(ranNum, shootspeed);

            yield return new WaitForSeconds(shootingtime);
        }
    }
}
