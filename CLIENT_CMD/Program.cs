using NS_WS;

namespace CLIENT_CMD
{
  internal class Program
  {
    static void Main(string[] args)
    {
      C_WS Le_WS = new C_WS("https://webdg.azurewebsites.net/", new HttpClient());

      try {
        //var Nouveau = Le_WS.AddContactAsync(new C_CONTACT() { Nom = "TOTO", Prenom = "toto", Mail = "toto@gmail.com" }).Result;
      }
      catch (Exception P_Message) {

        Console.WriteLine(P_Message);
      }

      var Liste_Contatcts = Le_WS.GetAllContactsAsync().Result;
      foreach (var contact in Liste_Contatcts) {
        Console.WriteLine($"{contact.Id} {contact.Nom} {contact.Prenom}");
      }
    }
  }
}
