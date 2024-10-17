using Bogus;
using LIB_CONTACT;

namespace TEST_LIB_CMD
{
  internal class Program
  {
    static void Main(string[] args)
    {
      C_BASE La_Base = new C_BASE();
      var Liste_Contacts = La_Base.Get_All_Contacts();

      //for (int i = 0; i < 20; i++) {
      //  Faker Generateur = new Faker("fr");
      //  La_Base.Add_Contact(Generateur.Name.LastName(), Generateur.Name.FirstName(), $"{Generateur.Name.LastName()}@gmail.com");
      //}

      //La_Base.Update_Contact(new C_CONTACT() { Id = 2, Nom = "TATA", Prenom = "Ben", Mail = "Ben@mail.com" });
      //La_Base.Delete_Contact(10);

      //Console.WriteLine(Liste_Contacts.Count());
      //foreach (var Contact in Liste_Contacts) { Console.WriteLine($"{Contact.Id} {Contact.Nom} {Contact.Prenom} {Contact.Mail}"); }
      La_Base.Save();
    }
  }
}
