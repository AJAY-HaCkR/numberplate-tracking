using UnityEngine;

public class InfoManager : MonoBehaviour
{
    public GameObject infoPrefab;
    public Camera arCamera;

    private Dictionary<string, (string name, string phone)> database = new Dictionary<string, (string, string)>()
    {
        { "TN01AB1234", ("Ajay Surya", "9876543210") },
        { "TN02XY4321", ("muhtukumaranr", "9123456780") },
        { "TN03CD6789", ("giri", "9001234567") }
    };

    public void ShowInfo(string numberPlate)
    {
        if (database.ContainsKey(numberPlate))
        {
            Vector3 position = arCamera.transform.position + arCamera.transform.forward * 1.5f;
            GameObject info = Instantiate(infoPrefab, position, Quaternion.identity);
            var text = info.GetComponent<TextMesh>();
            (string name, string phone) = database[numberPlate];
            text.text = $"Owner: {name}\nPhone: {phone}";
        }
        else
        {
            Debug.Log("Number not found in database.");
        }
    }
}

