using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_CONTACT.C;

namespace WPF_CONTACT
{
  /// <summary>
  /// Logique d'interaction pour C_CADRE_MODIFIER.xaml
  /// </summary>
  public partial class C_CADRE_MODIFIER : Window
  {
    C_COORDINATION La_Coordination;
    public C_CADRE_MODIFIER(C_COORDINATION P_Coordination)
    {
      try {
        InitializeComponent();
        La_Coordination = P_Coordination;
        DataContext = La_Coordination;
      }
      catch (Exception P_Expetion) {
        Console.WriteLine(P_Expetion);
      }
    }

    private void BTN_Modifier_Click(object sender, RoutedEventArgs e)
    {
      La_Coordination.Modifie_Contact(int.Parse(TXTB_M_Id.Text), TXTB_M_Nom.Text, TXTB_M_Prenom.Text, TXTB_M_Mail.Text, TXTB_M_Tel.Text);
      this.Close();
    }
  }
}
