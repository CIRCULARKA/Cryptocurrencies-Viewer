using System.ComponentModel.DataAnnotations;

namespace CurrencyViewer.ViewModels
{
	public class RegistrationViewModel
	{
		[Required]
		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "Password mismatch")]
		[DataType(DataType.Password)]
		public string ConfirmedPassword { get; set; }
	}
}
