using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NS_WS;

namespace WPF_CONTACT.C
{
  class C_COORDINATION : C_NOTIFIABLE
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

    private List<C_CONTACT>_Contact_Selectionne;
    public List<C_CONTACT> Contact_Selectionne {
      get { return _Contact_Selectionne; }
      set { _Contact_Selectionne = value; Signale_Changement(); }
    }
  }
}