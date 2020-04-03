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
using cooking;

namespace WpfApp2
{
    /// <summary>
    /// Logique d'interaction pour commande.xaml
    /// </summary>
    public partial class commande : Window
    {
        public commande()
        {
            InitializeComponent();
            // Initialisation Combox Recettes
            string[] recettes = MainClass.get_nom_recette();
            for (int i = 0; i < recettes.Length; i++)
            {
                combobox_commande.Items.Add(recettes[i]);
                combobox_recettes.Items.Add(recettes[i]);
            }
        }

        private void ajouter_panier(object sender, RoutedEventArgs e)
        {
            int prix = 0;
            if (combobox_commande.SelectedItems.Count > 1)
                for (int i= 0; i < combobox_commande.SelectedItems.Count; i++)
                {
                    combobox_commande_panier.Items.Add(combobox_commande.Items[i]);
                    prix += MainClass.prix_recette((string)combobox_commande.Items[i])[0] + Convert.ToInt32(prix_commande.Content);
                }
            else
            {
                combobox_commande_panier.Items.Add(combobox_commande.SelectedItem);
                prix += MainClass.prix_recette((string)combobox_commande.SelectedItem)[0] + Convert.ToInt32(prix_commande.Content);
            }
            prix_commande.Content = Convert.ToString(prix);
        }

        private void payer_commande(object sender, RoutedEventArgs e)
        {
            if (MainClass.peutPayerClient(((MainWindow)System.Windows.Application.Current.MainWindow).choix_id_client.SelectedItem.ToString(), Convert.ToInt32(prix_commande.Content)))
            {
                MainClass.Achat(((MainWindow)System.Windows.Application.Current.MainWindow).choix_id_client.SelectedItem.ToString(), Convert.ToInt32(prix_commande.Content));
                MessageBox.Show("Commande validée ! Le livreur va vous contacter très prochainement");
                // Ajouter commande à la base de donnée de commande
            }
            else
            {
                MessageBox.Show("Votre solde est insufisant ...");

            }
        }
    }
}
