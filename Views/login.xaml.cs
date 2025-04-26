namespace lopezgSA2.Views;

public partial class login : ContentPage
{
    private string[] usuarios = { "Carlos", "Ana", "Jose" };
    private string[] contrasenas = { "carlos123", "ana123", "jose123" };
    public login()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string user = usernameEntry.Text.Trim();
        string pass = passwordEntry.Text;

        int index = Array.IndexOf(usuarios, user);

        if (index != -1 && contrasenas[index] == pass)
        {
            await DisplayAlert("Bienvenido", $"Hola {user}, bienvenido al sistema.", "OK");
            await Navigation.PushAsync(new NewPage1());
        }
        else
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrecta.", "OK");
        }
    }
}