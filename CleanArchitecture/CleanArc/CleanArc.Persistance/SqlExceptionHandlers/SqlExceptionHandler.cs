using System;
using Microsoft.Data.SqlClient;
using CleanArc.Application.Exceptions;
using CleanArc.Application.Interfaces;
using CleanArc.Common;
using CleanArc.Persistance.SqlExceptions;

namespace CleanArc.Persistance.SqlExceptionHandlers
{
    [MapServiceDependency(nameof(SqlExceptionHandler))]
	internal class SqlExceptionHandler : ISqlExceptionHandler
	{
		public void Handle(Exception exception)
		{
			var sqlException = exception.InnerException as SqlException;
			if (sqlException != null)
			{
				switch (sqlException.Number)
				{
					case 242:
						throw new DateTimeRangeRepositoryViolationException(sqlException);
					case 547:
						throw new DeleteConstraintRepositoryViolationException(sqlException);
					case 1205:
						throw new DeadlockVictimRepositoryViolationException(sqlException);
					case 2601:
					case 2627:
						throw new UniqueConstraintRepositoryViolationException(sqlException);
					default:
						throw new RepositoryViolationException(sqlException);
				}
			}

			throw new RepositoryViolationException(exception);
		}
	}
}