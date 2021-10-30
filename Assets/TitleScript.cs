using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float speed = 5.0f;
    public float threshold = float.Epsilon;

    public bool faded = false;

    public SpriteRenderer sprite;

    void Update () {
        float step = speed * Time.deltaTime;

        if (faded) {
            sprite.color = new Color(1f, 1f, 1f, Mathf.Lerp(sprite.color.a, maximum, step));
            if (Mathf.Abs(maximum - sprite.color.a) <= threshold)
                faded = false;

        } else {
            sprite.color = new Color(1f, 1f, 1f, Mathf.Lerp(sprite.color.a, minimum, step));
            if (Mathf.Abs(sprite.color.a - minimum) <= threshold)
                faded = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("0");
        }
    }
}
