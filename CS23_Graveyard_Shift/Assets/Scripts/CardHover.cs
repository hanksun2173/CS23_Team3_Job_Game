using UnityEngine;
using TMPro;

public class CardHover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 initialScale;
    // public GameObject EnemyHealth;
    public TMP_Text EnemyHealth;
    private int EnemyHealthValue;
    void Start()
    {
        initialScale = transform.localScale;
        // EnemyHealthValue = int.TryParse(EnemyHealth.GetComponent<Text>().text);
        EnemyHealth = GetComponent<TextMeshProUGUI>();
        int.TryParse(EnemyHealth.text, out int EnemyHealthValue);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        transform.localScale = initialScale * 1.1f;
    }

    void OnMouseExit()
    {
        transform.localScale = initialScale;
    }

    void OnMouseDown()
    {
        EnemyHealthValue -= 1;
        // EnemyHealth.GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        
    }

}
