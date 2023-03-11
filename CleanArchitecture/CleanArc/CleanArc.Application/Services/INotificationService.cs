using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArc.Application.Services
{

    public interface INotificationService
    {
        Task NotifyAsync(string message);
    }
}
