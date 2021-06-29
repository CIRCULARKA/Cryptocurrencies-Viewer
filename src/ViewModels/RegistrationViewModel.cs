using System.ComponentModel.DataAnnotations;

namespace CurrencyViewer.ViewModels
{
	public class RegistrationViewModel
	{
		[Required(ErrorMessage = "Email is required")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Password confirmation is required")]
		[Compare("Password", ErrorMessage = "Password mismatch")]
		[DataType(DataType.Password)]
		public string ConfirmedPassword { get; set; }
	}
}
