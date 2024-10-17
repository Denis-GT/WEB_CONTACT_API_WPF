using LIB_CONTACT;
using Microsoft.AspNetCore.Mvc;

namespace WEB_API_CONTACT.CONTROLLERS
{
  [ApiController]
  [Route("/CONTACTS")]

  public class CONTACT : ControllerBase
  {
    C_BASE _Base;
    public CONTACT(C_BASE P_Base)
    {
      _Base = P_Base;
    }

    //----------------------------

    [HttpGet("GetDate", Name = "GetDate")]
    public string Get_Date()
    {
      return DateTime.Now.ToString();
    }

    [HttpGet("GetAllContacts", Name = "GetAllContacts")]
    public List<C_CONTACT> Get_All_Contacts() => _Base.Get_All_Contacts();

    [HttpPost("AddContact", Name = "AddContact")]
    public ActionResult <C_CONTACT> Add_Contact([FromBody] C_CONTACT P_Contact) {
      var Nouveau = _Base.Add_Contact(P_Contact.Nom, P_Contact.Prenom, P_Contact.Mail, P_Contact.Num_Tel);
      if (Nouveau != null) return Ok(Nouveau);
      else return NoContent();
    }

    [HttpGet("Save", Name = "Save")]
    public void Save()
    {
      _Base.Save();
    }

    [HttpDelete("DeleteContact", Name = "DeleteContact")]
    public ActionResult Delete_Contact(int P_Id)
    {
      bool Delete_Ok = _Base.Delete_Contact(P_Id);
      if (Delete_Ok) return Ok();
      else return NotFound(P_Id);
    }

    [HttpPut("UpdateContact", Name = "UpdateContact")]
    public ActionResult UpdateContact([FromBody] C_CONTACT P_Contact)
    {
      bool UpdateOk = _Base.Update_Contact(P_Contact);

      if (UpdateOk) return Ok();
      else return NotFound(P_Contact.Id);
    }

    [HttpDelete("DeleteAll", Name = "DeleteAll")]
    public void Delete_All()
    {
      _Base.Delete_All_Contacts();
    }
  }
}
