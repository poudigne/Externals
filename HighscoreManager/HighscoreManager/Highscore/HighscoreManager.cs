using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace HighscoreManager.Highscore
{
  public class HighscoreManager
  {

    private const String GET_LINK = "http://api.francoischolette.com/api/1.0/{0}/get";
    private const String POST_LINK = "http://api.francoischolette.com/api/1.0/{0}/post/{1}/{2}";

    private String gameName { get; set; }

    public HighscoreManager(String gameName)
    {
      this.gameName = gameName;
    }

    public string RetrieveHighscore()
    {
      var link = String.Format(GET_LINK, this.gameName);
      var response = this.SendRequest(link);
      return "TEST" + response;
    }

    public void PostHighscore(string playerName, int score)
    {
      var link = String.Format(POST_LINK, this.gameName, playerName, score);
      var response = this.SendRequest(link);
    }

    private string SendRequest(string link)
    {
      // Create a request for the URL. 		
      var request = WebRequest.Create(link);
      // If required by the server, set the credentials.
      request.Credentials = CredentialCache.DefaultCredentials;
      // Get the response.

			request.Method = "POST";
			request.


      var response = (HttpWebResponse)request.GetResponse();
      // Display the status.
      Console.WriteLine(response.StatusDescription);
      // Get the stream containing content returned by the server.
      var dataStream = response.GetResponseStream();
      // Open the stream using a StreamReader for easy access.
      var reader = new StreamReader(dataStream);
      // Read the content. 
      var responseFromServer = reader.ReadToEnd();
      // Display the content.
      Console.WriteLine(responseFromServer);
      // Cleanup the streams and the response.
      reader.Close();
      dataStream.Close();
      response.Close();

      return responseFromServer;
    }
  }
}
