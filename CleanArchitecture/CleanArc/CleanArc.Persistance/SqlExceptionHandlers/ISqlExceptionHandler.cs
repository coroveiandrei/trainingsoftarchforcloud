using System;

namespace CleanArc.Persistance.SqlExceptionHandlers
{
    public interface ISqlExceptionHandler
    {
        void Handle(Exception exception);
    }
}
