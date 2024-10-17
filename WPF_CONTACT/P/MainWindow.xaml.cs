using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_CONTACT.C;

namespace WPF_CONTACT
{

  public partial class MainWindow : Window
  {
    C_COORDINATION La_Coordination;
    public MainWindow()
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

    private void BTN_Ajouter_Personne_Click(object sender, RoutedEventArgs e)
    {
      C_CADRE_AJOUTER Cadre_Ajouter = new C_CADRE_AJOUTER();
      Cadre_Ajouter.Show();
    }

    private void BTN_Sauvegarder_Click(object sender, RoutedEventArgs e)
    {
      La_Coordination.Sauvegarde();
      La_Coordination.Update();
    }

    private void BTN_Modifier_Personne_Click(object sender, RoutedEventArgs e)
    {
      C_CADRE_MODIFIER Cadre_Modifier = new C_CADRE_MODIFIER(La_Coordination);
      Cadre_Modifier.Show();
    }

    private void LSTB_Contacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (LSTB_Contacts.SelectedItem != null) {
        BTN_Modifier_Personne.IsEnabled = true;
        BTN_Supprimer_Personne.IsEnabled = true;
      } else { 
        BTN_Modifier_Personne.IsEnabled = false;
        BTN_Supprimer_Personne.IsEnabled = false;
      }
    }

    private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      La_Coordination.Sauvegarde();
      La_Coordination.Update();
    }

    private void BTN_Supprimer_Personne_Click(object sender, RoutedEventArgs e)
    {
      La_Coordination.Supprime_Contact();
      La_Coordination.Update();
    }
  }
}