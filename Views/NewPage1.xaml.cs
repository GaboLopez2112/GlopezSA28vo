namespace lopezgSA2.Views;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}
    private async void OnCalcularNotasClicked(object sender, EventArgs e)
    {
        if (studentPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Seleccione un estudiante.", "OK");
            return;
        }

        if (!ValidarNotas(out double seg1, seguimiento1Entry.Text, "Seguimiento 1") ||
            !ValidarNotas(out double ex1, examen1Entry.Text, "Examen 1") ||
            !ValidarNotas(out double seg2, seguimiento2Entry.Text, "Seguimiento 2") ||
            !ValidarNotas(out double ex2, examen2Entry.Text, "Examen 2"))
            return;

        double parcial1 = (seg1 * 0.3) + (ex1 * 0.2);
        double parcial2 = (seg2 * 0.3) + (ex2 * 0.2);
        double notaFinal = parcial1 + parcial2;

        string estado;
        if (notaFinal >= 7)
            estado = "APROBADO";
        else if (notaFinal >= 5)
            estado = "COMPLEMENTARIO";
        else
            estado = "REPROBADO";

        string resultado = $"Nombre: {studentPicker.SelectedItem}\n" +
                           $"Fecha: {fechaPicker.Date:dd/MM/yyyy}\n" +
                           $"Nota Parcial 1: {parcial1:F2}\n" +
                           $"Nota Parcial 2: {parcial2:F2}\n" +
                           $"Nota Final: {notaFinal:F2}\n" +
                           $"Estado: {estado}";

        await DisplayAlert("Resultado", resultado, "OK");
    }

    private bool ValidarNotas(out double valor, string entrada, string campo)
    {
        if (!double.TryParse(entrada, out valor) || valor < 0 || valor > 10)
        {
            DisplayAlert("Error", $"Ingrese un valor válido (0-10) para {campo}.", "OK");
            valor = 0;
            return false;
        }
        return true;
    }
}

        
    
