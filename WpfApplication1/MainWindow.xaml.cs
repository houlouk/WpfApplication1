
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Music
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Dependency Property
        public static readonly DependencyProperty TailleBoutonProperty =
             DependencyProperty.Register("TailleBouton", typeof(double),
             typeof(MainWindow),
              new PropertyMetadata(
                    0d,                                            // The default value of the dependency property
                    new PropertyChangedCallback(OnValueChanged),  // Callback when the property changes
                    new CoerceValueCallback(CoerceValue)));
        // The coercion callback
        private static object CoerceValue(DependencyObject d, object value)
        {
            return value;
        }

        // The value changed callback 
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
        // .NET Property wrapper
        public double TailleBouton
        {
            get { return (double)GetValue(TailleBoutonProperty); }
            set { SetValue(TailleBoutonProperty, value); }
        }

        public MainWindow()
        {
            InitializeComponent();
            // notesNoires.ItemContainerGenerator.StatusChanged += new EventHandler(ItemContainerGenerator_StatusChanged);


        }

        /* private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
         {
             if (notesNoires.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
             {
                 for (int i = 0; i < notesNoires.Items.Count; i++)
                 {
                     /*UIElement separator =
                           ((StackPanel)notesNoires.ItemContainerGenerator.ContainerFromIndex(i)).Children[1];


                 }

             }

         }*/




    }
}
