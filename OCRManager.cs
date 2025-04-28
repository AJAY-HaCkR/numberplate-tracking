using UnityEngine;
using Tesseract;

public class OCRManager : MonoBehaviour
{
    public ARCameraCapture arCameraCapture;
    public InfoManager infoManager;

    private TesseractDriver ocrDriver;

    void Start()
    {
        ocrDriver = new TesseractDriver();
        ocrDriver.Setup(OnTesseractSetup);
    }

    void OnTesseractSetup()
    {
        Debug.Log("Tesseract Ready!");
    }

    public void Scan()
    {
        Texture2D image = arCameraCapture.CaptureFrame();
        ocrDriver.Recognize(image, OnRecognized);
    }

    void OnRecognized(string text)
    {
        string numberPlate = CleanText(text);
        infoManager.ShowInfo(numberPlate);
    }

    string CleanText(string raw)
    {
        return raw.Replace("\n", "").Replace(" ", "").ToUpper();
    }
}
