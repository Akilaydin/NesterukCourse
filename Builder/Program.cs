#region
using static System.Console;
#endregion

// Person person = new PersonBuilder().Lives.At("StreetName").In("Moscow").WithPostcode("122220").Works.AsA("Developer").At("Microsoft").Earns(5000);
// WriteLine(person);

var service = new EmailService();
service.SendEmail(builder => builder.To("Artem").AddSubject("Subject").AddBody("Body").From("A mystery friend"));

public class EmailService
{
	public class EmailBuilder
	{
		private readonly Email _email;
		internal EmailBuilder(Email email)
		{
			_email = email;
		}

		public EmailBuilder From(string from)
		{
			_email.From = from;
			
			return this;
		}
		
		public EmailBuilder AddBody(string body)
		{
			_email.Body = body;
			
			return this;
		}
		
		public EmailBuilder AddSubject(string subject)
		{
			_email.Subject = subject;
			
			return this;
		}
		
		public EmailBuilder To(string to)
		{
			_email.To = to;
			
			return this;
		}
	}
	
	internal class Email
	{
		public string From, To, Subject, Body;

		public override string ToString()
		{
			return $"{From} {To} {Subject} {Body}";
		}
	}
	
	public void SendEmail(Action<EmailBuilder> buildEmailAction)
	{
		var resultEmail = new Email();
		buildEmailAction?.Invoke(new EmailBuilder(resultEmail));
		SendEmailInternal(resultEmail);
	}

	private void SendEmailInternal(Email email)
	{
		WriteLine("Sending email internal impl " + email);
	}
}

