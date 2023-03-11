using System;
using Microsoft.Data.SqlClient;
using System.Runtime.Serialization;
using CleanArc.Application.Exceptions;

namespace CleanArc.Persistance.SqlExceptions
{
	[Serializable]
	public class UniqueConstraintRepositoryViolationException : RepositoryViolationException
	{
		public UniqueConstraintRepositoryViolationException()
		{
		}

		public UniqueConstraintRepositoryViolationException(string errorMessage)
			: base(errorMessage)
		{
		}

		public UniqueConstraintRepositoryViolationException(SqlException exception)
			: base(exception)
		{
		}

		public UniqueConstraintRepositoryViolationException(string message, Exception exception)
			: base(message, exception)
		{
		}

		protected UniqueConstraintRepositoryViolationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}