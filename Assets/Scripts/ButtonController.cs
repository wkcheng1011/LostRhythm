using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public static ButtonController instance;

    private SpriteRenderer spriteRenderer;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            Color color = spriteRenderer.color;
            color.a = 1f;
            spriteRenderer.color = color;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            Color color = spriteRenderer.color;
            color.a = 0.75f;
            spriteRenderer.color = color;
        }
    }
}
