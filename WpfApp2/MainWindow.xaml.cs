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
using System.Windows.Navigation;
using System.Windows.Shapes;
using cooking;

namespace WpfApp2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainClass.Creation_tables();

            // Initialisation ComboBox Clients
            string[] id_client = MainClass.get_id_client();
            for (int i = 0; i < id_client.Length; i++)
            {
                choix_id_client.Items.Add(id_client[i]);
            }
            choix_cdr.Items.Add("Oui");
            choix_cdr.Items.Add("Non");
        }

        private void connexion_client(object sender, RoutedEventArgs e)
        {
            // Verifier nom, prenom, identifiant et mot de passe
            if (choix_id_client.Text != "" && nom_client.Text != "" && prenom_client.Text != "" && mdp_client.Password != "" && MainClass.client_exists(choix_id_client.Text, nom_client.Text, prenom_client.Text, mdp_client.Password))
            {
                MessageBox.Show("Connexion réussie");  //A modifier

                // Cache les informations d'identification
                choix_id_client.Visibility = Visibility.Hidden;
                nom_client.Visibility = Visibility.Hidden; prenom_client.Visibility = Visibility.Hidden;
                choix_id_client.Visibility = Visibility.Hidden; mdp_client.Visibility = Visibility.Hidden;
                valider_identification.Visibility = Visibility.Hidden; mdp_label.Visibility = Visibility.Hidden;
                label_inscription.Visibility = Visibility.Hidden; label_tel.Visibility = Visibility.Hidden;
                tel_inscription.Visibility = Visibility.Hidden;button_inscription.Visibility = Visibility.Hidden;
                nom_inscription.Visibility = Visibility.Hidden;prenom_inscription.Visibility = Visibility.Hidden;
                adresse_inscription.Visibility = Visibility.Hidden;ville_inscription.Visibility = Visibility.Hidden;
                tel_inscription.Visibility = Visibility.Hidden; label_addr_insc.Visibility = Visibility.Hidden;
                label_nom_insc.Visibility = Visibility.Hidden; label_prenom_insc.Visibility = Visibility.Hidden;
                label_ville_insc.Visibility = Visibility.Hidden; label_tel.Visibility = Visibility.Hidden;
                cdr_label.Visibility = Visibility.Hidden;choix_cdr.Visibility = Visibility.Hidden;
                saisie1pass.Visibility = Visibility.Hidden;mdp_client_1.Visibility = Visibility.Hidden;
                saisie2pass.Visibility = Visibility.Hidden;mdp_client_2.Visibility = Visibility.Hidden;
                button_inscription.Visibility = Visibility.Hidden;
                // Affiche les infos compte client

                string[] infos_clients = MainClass.get_infos_clients(choix_id_client.Text, nom_client.Text, prenom_client.Text, mdp_client.Password); 

                nom_client_identifie.Content = nom_client.Text;
                nom_client_identifie.Visibility = Visibility.Visible;
                prenom_client_identifie.Content = prenom_client.Text;
                prenom_client_identifie.Visibility = Visibility.Visible;

                label_adresse.Visibility = Visibility.Visible;
                adresse_client.Visibility = Visibility.Visible;
                nom_client_identifie.Visibility = Visibility.Visible;
                prenom_client_identifie.Visibility = Visibility.Visible;
                label_solde.Visibility = Visibility.Visible;
                valeur_solde.Visibility = Visibility.Visible;
                choix_id_client_label.Visibility = Visibility.Visible;
                telephone_label.Visibility = Visibility.Visible;
                telephone_value.Visibility = Visibility.Visible;
                button_commander.Visibility = Visibility.Visible;


                adresse_client.Content = infos_clients[3] + " " + infos_clients[4];
                valeur_solde.Content = infos_clients[6];
                choix_id_client_label.Content = infos_clients[0];
                telephone_value.Content = infos_clients[7];

            }
            else if (choix_id_client.Text == "" ||  nom_client.Text == "" || prenom_client.Text == "" || mdp_client.Password == "")
            {
                MessageBox.Show("Champs manquants !");
            }
            else
            {
                MessageBox.Show("Client non reconnu !");
                nom_client.Text = String.Empty;
                prenom_client.Text = String.Empty;
                choix_id_client.Text = String.Empty;
                mdp_client.Clear();
            }

        }

        private void inscription_client(object sender, RoutedEventArgs e)
        {
            bool b = false;
            if (nom_inscription.Text != "" && prenom_inscription.Text != "" && adresse_inscription.Text != "" && ville_inscription.Text != "" && choix_cdr.Text != "" && mdp_client_1.Password != "" && mdp_client_2.Password != "" && mdp_client_1.Password == mdp_client_2.Password)
            {
                int cdr = 0;
                if (choix_cdr.Text == "Oui") cdr = 1;
                b = MainClass.inscrire_client_base(nom_inscription.Text, prenom_inscription.Text, adresse_inscription.Text, ville_inscription.Text, cdr, tel_inscription.Text, mdp_client_1.Password);
                if (b)
                {
                    MessageBox.Show("Inscription réussie !");
                    nom_inscription.Text = String.Empty;prenom_inscription.Text = String.Empty;adresse_inscription.Text = String.Empty;ville_inscription.Text = String.Empty;mdp_client_1.Password = String.Empty;mdp_client_2.Password = String.Empty;
                }
                else
                {
                    MessageBox.Show("Inscription échouée...");
                }
            }
            else if (mdp_client_1.Password != mdp_client_2.Password)
            {
                MessageBox.Show("Mots de passe non identiques !");
            }
            else if (nom_inscription.Text == "" || prenom_inscription.Text == "" || adresse_inscription.Text == "" || ville_inscription.Text == "" || choix_cdr.Text == "" || mdp_client_1.Password == "" || mdp_client_2.Password == "" || mdp_client_1.Password == "" || mdp_client_2.Password== "" || tel_inscription.Text == "")
            {
                MessageBox.Show("Champs manquants !");
            }
        }

        private void acces_pagecommande(object sender, RoutedEventArgs e)
        {
            commande fenetre = new commande();
            fenetre.Show();
        }
    }
}
