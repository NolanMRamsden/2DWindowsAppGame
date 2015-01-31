using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MonoGame.Framework;
using FieldFighter.Hittable.Characters.BaseCharacters;
using FieldFighter.Hittable.CharacterLogic;
using FieldFighter.Hittable.Castles;


namespace FieldFighter
{
    /// <summary>
    /// The root page used to display the game.
    /// </summary>
    public sealed partial class GamePage : SwapChainBackgroundPanel
    {
        readonly Game1 _game;

        public GamePage(string launchArguments)
        {
            this.InitializeComponent();

            // Create the game.
            _game = XamlGame<Game1>.Create(launchArguments, Window.Current.CoreWindow, this);
        }

        private void Button_Tapped_1(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            _game.right.spawn(ECharacterType.MELEE);
        }

        private void Button_Tapped_2(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            _game.right.spawn(ECharacterType.RANGED);
        }

        private void Button_Tapped_3(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            _game.right.spawn(ECharacterType.SPECIAL);
        }

        private void Button_Tapped_4L(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            _game.right.upgradeLeft();
        }

        private void Button_Tapped_4R(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            _game.right.upgradeRight();
        }

        private void Button_Tapped_5(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            _game.left.spawn(ECharacterType.MELEE);
        }

        private void Button_Tapped_6(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            _game.left.spawn(ECharacterType.RANGED);
        }

        private void Button_Tapped_7(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            _game.left.spawn(ECharacterType.SPECIAL);
        }

        private void Button_Tapped_8L(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            _game.left.upgradeLeft();
        }

        private void Button_Tapped_8R(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            _game.left.upgradeRight();
        }
    }
}
