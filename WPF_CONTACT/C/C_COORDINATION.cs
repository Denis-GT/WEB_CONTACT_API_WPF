using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NS_WS;

namespace WPF_CONTACT.C
{
  public class C_COORDINATION : C_NOTIFIABLE
  {
    C_WS Le_WS;

    public C_COORDINATION()
    {
      Le_WS = new C_WS("https://webdg.azurewebsites.net/", new HttpClient());
      Liste_Contacts = Le_WS.GetAllContactsAsync().Result.ToList();
    }

    private List<C_CONTACT> _Liste_Contacts;
    public List<C_CONTACT> Liste_Contacts {
      get { return _Liste_Contacts; }
      set { _Liste_Contacts = value; Signale_Changement(); }
    }

    private C_CONTACT _Contact_Selectionne;
    public C_CONTACT Contact_Selectionne {
      get { return _Contact_Selectionne; }
      set { _Contact_Selectionne = value; Signale_Changement(); }
    }

    //-----------------------------------------

    public void Ajoute_Contact(string P_Nom, string P_Prenom, string P_Mail, string P_Num_Tel)
    {
      Le_WS.AddContactAsync(new C_CONTACT() { Nom = P_Nom, Prenom = P_Prenom, Mail = P_Mail, Num_Tel = P_Num_Tel });
      Update();

    }

    internal void Sauvegarde()
    {
      Le_WS.SaveAsync().Wait();
    }

    internal void Modifie_Contact(int P_Id, string P_Nom, string P_Prenom, string P_Mail, string P_Num_Tel)
    {
      Le_WS.UpdateContactAsync(new C_CONTACT() { Id = P_Id, Nom = P_Nom, Prenom = P_Prenom, Mail = P_Mail, Num_Tel = P_Num_Tel });
      Update();
    }

    internal void Supprime_Contact()
    {
      Le_WS.DeleteContactAsync(Contact_Selectionne.Id);
      Update();
    }

    internal void Update()
    {
      Liste_Contacts = Le_WS.GetAllContactsAsync().Result.ToList();
    }
  }
}