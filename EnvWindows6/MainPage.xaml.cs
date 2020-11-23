using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using EnvWindows6.Données;
using Windows.UI.Popups;
using System;
// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EnvWindows6
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Contacts donneesContacts = new Contacts();
        private Contact contactSelect;
        private Contact inputContact = new Contact("", "", "");

        public MainPage()
        {
            this.InitializeComponent();
            donneesContacts.chargementContacts();
            listeContacts.DataContext = donneesContacts;
        }

        private void listeContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listeContacts.SelectedIndex != -1)
            {
                contactSelect = (Contact)listeContacts.SelectedItem;
                uiName.Text = contactSelect.Nom;
                uiPrenom.Text = contactSelect.Prénom;
                uiNumero.Text = contactSelect.Numéro;
            }
        }

        private async void BoutonCreer_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Création du Contact : \n\tNom : " + uiName.Text + " \n\tPrénom : " + uiPrenom.Text + " \n\tNuméro : " + uiNumero.Text);
            await dialog.ShowAsync();
            donneesContacts.Add(new Contact(uiName.Text, uiPrenom.Text, uiNumero.Text));
        }

        private async void BoutonModifier_Click(object sender, RoutedEventArgs e)
        {
            if(listeContacts.SelectedItem == null)
            {
                var dialog = new MessageDialog("Veuillez sélectionner un contact dans le liste avant de modifier");
                await dialog.ShowAsync();
            }
            else
            {
                contactSelect = (Contact)listeContacts.SelectedItem;
                donneesContacts[contactSelect].Nom = uiName.Text;
                donneesContacts[contactSelect].Prénom = uiPrenom.Text;
                donneesContacts[contactSelect].Numéro = uiNumero.Text;
                //Force Mise à jour de l'affichage de la listBox lors d'une modification d'un Contact déjà existant
                listeContacts.DisplayMemberPath = "";
                listeContacts.DisplayMemberPath = "ContactString";
                var dialog = new MessageDialog("Modification du Contact : \n\tNom : " + uiName.Text + " \n\tPrénom : " + uiPrenom.Text + " \n\tNuméro : " + uiNumero.Text);
                await dialog.ShowAsync();
            }
        }

        private async void BoutonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (listeContacts.SelectedItem == null)
            {
                var dialog = new MessageDialog("Veuillez sélectionner un contact dans le liste avant de le supprimer");
                await dialog.ShowAsync();
            }
            else
            {
                contactSelect = (Contact)listeContacts.SelectedItem;
                listeContacts.SelectedIndex = -1;
                donneesContacts.Remove(contactSelect);
                var dialog = new MessageDialog("Suppression du Contact : \n\tNom : " + uiName.Text + " \n\tPrénom : " + uiPrenom.Text + " \n\tNuméro : " + uiNumero.Text);
                await dialog.ShowAsync();
            }
        }
        
        private void uiName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //inputContact.Nom = uiName.Text;
        }

        private void uiPrenom_TextChanged(object sender, TextChangedEventArgs e)
        {
            //inputContact.Prénom = uiPrenom.Text;
        }

        private void uiNumero_TextChanged(object sender, TextChangedEventArgs e)
        {
            //inputContact.Numéro = uiNumero.Text;
        }
    }
}
