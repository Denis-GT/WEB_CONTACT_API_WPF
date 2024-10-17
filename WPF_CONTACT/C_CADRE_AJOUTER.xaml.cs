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
  /// Logique d'interaction pour C_CADRE_AJOUTER.xaml
  /// </summary>
  public partial class C_CADRE_AJOUTER : Window
  {
    C_COORDINATION La_Coordination;
    public C_CADRE_AJOUTER()
    {
      try {
        InitializeComponent();
        La_Coordination = new C_COORDINATION();
        DataContext = La_Coordination;
      }
      catch (Exception P_Expetion) {
        Console.WriteLine(P_Expetion);
      }
    }

    private void BTN_Ajouter_Click(object sender, RoutedEventArgs e)
    {
      La_Coordination.Ajoute_Contact(TXTB_Nom.Text, TXTB_Prenom.Text, TXTB_Mail.Text, TXTB_Tel.Text);
      this.Close();
    }
  }
}
