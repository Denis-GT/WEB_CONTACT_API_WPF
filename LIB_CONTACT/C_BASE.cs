using System.ComponentModel.Design;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LIB_CONTACT
{
  public class C_CONTACT
  {
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Mail { get; set; }
    public string Num_Tel { get; set; }
  }

  //###################################################

  public class C_BASE
  {
    const string NOM_BASE_JSON = "Base_Json.json";
    static int _Id_Contact_Base = 0;

    //--------------------------------------------------
    public List<C_CONTACT> Les_Contacts { get; private set; }

    //--------------------------------------------------------

    public C_BASE()
    {
      if (File.Exists(NOM_BASE_JSON)) {
        var Data_Json = File.ReadAllText(NOM_BASE_JSON);
        Les_Contacts = JsonSerializer.Deserialize<List<C_CONTACT>>(Data_Json);
        foreach (var Contact in Les_Contacts) {
          if (Contact.Id > _Id_Contact_Base) _Id_Contact_Base = Contact.Id;
        }
      } else {
        Les_Contacts = new List<C_CONTACT>();
        _Id_Contact_Base = 0;
      }
    }

    //--------------------------------------------------------------------
    public List<C_CONTACT> Get_All_Contacts()
    {
      return Les_Contacts;
    }
    //--------------------------------------------------------------------

    public C_CONTACT Add_Contact(string P_Nom, string P_Prenom, string P_Mail, string P_Num_Tel)
    {
      var Trouve = Les_Contacts.Where(c => c.Nom == P_Nom & c.Prenom == P_Prenom & c.Mail == P_Mail & c.Num_Tel == P_Num_Tel).FirstOrDefault();
      if (Trouve == null) {
        _Id_Contact_Base++;

        var Nouveau = new C_CONTACT() { Id = _Id_Contact_Base, Nom = P_Nom, Prenom = P_Prenom, Mail = P_Mail, Num_Tel = P_Num_Tel };
        Les_Contacts.Add(Nouveau);

        return Nouveau;

      } else return null;
    }
    public bool Delete_Contact(int P_Id)
    {
      var Trouve = Les_Contacts.Where(c => c.Id == P_Id).FirstOrDefault();
      if (Trouve != null) {
        Les_Contacts.Remove(Trouve);
        return true;
      } else return false;
    }

    public bool Update_Contact(C_CONTACT P_Contact)
    {
      var Trouve = Les_Contacts.Where(c => c.Id == P_Contact.Id).FirstOrDefault();
      if (Trouve != null) {
        Trouve.Nom = P_Contact.Nom;
        Trouve.Prenom = P_Contact.Prenom;
        Trouve.Mail = P_Contact.Mail;
        Trouve.Num_Tel = P_Contact.Num_Tel;
        return true;
      } else return false;
    }
    public void Load()
    {
      var Data_Json = File.ReadAllText(NOM_BASE_JSON);
      Les_Contacts = JsonSerializer.Deserialize<List<C_CONTACT>>(Data_Json);
      foreach (var Contact in Les_Contacts) {
        if (Contact.Id > _Id_Contact_Base) _Id_Contact_Base++;
      }
    }
    public void Save()
    {
      var Data_Json = JsonSerializer.Serialize(Les_Contacts);
      File.WriteAllText(NOM_BASE_JSON, Data_Json);
    }

    public void Delete_All_Contacts()
    {
      Les_Contacts.Clear();
    }
  }
}
