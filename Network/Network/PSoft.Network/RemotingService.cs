using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Policy;
using log4net;

namespace Network.PSoft.Network
{
  public class RemotingService
  {
    private String gameName { get; set; }
    private static RemotingService instance;

    public RemotingService()
    {

    }
    public RemotingService(string name)
    {
      gameName = name;
    }

    public RemotingService GetInstance()
    {
      if (instance == null)
        instance = new RemotingService(string.Empty);
      return instance;
    }

    public string GetGameName()
    {
      return this.gameName;
    }

    public string SendRequest(string link)
    {
      // Create a request for the URL. 		
      var request = WebRequest.Create(link);
      // If required by the server, set the credentials.
      request.Credentials = CredentialCache.DefaultCredentials;
      var log = LogManager.GetLogger("DefaultFileLogger");
      log.Debug(String.Format("Sending message : {0}",link));
      
      // Get the response
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
      log.Debug(String.Format("Received response : {0}", responseFromServer));
      // Cleanup the streams and the response.
      reader.Close();
      dataStream.Close();
      response.Close();

      return responseFromServer;
    }
  }



  public enum RequestMethod
  {
    Post,
    Method
  }

  public enum RequestAction
  {
    GetHighscore,
    Login,
    CreateUser
  }
}
