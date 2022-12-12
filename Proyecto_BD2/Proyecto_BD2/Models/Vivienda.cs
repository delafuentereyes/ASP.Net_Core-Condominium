namespace Proyecto_BD2.Models
{
	public class Vivienda
	{
		public int ID_Vivienda { get; set; }
		public string? Numero_Vivienda { get; set; }
		public string? Desc_Vivienda { get; set; }
		public int Numero_Habitaciones { get; set; }
		public int Cochera { get; set; }
		public int ID_Habitacional { get; set; }
		public int? ID_Usuario { get; set; }

	}
}
