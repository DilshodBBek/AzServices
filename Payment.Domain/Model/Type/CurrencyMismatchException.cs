using System.Runtime.Serialization;

namespace Payment.Domain.Model.Type
{
	[Serializable]
	internal class CurrencyMismatchException : Exception
	{
		private Currency currency1;
		private Currency currency2;

		public CurrencyMismatchException()
		{
		}

		public CurrencyMismatchException(string? message) : base(message)
		{
		}

		public CurrencyMismatchException(Currency currency1, Currency currency2)
		{
			this.currency1 = currency1;
			this.currency2 = currency2;
		}

		public CurrencyMismatchException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected CurrencyMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}