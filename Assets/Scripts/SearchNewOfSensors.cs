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
        siteToVisit = Random.Range(0, urlSites.Length);
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
                string stringWithoutHtmlTags = Regex.Replace(titleText.text, "<.*?>|[#&$&@]|[\r\n]", string.Empty);
                titleText.text = stringWithoutHtmlTags;
            }
            // Suponiendo que el párrafo principal está contenido en las primeras etiquetas <p></p>
            string paragraphPattern = @"<p.*?>(.*?)<\/p>";
            MatchCollection paragraphMatches = Regex.Matches(htmlContent, paragraphPattern);

            
            string firstParagraph = paragraphMatches[0].Groups[1].Value;
            string Pwithout1 = Regex.Replace(firstParagraph, "<.*?>|[#&$&@]|[\r\n]", string.Empty);
            
            string secondParagraph = paragraphMatches[1].Groups[1].Value;
            string Pwithout2 = Regex.Replace(secondParagraph, "<.*?>|[#&$&@]|[\r\n]", string.Empty);

            string thirdParagraph = paragraphMatches[2].Groups[1].Value;
            string Pwithout3 = Regex.Replace(thirdParagraph, "<.*?>|[#&$&@]|[\r\n]", string.Empty);

            string fourthParagraph = paragraphMatches[3].Groups[1].Value;
            string Pwithout4 = Regex.Replace(fourthParagraph, "<.*?>|[#&$&@]|[\r\n]", string.Empty);

            paragraphText.text = Pwithout1 + "\n" + "\n" + Pwithout2 + "\n" + "\n" + Pwithout3 + "\n" + "\n" + Pwithout4;


            
            bool imgTagExists = Regex.IsMatch(htmlContent, "<img");

            if (imgTagExists)
            {
                // Suponiendo que la imagen principal tiene una etiqueta <img> (esto obtendría la primera imagen)
                string imgPattern = @"<img.*?src=['""](.*?)['""]";
                // Comprueba si existe una etiqueta <img>
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
        if(Application.platform != RuntimePlatform.WindowsPlayer || Application.platform != RuntimePlatform.OSXPlayer || Application.platform != RuntimePlatform.LinuxPlayer)
        Application.OpenURL(urlSites[siteToVisit]);
    }


}
