using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class SearchNewOfSensors : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI paragraphText;
    public Image mainImage;

    public string[] urlSites;

    int siteToVisit;

    void Start()
    {
        StartCoroutine(FetchDataFromWebsite());
        siteToVisit = Random.Range(0, urlSites.Length);
    }

    IEnumerator FetchDataFromWebsite()   
    {
        
        UnityWebRequest request = UnityWebRequest.Get(urlSites[siteToVisit]);
        yield return request.SendWebRequest();

        if(request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error Obteniendo información de la pagina: " + request.error);
        }
        else
        {
            string htmlContent = request.downloadHandler.text;

            string titlePattern = @"<title>(.*?)<\/title>";
            Match titleMatch = Regex.Match(htmlContent, titlePattern);
            if(titleMatch.Success)
            {
                titleText.text = titleMatch.Groups[1].Value;
            }
            // Suponiendo que el párrafo principal está contenido en las primeras etiquetas <p></p>
            string paragraphPattern = @"<p.*?>(.*?)<\/p>";
            MatchCollection paragraphMatches = Regex.Matches(htmlContent, paragraphPattern);

            
            string firstParagraph = paragraphMatches[0].Groups[1].Value;
            string secondParagraph = paragraphMatches[1].Groups[1].Value;
            string thirdParagraph = paragraphMatches[2].Groups[1].Value;
            string fourthParagraph = paragraphMatches[3].Groups[1].Value;
            paragraphText.text = firstParagraph + "; " + "\n" +secondParagraph + "; " + "\n" + thirdParagraph + "; " + "\n" + fourthParagraph;
                
   
            // Suponiendo que la imagen principal tiene una etiqueta <img> (esto obtendría la primera imagen)
            string imgPattern = @"<img.*?src=['""](.*?)['""]";
            Match imgMatch = Regex.Match(htmlContent, imgPattern);
            if (imgMatch.Success)
            {
                string imgUrl = imgMatch.Groups[1].Value;

                // Si la URL de la imagen es relativa, añadir el dominio principal
                if (!imgUrl.StartsWith("http"))
                {
                    string domain = new System.Uri(urlSites[siteToVisit]).GetLeftPart(System.UriPartial.Authority);
                    imgUrl = domain + imgUrl;
                }

                StartCoroutine(DownloadImage(imgUrl));
            }
        }
    }

    IEnumerator DownloadImage(string imageUrl)
    {
        UnityWebRequest imgRequest = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return imgRequest.SendWebRequest();

        if (imgRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error downloading image: " + imgRequest.error);
        }
        else
        {
            Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(imgRequest);
            mainImage.sprite = Sprite.Create(downloadedTexture, new Rect(0, 0, downloadedTexture.width, downloadedTexture.height), new Vector2(0.5f, 0.5f));
        }
    }

    public void OpenWebPage()
    {
        Application.OpenURL(urlSites[siteToVisit]);
    }


}
